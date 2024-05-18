using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class register : Form
    {
        accounts acc = new accounts();
        private void register_Load(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
            cnfrmpass.PasswordChar = '*';
        }
        public register()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            passwordtxt.SelectionStart = passwordtxt.Text.Length;
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usernametxt.Text) || string.IsNullOrEmpty(passwordtxt.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (passwordtxt.Text != cnfrmpass.Text)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            bool check = acc.RegisterUser(usernametxt.Text, passwordtxt.Text);
            if (check)
            {
                MessageBox.Show("Account created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form = new Form1(usernametxt.Text);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Account registration failed!", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new login().Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cnfrmpass_TextChanged(object sender, EventArgs e)
        {
            cnfrmpass.SelectionStart = cnfrmpass.Text.Length;
        }
        
    }
}
