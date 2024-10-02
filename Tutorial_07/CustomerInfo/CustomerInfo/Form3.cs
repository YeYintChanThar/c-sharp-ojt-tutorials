using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CustomerInfo
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, password FROM Customers WHERE (customer_name = @username OR customer_id = @username)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var customers = new List<Customer>();

                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32(0),
                                HashedPassword = reader.GetString(1)
                            });
                        }

                        var matchedCustomer = customers.FirstOrDefault(c => c.HashedPassword == hashedPassword);

                        if (matchedCustomer != null)
                        {
                            MessageBox.Show("Login successful!");
                            UserProfile_Form userProfileForm = new UserProfile_Form(matchedCustomer.Id);
                            userProfileForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private class Customer
        {
            public int Id { get; set; }
            public string HashedPassword { get; set; }
        }
    }
}
