using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerInfo
{

    public partial class Form1 : Form
    {
        static int custom_id;
        private Image uploadedImage;
        int created_user_id;
        int updated_user_id;
        int deleted_user_id;
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";
        private string imagePath;
        public Form1()
        {
            InitializeComponent();
           
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

            LoadData();
            this.Load += Form1_Load;
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

                foreach (DataRow row in dt.Rows)
                {
                    string photoPath = row["photo"].ToString();
                    if (File.Exists(photoPath))
                    {
                        int rowIndex = dt.Rows.IndexOf(row);
                        dataGridView1.Rows[rowIndex].Cells["Photo"].Value = Image.FromFile(photoPath);
                    }
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
            img.Refresh();
            img.Image = null;
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            rdoOther.Checked = false;
            img.Refresh();

        }
      

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int age = CalculateAge();
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                txtCustomID.Text = selectedRow.Cells["customer_id"].Value.ToString();
                txtCustomName.Text = selectedRow.Cells["customer_name"].Value.ToString();
                txtNRC.Text = selectedRow.Cells["nrc_number"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["email"].Value.ToString();
                txtPh1.Text = selectedRow.Cells["phone_no_1"].Value.ToString();
                txtPh2.Text = selectedRow.Cells["phone_no_2"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["address"].Value.ToString();
                txtAge.Text = age.ToString(); 
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
            string memberID ="";
            string name = txtCustomName.Text;
            string NRC = txtNRC.Text;
            DateTime dob = dtpDOB.Value;
            string email = txtEmail.Text;
            int isDeleted = 0;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            int memberCard = ddlMemberCard.SelectedIndex == 0 ? 1 : 2; 
            int gender = rdoMale.Checked ? 1 : rdoFemale.Checked ? 2 : 0;
            deleted_user_id = 0;
          
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone1) || string.IsNullOrWhiteSpace(phone2) ||string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all fields.");

                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }
            if (!IsValidNRC(NRC))
            {
                MessageBox.Show("Please enter a valid NRC in the format 'X/Y123456' where X is 1-14, Y is letters, and optionally (A) for additional info.");
                return;
            }
            if (!IsValidPhone(phone1))
            {
                MessageBox.Show("Please enter a valid phone Number.");
                return;
            }
            if (!IsValidPhone(phone2))
            {
                MessageBox.Show("Please enter a valid phone Number.");
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
                    updated_user_id = 1;
                    query = @"UPDATE Customers SET 
                                customer_name = @name, 
                                photo = @photo,
                                nrc_number = @nrc, 
                                dob = @dob, 
                                email = @Email,
                                is_deleted = @isDeleted,
                                phone_no_1 = @phone1, 
                                phone_no_2 = @phone2, 
                                address = @address, 
                                member_card = @memberCard, 
                                updated_user_id =@updated_user_id,
                                updated_datetime = @updated_datetime,
                                gender = @gender
                              WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
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
                        cmd.Parameters.AddWithValue("@updated_user_id", updated_user_id);
                        cmd.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Row Update Successfully");
                }
                else
                {
                    int latestId = (int)new SqlCommand("SELECT ISNULL(MAX(CAST(SUBSTRING(customer_id, 3, LEN(customer_id) - 2) AS INT)), 0) FROM Customers", conn).ExecuteScalar();
                    custom_id = latestId + 1;
                    memberID = $"C-{custom_id:D4}";
                    updated_user_id = 0;
                    created_user_id = 1;
                    query = @"INSERT INTO Customers (customer_id,customer_name,photo, nrc_number, dob, email,is_deleted, phone_no_1, phone_no_2, address,created_user_id,updated_user_id,deleted_user_id,created_datetime, member_card, gender) 
                              VALUES (@memberID, @name,@photo, @nrc, @dob, @Email,@isDeleted, @phone1, @phone2, @address,@created_user_id,@updated_user_id,@deleted_user_id,@created_datetime,@memberCard, @gender)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            var selectedRow = dataGridView1.SelectedRows[0];
                            int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@created_datetime", DateTime.Now);
                        }

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
                        cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
                        cmd.Parameters.AddWithValue("@created_user_id", created_user_id);
                        cmd.Parameters.AddWithValue("@updated_user_id", updated_user_id);
                        cmd.Parameters.AddWithValue("@deleted_user_id", deleted_user_id);
                        cmd.Parameters.AddWithValue("@photo", imagePath);

                        cmd.ExecuteNonQuery();
                    }
                }
                
               
                conn.Close();
            }
            imagePath = null;
            LoadData();
            
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
                string query = @"UPDATE Customers SET 
                             is_deleted = 1, 
                             deleted_user_id = 1,
                             deleted_datetime = @deleted_datetime 
                             WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    query = "DELETE FROM Customers WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@deleted_datetime", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
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
            int currentYear = DateTime.Now.Year;

            int birthYear = dob.Year;
            int age = currentYear - birthYear;

            if(dob > DateTime.Now.AddYears(-age)) age--;
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
                         deleted_user_id=1,
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
                    conn.Close();
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
