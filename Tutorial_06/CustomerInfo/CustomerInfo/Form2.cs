using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerInfo
{
    public partial class Registeration_Form : Form
    {
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private string imagePath;
        private const int maxCustomerNameLength = 15;
        private const int maxEmailLength = 100;
        private string hashedPassword;

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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    InsertCustomer(conn);
                }

                UserProfile_Form userProfileForm = new UserProfile_Form();
                userProfileForm.Show();
                this.Hide();
            }
        }

        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return string.Concat(hashBytes.Select(b => b.ToString("x2")));
            }
        }

        private bool ValidateInputs()
        {
            var inputs = new[]
            {
                (txtCustomName.Text, "Customer name"),
                (txtPh1.Text, "Phone 1"),
                (txtPh2.Text, "Phone 2"),
                (txtAddress.Text, "Address"),
                (txtPwd.Text, "Password"),
                (txtConfirmPwd.Text, "Confirm Password")
            };

            foreach (var (input, fieldName) in inputs)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show($"Please fill in {fieldName}.");
                    return false;
                }
            }

            if (txtPwd.Text != txtConfirmPwd.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            if (txtCustomName.Text.Length > maxCustomerNameLength)
            {
                MessageBox.Show($"Customer name cannot exceed {maxCustomerNameLength} characters.");
                return false;
            }

            if (txtEmail.Text.Length > maxEmailLength)
            {
                MessageBox.Show($"Email cannot exceed {maxEmailLength} characters.");
                return false;
            }

            if (!IsValidEmail(txtEmail.Text) || !IsValidNRC(txtNRC.Text) ||
                !IsValidPhone(txtPh1.Text) || !IsValidPhone(txtPh2.Text))
            {
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidNRC(string nrc)
        {
            return Regex.IsMatch(nrc, @"^(1[0-4]|[1-9])/[A-Za-z]+(\([A-Za-z]\))?\d{6}$");
        }

        private bool IsValidPhone(string phoneNo)
        {
            return Regex.IsMatch(phoneNo, @"^[\d()+-]+$");
        }

        private void InsertCustomer(SqlConnection conn)
        {
            string memberID = GetNewMemberID(conn);
            string query = @"INSERT INTO Customers (customer_id, customer_name, password, photo, nrc_number, dob, email, is_deleted, phone_no_1, phone_no_2, address, created_datetime, member_card, gender) 
                             VALUES (@memberID, @name, @hashedPassword, @photo, @nrc, @dob, @Email, @isDeleted, @phone1, @phone2, @address, @created_datetime, @memberCard, @gender)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@created_datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                AddCustomerParameters(cmd);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("New customer added successfully.");
        }

        private string GetNewMemberID(SqlConnection conn)
        {
            int latestId = (int)new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(customer_id, 3, LEN(customer_id) - 2) AS INT)), 0) FROM Customers", conn).ExecuteScalar();
            return $"C-{(latestId + 1):D4}";
        }

        private void AddCustomerParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@name", txtCustomName.Text);
            cmd.Parameters.AddWithValue("@nrc", txtNRC.Text);
            cmd.Parameters.AddWithValue("@dob", dtpDOB.Value);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone1", txtPh1.Text);
            cmd.Parameters.AddWithValue("@phone2", txtPh2.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@memberCard", cboMemberCard.SelectedIndex == 0 ? 1 : 2);
            cmd.Parameters.AddWithValue("@gender", rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0);
            cmd.Parameters.AddWithValue("@isDeleted", 0);
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
            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.");
                return 0;
            }

            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;

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
