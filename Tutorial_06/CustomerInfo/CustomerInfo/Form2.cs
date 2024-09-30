using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace CustomerInfo
{
    public partial class Registeration_Form : Form
    {
        static int custom_id;
        //private Image uploadedImage;
        int created_user_id;
        int updated_user_id;
        int deleted_user_id;
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private string imagePath;
        private const int maxCustomerNameLength = 15;
        private const int maxEmailLength = 100;
        string hashedPassword;
        public Registeration_Form()
        {
            InitializeComponent();
            CalculateAge();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                 hashedPassword = HashPassword(txtPwd.Text);

            }
            else
            {
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                InsertCustomer(conn);
                conn.Close();
            }
            UserProfile_Form userProfileForm = new UserProfile_Form();
            userProfileForm.Show(); 
            this.Hide();

        }
        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert hash bytes to hex string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private bool ValidateInputs()
        {
            string name = txtCustomName.Text;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string NRC = txtNRC.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone1) ||
                string.IsNullOrWhiteSpace(phone2) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPwd.Text) || string.IsNullOrWhiteSpace(txtConfirmPwd.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (txtPwd.Text != txtConfirmPwd.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }
            if (name.Length > maxCustomerNameLength)
            {
                MessageBox.Show($"Customer name cannot exceed {maxCustomerNameLength} characters.");
                return false;
            }

            if (email.Length > maxEmailLength)
            {
                MessageBox.Show($"Email cannot exceed {maxEmailLength} characters.");
                return false;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }
            if (!IsValidNRC(NRC))
            {
                MessageBox.Show("Please enter a valid NRC.");
                return false;
            }
            if (!IsValidPhone(phone1) || !IsValidPhone(phone2))
            {
                MessageBox.Show("Please enter valid phone numbers.");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return email != null && regex.IsMatch(email);
        }
        private bool IsValidNRC(string nrc)
        {
            Regex regex = new Regex(@"^(1[0-4]|[1-9])/[A-Za-z]+(\([A-Za-z]\))?\d{6}$");
            return regex.IsMatch(nrc);
        }

        private bool IsValidPhone(string phoneNo)
        {
            Regex regex = new Regex(@"^[\d()+-]+$");
            return phoneNo != null && regex.IsMatch(phoneNo);
        }


        private void InsertCustomer(SqlConnection conn)
        {
            int latestId = (int)new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(customer_id, 3, LEN(customer_id) - 2) AS INT)), 0) FROM Customers", conn).ExecuteScalar();
            string memberID = $"C-{(latestId + 1):D4}";
            created_user_id = latestId;
            string query = @"INSERT INTO Customers (customer_id, customer_name,password, photo, nrc_number, dob, email, is_deleted, phone_no_1, phone_no_2, address, created_user_id, updated_user_id, deleted_user_id, created_datetime, member_card, gender) 
                     VALUES (@memberID, @name,@hashedPassword, @photo, @nrc, @dob, @Email, @isDeleted, @phone1, @phone2, @address, @created_user_id, @updated_user_id, @deleted_user_id, @created_datetime, @memberCard, @gender)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@created_datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                AddCustomerParameters(cmd);

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("New customer added successfully.");
        }

        private void AddCustomerParameters(SqlCommand cmd, int? id = null)
        {
            string name = txtCustomName.Text;
            string NRC = txtNRC.Text;
            DateTime dob = dtpDOB.Value;
            string email = txtEmail.Text;
            int isDeleted = 0;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            int memberCard = cboMemberCard.SelectedIndex == 0 ? 1 : 2;
            int gender = rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0;

            if (id.HasValue)
            {
                cmd.Parameters.AddWithValue("@id", id.Value);
                cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
            }

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@nrc", NRC);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@phone1", phone1);
            cmd.Parameters.AddWithValue("@phone2", phone2);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@memberCard", memberCard);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
            cmd.Parameters.AddWithValue("@created_user_id", 1);
            cmd.Parameters.AddWithValue("@updated_user_id", 0);
            cmd.Parameters.AddWithValue("@deleted_user_id", 0);
            cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
            cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword);
        }

        private void btnUpload_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image uploadedImage = Image.FromFile(openFileDialog.FileName);
                    img.Image = uploadedImage;
                    imagePath = Path.Combine(@"C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_06\CustomerInfo\CustomerInfo\image", Path.GetFileName(openFileDialog.FileName));
                    uploadedImage.Save(imagePath);
                }
            }
        }
        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }

        private int CalculateAge()
        {
            DateTime dob = dtpDOB.Value;
            int currentYear = DateTime.Now.Year;

            int birthYear = dob.Year;
            int age = currentYear - birthYear;

            if (dob > DateTime.Now.AddYears(-age)) age--;
            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.");
                return 0;
            }

            if (age < 0)
            {
                MessageBox.Show("Calculated age is negative. Please check the date of birth.");
                return 0;
            }
            txtAge.Text = age.ToString();
            return age;
        }

    }
}
