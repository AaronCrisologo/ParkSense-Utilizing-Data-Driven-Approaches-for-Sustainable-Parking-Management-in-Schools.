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
    public partial class login : Form
    {
        private void login_Load(object sender, EventArgs e)
        {
            passwordtxt.PasswordChar = '*';
           
        }
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";
        public login()
        {
            InitializeComponent();
        }
        accounts acc = new accounts();

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }
        string realpass = "";
        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {
            passwordtxt.SelectionStart = passwordtxt.Text.Length;
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(usernametxt.Text) || string.IsNullOrEmpty(passwordtxt.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            realpass = passwordtxt.Text;
            wow.Text = realpass;

            bool check = acc.CheckCredentials(usernametxt.Text, passwordtxt.Text);
            if (check)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form = new Form1(usernametxt.Text);
                dashboard dash = new dashboard(usernametxt.Text);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new register().Show();
            this.Close();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wow_Click(object sender, EventArgs e)
        {

        }
    }
}
