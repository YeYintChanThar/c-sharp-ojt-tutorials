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
        private Image uploadedImage;
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private string imagePath;
        private const int PageSize = 10;
        private int totalPages;
        private int currentPageIndex;
        private int totalRows;
        private const int maxCustomerNameLength = 15;
        private const int maxEmailLength = 100;

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadData();
            currentPageIndex = 1;
            PagniationLoadData();
            lblCurrentPage.Text = currentPageIndex.ToString();
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

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customers WHERE is_deleted = 0";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                foreach (DataRow row in dt.AsEnumerable())
                {
                    string photoPath = row.Field<string>("photo");
                    if (File.Exists(photoPath))
                    {
                        int rowIndex = dt.Rows.IndexOf(row);
                        dataGridView1.Rows[rowIndex].Cells["Photo"].Value = Image.FromFile(photoPath);
                    }
                }

                dataGridView1.ClearSelection();
            }
        }

        private void PagniationLoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                totalRows = (int)new SqlCommand("SELECT COUNT(*) FROM Customers", conn).ExecuteScalar();
                totalPages = (int)Math.Ceiling((double)totalRows / PageSize);
                lblTotalPages.Text = totalPages.ToString();

                string paginatedQuery = $"SELECT * FROM Customers WHERE is_deleted = 0 ORDER BY id OFFSET {(currentPageIndex - 1) * PageSize} ROWS FETCH NEXT {PageSize} ROWS ONLY";
                SqlDataAdapter adapter = new SqlDataAdapter(paginatedQuery, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                lblTotalRowsCount.Text = totalRows.ToString();
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


                txtCustomID.Text = selectedRow.Cells["customer_id"].Value?.ToString() ?? string.Empty;
                txtCustomName.Text = selectedRow.Cells["customer_name"].Value?.ToString() ?? string.Empty;
                txtNRC.Text = selectedRow.Cells["nrc_number"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = selectedRow.Cells["email"].Value?.ToString() ?? string.Empty;
                txtPh1.Text = selectedRow.Cells["phone_no_1"].Value?.ToString() ?? string.Empty;
                txtPh2.Text = selectedRow.Cells["phone_no_2"].Value?.ToString() ?? string.Empty;
                txtAddress.Text = selectedRow.Cells["address"].Value?.ToString() ?? string.Empty;


                if (DateTime.TryParse(selectedRow.Cells["dob"].Value?.ToString(), out DateTime dob))
                {
                    dtpDOB.Value = dob;
                    txtAge.Text = CalculateAge(dob).ToString();
                }

                // Member card retrieval
                if (int.TryParse(selectedRow.Cells["member_card"].Value?.ToString(), out int memberCardValue))
                {
                    ddlMemberCard.SelectedIndex = memberCardValue == 1 ? 0 : 1;
                }

                string gender = selectedRow.Cells["gender"].Value?.ToString();
                rdoMale.Checked = gender == "1";
                rdoFemale.Checked = gender == "2";
                rdoOther.Checked = gender == "0";

                img.Image = selectedRow.Cells["Photo"].Value as Image;
            }
        }

        private void btnAddAndUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    UpdateCustomer(conn);
                }
                else
                {
                    InsertCustomer(conn);
                }
            }

            imagePath = null;
            LoadData();
        }

        private bool ValidateInputs()
        {
            string name = txtCustomName.Text;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string nrc = txtNRC.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone1) ||
                string.IsNullOrWhiteSpace(phone2) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all fields.");
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
            if (!IsValidNRC(nrc))
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

        private void UpdateCustomer(SqlConnection conn)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

            string query = @"UPDATE Customers SET 
                        customer_name = @name, 
                        photo = @photo,
                        nrc_number = @nrc, 
                        dob = @dob, 
                        email = @Email,
                        phone_no_1 = @phone1, 
                        phone_no_2 = @phone2, 
                        address = @address, 
                        member_card = @memberCard, 
                        updated_datetime = @updated_datetime,
                        gender = @gender
                     WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                AddCustomerParameters(cmd, id);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Row updated successfully.");
        }

        private void InsertCustomer(SqlConnection conn)
        {
            int latestId = (int)new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(customer_id, 3, LEN(customer_id) - 2) AS INT)), 0) FROM Customers", conn).ExecuteScalar();
            string memberID = $"C-{(latestId + 1):D4}";

            string query = @"INSERT INTO Customers (customer_id, customer_name, photo, nrc_number, dob, email, phone_no_1, phone_no_2, address, created_datetime, member_card, gender) 
                     VALUES (@memberID, @name, @photo, @nrc, @dob, @Email, @phone1, @phone2, @address, @created_datetime, @memberCard, @gender)";

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
            string nrc = txtNRC.Text;
            DateTime dob = dtpDOB.Value;
            string email = txtEmail.Text;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            int memberCard = ddlMemberCard.SelectedIndex + 1; 
            int gender = rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0;

            if (id.HasValue)
            {
                cmd.Parameters.AddWithValue("@id", id.Value);
                cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
            }

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@nrc", nrc);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@phone1", phone1);
            cmd.Parameters.AddWithValue("@phone2", phone2);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@memberCard", memberCard);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
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

        private bool IsValidEmail(string email) => new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").IsMatch(email);
        private bool IsValidNRC(string nrc) => new Regex(@"^(1[0-4]|[1-9])/[A-Za-z]+(\([A-Za-z]\))?\d{6}$").IsMatch(nrc);
        private bool IsValidPhone(string phoneNo) => new Regex(@"^[\d()+-]+$").IsMatch(phoneNo);

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string query = "DELETE FROM Customers WHERE id = @id";

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
        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);


                string query = "UPDATE Customers SET is_deleted = 1 WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Customer soft deleted successfully.");
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Please select a row to soft delete.");
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Text = CalculateAge(dtpDOB.Value).ToString();
        }

        private int CalculateAge(DateTime dob)
        {
            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.");
                return 0;
            }

            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;

            return age < 0 ? 0 : age;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPageIndex < totalPages)
            {
                currentPageIndex++;
                PagniationLoadData();
                lblCurrentPage.Text = currentPageIndex.ToString();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPageIndex > 1)
            {
                currentPageIndex--;
                PagniationLoadData();
                lblCurrentPage.Text = currentPageIndex.ToString();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPageIndex = 1;
            PagniationLoadData();
            lblCurrentPage.Text = currentPageIndex.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPageIndex = totalPages;
            PagniationLoadData();
            lblCurrentPage.Text = currentPageIndex.ToString();
        }
    }
}
