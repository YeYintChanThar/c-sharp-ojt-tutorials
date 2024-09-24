using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CustomerInfo
{
    
    public partial class Form1 : Form
    {
        static int customerID = 0;
        private Image uploadedImage;

        public Form1()
        {
            InitializeComponent();
            ddlMemberCard.SelectedIndex = 0;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Underline);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridView1.RowTemplate.Height = 100;
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
      
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                
                txtCustomID.Text = selectedRow.Cells["Column1"].Value.ToString();
                txtCustomName.Text = selectedRow.Cells["Column3"].Value.ToString();
                txtNRC.Text = selectedRow.Cells["Column4"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Column6"].Value.ToString();
                txtPh1.Text = selectedRow.Cells["Column9"].Value.ToString();
                txtPh2.Text = selectedRow.Cells["Column10"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Column11"].Value.ToString();

                
                txtAge.Text = selectedRow.Cells["Column8"].Value.ToString();
                ddlMemberCard.SelectedItem = selectedRow.Cells["Column5"].Value.ToString();
                string gender = selectedRow.Cells["Column7"].Value.ToString();
                rdoMale.Checked = gender == "Male";
                rdoFemale.Checked = gender == "Female";
                rdoOther.Checked = gender == "Other";
            }

        }

        private void btnAddAndUpdate_Click(object sender, EventArgs e)
        {

            string id;
            string name = txtCustomName.Text;
            string NRC = txtNRC.Text;
            int age = CalculateAge();
           
            string email = txtEmail.Text;
            string phone1 = txtPh1.Text;
            string phone2 = txtPh2.Text;
            string address = txtAddress.Text;
            string staffType = ddlMemberCard.SelectedItem?.ToString();
            string gender = rdoMale.Checked ? "Male" : rdoFemale.Checked ? "Female" : rdoOther.Checked ? "Other" : "Not specified"; // Radio buttons
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
            if (phone1 == phone2)
            {
                MessageBox.Show("Phone Number1 and 2 must not same");
            }
            

            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                var selectedRow = dataGridView1.SelectedRows[0];


                id = selectedRow.Cells["Column1"].Value.ToString();
                selectedRow.Cells["Column2"].Value = uploadedImage;
                selectedRow.Cells["Column3"].Value = name;
                selectedRow.Cells["Column4"].Value = NRC;
                selectedRow.Cells["Column5"].Value = staffType;
                selectedRow.Cells["Column6"].Value = email;
                selectedRow.Cells["Column7"].Value = gender;
                selectedRow.Cells["Column8"].Value = age;

                selectedRow.Cells["Column9"].Value = phone1;
                selectedRow.Cells["Column10"].Value = phone2;
                selectedRow.Cells["Column11"].Value = address;
            
            }
            else
            {
                customerID += 1;
                id = $"C-{customerID:D4}";
                dataGridView1.Rows.Add(id, uploadedImage, name, NRC, staffType, email, gender, age, phone1, phone2, address);
                
            }
            dataGridView1.ClearSelection();

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    string filePath = openFileDialog.FileName;

                    
                    uploadedImage = Image.FromFile(filePath);
                    img.Image = uploadedImage;
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
                // Remove the selected row
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
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
            if (dob > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.");
                return 0;
            }
            
            int age = DateTime.Now.Year - dob.Year;
            
            if (dob > DateTime.Now.AddYears(-age)) age--;
            if(age == 0)
            {
                MessageBox.Show("Don't Play With Laptop Baby");
                return 0;
            }
            return age;
        }

       
    }
}
