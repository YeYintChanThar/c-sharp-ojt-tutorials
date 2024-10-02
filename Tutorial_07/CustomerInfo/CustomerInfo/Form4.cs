using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerInfo
{
    public partial class CustomerInfoEdit : Form
    {
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private int customerId;
        private Image uploadedImage;
        private string imagePath;
        private int userId;

        public CustomerInfoEdit(int id)
        {
            InitializeComponent();
            customerId = id;
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, customer_name, customer_id, nrc_number, dob, email, phone_no_1, phone_no_2, address, member_card, gender, photo FROM Customers WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(0);
                            txtCustomName.Text = reader["customer_name"].ToString();
                            txtCustomID.Text = reader["customer_id"].ToString();
                            txtNRC.Text = reader["nrc_number"].ToString();
                            lblDOB.Text = Convert.ToDateTime(reader["dob"]).ToShortDateString();
                            CalculateAge();
                            txtEmail.Text = reader["email"].ToString();
                            txtPh1.Text = reader["phone_no_1"].ToString();
                            txtPh2.Text = reader["phone_no_2"].ToString();
                            txtAddress.Text = reader["address"].ToString();
                            cboMemberCard.SelectedIndex = Convert.ToInt32(reader["member_card"]) - 1;
                            string photoPath = reader["photo"].ToString();

                            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                            {
                                img.Image = Image.FromFile(photoPath);
                            }

                            int genderValue = Convert.ToInt32(reader["gender"]);
                            rdoMale.Checked = genderValue == 1;
                            rdoFemale.Checked = genderValue == 2;
                            rdoOther.Checked = genderValue == 0;
                        }
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

            if (new[] { name, phone1, phone2, address }.Any(string.IsNullOrWhiteSpace))
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

        private bool IsValidEmail(string email) =>
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private bool IsValidNRC(string nrc) =>
            Regex.IsMatch(nrc, @"^(1[0-4]|[1-9])/[A-Za-z]+(\([A-Za-z]\))?\d{6}$");

        private bool IsValidPhone(string phoneNo) =>
            Regex.IsMatch(phoneNo, @"^[\d()+-]+$");

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
                cmd.Parameters.AddWithValue("@memberCard", cboMemberCard.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@gender", rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0);
                cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                cmd.Parameters.AddWithValue("@id", customerId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer details updated successfully.");
                this.Close();
                new UserProfile_Form(userId).Show();
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }

        private void CalculateAge()
        {
            DateTime dob = dtpDOB.Value;
            int age = DateTime.Now.Year - dob.Year;

            if (dob > DateTime.Now.AddYears(-age)) age--;

            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.");
                return;
            }

            if (age < 0)
            {
                MessageBox.Show("Calculated age is negative. Please check the date of birth.");
                return;
            }

            txtAge.Text = age.ToString();
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
                    new UserProfile_Form(userId).Show();
                }
                else
                {
                    MessageBox.Show("Customer deletion failed. Please try again.");
                }
            }
        }
    }
}
