﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CustomerInfo
{
    public partial class UserProfile_Form : Form
    {
        private string connectionString = "Data Source=DESKTOP-GKTPEC8\\SQLEXPRESSTESTER;Initial Catalog=CustomerDb;Integrated Security=True;";

        private const int PageSize = 10;
        private int totalPages = 0;
        private int currentPageIndex = 1;
        private int totalRows = 0;
        private int? currentUserId;

        public UserProfile_Form(int? userId = null)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            currentUserId = userId;

            this.Load += Form1_Load;
            currentPageIndex = 1;
            PagniationLoadData();
            lblCurrentPage.Text = currentPageIndex.ToString();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        public void LoadData(string searchItem = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Customers WHERE is_deleted = 0";

                    if (!string.IsNullOrEmpty(searchItem))
                    {
                        query += " AND (customer_name LIKE @searchItem OR customer_id LIKE @searchItem OR nrc_number LIKE @searchItem " +
                                  "OR dob LIKE @searchItem OR email LIKE @searchItem OR phone_no_1 LIKE @searchItem " +
                                  "OR phone_no_2 LIKE @searchItem OR address LIKE @searchItem OR member_card LIKE @searchItem " +
                                  "OR gender LIKE @searchItem OR id LIKE @searchItem)";
                    }

                    if (currentUserId.HasValue)
                    {
                        query += " AND id = @userId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchItem))
                        {
                            cmd.Parameters.AddWithValue("@searchItem", "%" + searchItem + "%");
                        }

                        if (currentUserId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@userId", currentUserId.Value);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Prepare image column
                        dt.Columns.Add("Image", typeof(Image));

                        // Load images into the DataTable
                        foreach (DataRow row in dt.Rows)
                        {
                            string photoPath = row["photo"].ToString();
                            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                            {
                                // Load the image from file
                                row["Image"] = Image.FromFile(photoPath);
                            }
                            else
                            {
                                row["Image"] = null; // Or handle it as needed
                            }
                        }

                        // Update DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"An error occurred while searching: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Invalid format: {formatEx.Message}", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PagniationLoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE is_deleted = 0", conn);
                totalRows = (int)cmd.ExecuteScalar();
                totalPages = (int)Math.Ceiling((double)totalRows / PageSize);
                lblTotalPages.Text = totalPages.ToString();

                if (currentPageIndex < 1) currentPageIndex = 1;
                if (currentPageIndex > totalPages) currentPageIndex = totalPages;
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Customers WHERE is_deleted = 0 ORDER BY id OFFSET {(currentPageIndex - 1) * PageSize} ROWS FETCH NEXT {PageSize} ROWS ONLY", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                lblTotalRowsCount.Text = totalRows.ToString();
            }
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(selectedRow.Cells["Column0"].Value); // Replace "Column0" with your actual column name

                this.Close();
                CustomerInfoEdit detailsForm = new CustomerInfoEdit(id);
                detailsForm.Show();
            }
        }

        private void menuEntryPage_Click(object sender, EventArgs e)
        {
            this.Close();
            Registeration_Form registeration_Form = new Registeration_Form();
            registeration_Form.ShowDialog();
        }

        private void menuLoginPage_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login_form = new LoginForm();
            login_form.ShowDialog();
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login_form = new LoginForm();
            login_form.ShowDialog();
        }
    }
}