using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace CustomerInfo
{
    public partial class CustomerInfoEdit : Form
    {
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private int customerId;
        private Image uploadedImage;
        private string imagePath;
        int userId;
        public CustomerInfoEdit(int id)
        {
            InitializeComponent();
            customerId = id;
            LoadCustomerDetails();
        }
        private void LoadCustomerDetails()
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id,customer_name,customer_id, nrc_number, dob, email, phone_no_1, phone_no_2, address, member_card, gender, photo FROM Customers WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userId = Convert.ToInt32(reader["id"]);
                        txtCustomName.Text = reader["customer_name"].ToString();
                        txtCustomID.Text = reader["customer_id"].ToString();
                        txtNRC.Text = reader["nrc_number"].ToString();
                        lblDOB.Text = Convert.ToDateTime(reader["dob"]).ToShortDateString();
                        CalculateAge();
                        txtEmail.Text = reader["email"].ToString();
                        txtPh1.Text = reader["phone_no_1"].ToString();
                        txtPh2.Text = reader["phone_no_2"].ToString();
                        txtAddress.Text = reader["address"].ToString();
                        cboMemberCard.Text = reader["member_card"].ToString();
                        string photoPath = reader["photo"].ToString();
                        if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                        {
                            img.Image = Image.FromFile(photoPath);
                        }
                        
                        int genderValue = Convert.ToInt32(reader["gender"]);
                        if (genderValue == 0)
                            rdoOther.Checked = true;
                        else if (genderValue == 1)
                            rdoMale.Checked = true;
                        else
                            rdoFemale.Checked = true;
                    }

                }
            }
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    UpdateCustomer(conn);
                }
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

        private void UpdateCustomer(SqlConnection conn)
        {
            string query = @"UPDATE Customers SET 
                        customer_name = @name, 
                        nrc_number = @nrc, 
                        dob = @dob, 
                        email = @Email, 
                        phone_no_1 = @phone1, 
                        phone_no_2 = @phone2, 
                        address = @address, 
                        member_card = @memberCard, 
                        gender = @gender, 
                        photo = @photo
                     WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
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
                cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                cmd.Parameters.AddWithValue("@id", customerId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer details updated successfully.");
                this.Close();
                UserProfile_Form userProfile_Form = new UserProfile_Form(userId);
                userProfile_Form.Show();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    uploadedImage = Image.FromFile(openFileDialog.FileName);
                    img.Image = uploadedImage;
                    imagePath = Path.Combine(@"C:\Users\yyct\Desktop\c-sharp-ojt-tutorials\Tutorial_04\CustomerInfo\CustomerInfo\image", Path.GetFileName(openFileDialog.FileName));
                    uploadedImage.Save(imagePath);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmationResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmationResult == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    DeleteCustomer(conn);
                }
            }
        }
        private void DeleteCustomer(SqlConnection conn)
        {
            string query = "UPDATE Customers SET is_deleted = 1 WHERE id = @id"; 

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", customerId);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer deleted successfully.");
                    this.Close();
                    UserProfile_Form userProfile_Form = new UserProfile_Form(userId);
                    userProfile_Form.Show();
                }
                else
                {
                    MessageBox.Show("Customer deletion failed. Please try again.");
                }
            }
        }

    }
}
