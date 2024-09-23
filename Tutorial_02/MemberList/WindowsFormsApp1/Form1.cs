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
            string memberDetails = $"{index},{memberID}, {memberName}, {email} ,{phoneNo}";

            lbMemberList.Items.Add(memberDetails);

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
    }
}
