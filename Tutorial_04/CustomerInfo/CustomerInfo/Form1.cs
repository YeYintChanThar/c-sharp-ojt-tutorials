using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerInfo
{
    public partial class Form1 : Form
    {
        static int custom_id;
        private Image uploadedImage;
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private string imagePath;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
            this.Load += Form1_Load;
        }

        private void InitializeDataGridView()
        {
            if (!dataGridView1.Columns.Contains("Photo"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = "Photo",
                    HeaderText = "Photo",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Insert(0, imgColumn);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE is_deleted = 0";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                var photoPaths = dt.AsEnumerable()
                    .Select(row => new
                    {
                        PhotoPath = row.Field<string>("photo"),
                        RowIndex = dt.Rows.IndexOf(row)
                    })
                    .Where(item => File.Exists(item.PhotoPath));

                foreach (var item in photoPaths)
                {
                    dataGridView1.Rows[item.RowIndex].Cells["Photo"].Value = Image.FromFile(item.PhotoPath);
                }

                dataGridView1.ClearSelection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomID.Clear();
            txtCustomName.Clear();
            txtNRC.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtPh1.Clear();
            txtPh2.Clear();
            txtAddress.Clear();
            img.Image = null;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            rdoOther.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                txtCustomID.Text = selectedRow.Cells["customer_id"].Value.ToString();
                txtCustomName.Text = selectedRow.Cells["customer_name"].Value.ToString();
                txtNRC.Text = selectedRow.Cells["nrc_number"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["email"].Value.ToString();
                txtPh1.Text = selectedRow.Cells["phone_no_1"].Value.ToString();
                txtPh2.Text = selectedRow.Cells["phone_no_2"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["address"].Value.ToString();
                ddlMemberCard.SelectedItem = selectedRow.Cells["member_card"].Value.ToString();
                string gender = selectedRow.Cells["gender"].Value.ToString();
                rdoMale.Checked = gender == "1";
                rdoFemale.Checked = gender == "2";
                rdoOther.Checked = gender == "0";

                if (DateTime.TryParse(selectedRow.Cells["dob"].Value.ToString(), out DateTime dob))
                {
                    dtpDOB.Value = dob;
                }

                img.Image = selectedRow.Cells["Photo"].Value as Image;
            }
        }

        private void btnAddAndUpdate_Click(object sender, EventArgs e)
        {
            string memberID = "";
            string name = txtCustomName.Text;
            string NRC = txtNRC.Text;
            DateTime dob = dtpDOB.Value;
            string email = txtEmail.Text;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            int memberCard = ddlMemberCard.SelectedIndex == 0 ? 1 : 2;
            int gender = rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone1) || string.IsNullOrWhiteSpace(phone2) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!IsValidEmail(email) || !IsValidNRC(NRC) || !IsValidPhone(phone1) || !IsValidPhone(phone2))
            {
                return; 
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    query = @"UPDATE Customers SET 
                                customer_name = @name, 
                                photo = @photo,
                                nrc_number = @nrc, 
                                dob = @dob, 
                                email = @Email,
                                phone_no_1 = @phone1, 
                                phone_no_2 = @phone2, 
                                address = @address, 
                                member_card = @memberCard, 
                                gender = @gender
                              WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@nrc", NRC);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@phone1", phone1);
                        cmd.Parameters.AddWithValue("@phone2", phone2);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@memberCard", memberCard);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Row updated successfully");
                }
                else
                {
                    int latestId = (int)new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(customer_id, 3, LEN(customer_id) - 2) AS INT)), 0) FROM Customers", conn).ExecuteScalar();
                    custom_id = latestId + 1;
                    memberID = $"C-{custom_id:D4}";
                    query = @"INSERT INTO Customers (customer_id, customer_name, photo, nrc_number, dob, email, phone_no_1, phone_no_2, address, member_card, gender) 
                              VALUES (@memberID, @name, @photo, @nrc, @dob, @Email, @phone1, @phone2, @address, @memberCard, @gender)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@memberID", memberID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@nrc", NRC);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@phone1", phone1);
                        cmd.Parameters.AddWithValue("@phone2", phone2);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@memberCard", memberCard);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Row added successfully");
                }
                LoadData();
            }
            imagePath = null;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string query = @"DELETE FROM Customers WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }

        private int CalculateAge()
        {
            DateTime dob = dtpDOB.Value;
            int age = DateTime.Now.Year - dob.Year;

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

        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                string query = @"UPDATE Customers SET 
                                 is_deleted = 1, 
                                 deleted_datetime = @deleted_datetime 
                                 WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@deleted_datetime", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}
