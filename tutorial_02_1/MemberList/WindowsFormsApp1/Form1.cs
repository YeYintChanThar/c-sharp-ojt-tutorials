using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int index =0;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Underline);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
          private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string memberName = txtName.Text;
            string email = txtEmail.Text;
            string phoneNo = txtPhone.Text;
            

            if (string.IsNullOrWhiteSpace(memberName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNo))
            {
                MessageBox.Show("Please fill in all fields.");

                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }
            if (!IsValidPhone(phoneNo))
            {
                MessageBox.Show("Please enter a valid phone Number.");
                return;
            }

            index += 1;
            string memberID = $"MC-{index:D4}";
            dataGridView1.Rows.Add(memberID, memberName, email, phoneNo);

            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return email != null && regex.IsMatch(email);
        }
        private bool IsValidPhone(string phoneNo)
        {
            Regex regex = new Regex(@"^[\d()+-]+$");
            return phoneNo != null && regex.IsMatch(phoneNo);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
