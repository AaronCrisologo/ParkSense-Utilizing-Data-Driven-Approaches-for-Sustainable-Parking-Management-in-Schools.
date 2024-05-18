using ParkingManagementSystem;
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
    public partial class cit : Form
    {
        public cit()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";
        ParkingLot parking = new ParkingLot(10, connectionString);
        PDFReceiptGenerator pdf = new PDFReceiptGenerator();
        private void cit_Load(object sender, EventArgs e)
        {
            caller();
        }

        public void slot1()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(1, "cit");
            if (status == "Available")
            {
                slot1lbl.Text = "Available";
                slot1lbl.ForeColor = Color.Green;
                slot1lbl.AutoSize = true;
                slot1lbl.Width = 200;
                slot1lbl.Height = 100;
            }
            else
            {
                slot1lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }
        }
        public void slot2()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(2, "cit");
            if (status == "Available")
            {
                slot2lbl.Text = "Available";
                slot2lbl.ForeColor = Color.Green;
                slot2lbl.AutoSize = true;
                slot2lbl.Width = 200;
                slot1lbl.Height = 100;
            }
            else
            {
                slot2lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }
        public void slot3()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(3, "cit");
            if (status == "Available")
            {
                slot3lbl.Text = "Available";
                slot3lbl.ForeColor = Color.Green;
                slot3lbl.AutoSize = true;
                slot3lbl.Width = 200;
                slot3lbl.Height = 100;
            }
            else
            {
                slot3lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }
        public void slot4()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(4, "cit");
            if (status == "Available")
            {
                slot4lbl.Text = "Available";
                slot4lbl.ForeColor = Color.Green;
                slot4lbl.AutoSize = true;
                slot4lbl.Width = 200;
                slot4lbl.Height = 100;
            }
            else
            {
                slot4lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }
        public void slot5()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(5, "cit");
            if (status == "Available")
            {
                slot5lbl.Text = "Available";
                slot5lbl.ForeColor = Color.Green;
                slot5lbl.AutoSize = true;
                slot5lbl.Width = 200;
                slot5lbl.Height = 100;
            }
            else
            {
                slot5lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void slot6()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(6, "cit");
            if (status == "Available")
            {
                slot6lbl.Text = "Available";
                slot6lbl.ForeColor = Color.Green;
                slot6lbl.AutoSize = true;
                slot6lbl.Width = 200;
                slot6lbl.Height = 100;
            }
            else
            {
                slot6lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void slot7()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(7, "cit");
            if (status == "Available")
            {
                slot7lbl.Text = "Available";
                slot7lbl.ForeColor = Color.Green;
                slot7lbl.AutoSize = true;
                slot7lbl.Width = 200;
                slot7lbl.Height = 100;
            }
            else
            {
                slot7lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void slot8()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(8, "cit");
            if (status == "Available")
            {
                slot8lbl.Text = "Available";
                slot8lbl.ForeColor = Color.Green;
                slot8lbl.AutoSize = true;
                slot8lbl.Width = 200;
                slot8lbl.Height = 100;
            }
            else
            {
                slot8lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void slot9()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(9, "cit");
            if (status == "Available")
            {
                slot9lbl.Text = "Available";
                slot9lbl.ForeColor = Color.Green;
                slot9lbl.AutoSize = true;
                slot9lbl.Width = 200;
                slot9lbl.Height = 100;
            }
            else
            {
                slot9lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void slot10()
        {
            (string status, string vehiclenumber, string name) = parking.GetSlotStatus(10, "cit");
            if (status == "Available")
            {
                slot10lbl.Text = "Available";
                slot10lbl.ForeColor = Color.Green;
                slot10lbl.AutoSize = true;
                slot10lbl.Width = 200;
                slot10lbl.Height = 100;
            }
            else
            {
                slot10lbl.Text = $"Driver: {name}\n Vehicle Number:\n{vehiclenumber}\n\n {status}";

            }

        }

        public void erase()
        {
            nametxtbox.Text = "";
            vehicletxtbox.Text = "";
            vehicletypecombo.Text = "";
            yesrbtn.Checked = false;

        }
        public void caller()
        {
            slot1();
            slot2();
            slot3();
            slot4();
            slot5();
            slot6();
            slot7();
            slot8();
            slot9();
            slot10();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicletxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void vehicletypecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yesrbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nametxtbox.Text) ||
               string.IsNullOrEmpty(vehicletxtbox.Text) ||
               vehicletypecombo.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            else
            {


                bool right;
                if (yesrbtn.Checked == true)
                {
                    right = parking.ParkVehicle(nametxtbox.Text, vehicletypecombo.SelectedItem.ToString(), vehicletxtbox.Text, "yes", "cit");
                }
                else
                {
                    right = parking.ParkVehicle(nametxtbox.Text, vehicletypecombo.SelectedItem.ToString(), vehicletxtbox.Text, "no", "cit");
                }

                if (right)
                {
                    erase();
                    MessageBox.Show("Car parked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Parking is full.", "Try again later", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    erase();
                }
            }

            caller();

        }

        private void leavebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vehicletxtbox.Text))
            {
                MessageBox.Show("Please enter Vehicle number.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
            else
            {
                bool might = parking.LeaveParking(vehicletxtbox.Text, "cit");
                if (might)
                {
                    MessageBox.Show("Car has left parking.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string pdfFilePath1 = $@"C:\Users\Nielle\Documents\Programming shit\C#\WOW\WOW\Receipts\{vehicletxtbox.Text}.pdf";
                    string pdfViewerPath = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
                    bool open = pdf.OpenPDF(pdfFilePath1, pdfViewerPath);
                    if (!open)
                    {
                        MessageBox.Show("Receipt can't be found or does not exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    }
                    erase();
                }
                else
                {
                    MessageBox.Show("Car has already left or does not exit.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                }

            }
            caller();
        }

        private void slot1lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot2lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot3lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot4lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot5lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot6lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot7lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot8lbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void slot9lbl_Click(object sender, EventArgs e)
        {

        }

        private void slot10lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
