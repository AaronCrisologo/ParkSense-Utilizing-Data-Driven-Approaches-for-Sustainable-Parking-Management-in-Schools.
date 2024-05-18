using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ParkingManagementSystem;



namespace GUI
{
    public partial class dashboard : Form
    {
        private string user;
        ParkingLot parking = new ParkingLot(10, connectionString);
        public static string connectionString = "server=localhost;database=parkinglot1;uid=root;pwd=password;";
        CostCalculator calcu = new CostCalculator(connectionString);



        

        public void changefee()
        {
            int num;
            if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(textBox1.Text, out num))
            {
                MessageBox.Show("Invalid input for number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool right = parking.valueoverride(connectionString, comboBox1.SelectedItem.ToString(), num);
                if (right)
                {
                    MessageBox.Show("You have successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Rate was not changed", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }


        }


        public dashboard(string pass)
        {
            InitializeComponent();
            user = pass;
            double tcics = calcu.CalculateTotalCostForDepartment("cics", connectionString);
            double tcoe = calcu.CalculateTotalCostForDepartment("coe", connectionString);
            double tceafa = calcu.CalculateTotalCostForDepartment("ceafa", connectionString);
            double tcit = calcu.CalculateTotalCostForDepartment("cit", connectionString);
            double total1 = tcics + tcoe + tceafa + tcit;

            cics.Text = $"CICS Department Total Revenue: \n      {tcics:N2} PHP";
            coe.Text = $"COE Department Total Revenue: \n       {tcoe:N2} PHP";
            cit.Text = $"CIT Department Total Revenue: \n        {tcit:N2} PHP";
            ceafa.Text = $"CEAFA Department Total Revenue: \n     {tceafa:N2} PHP";
            total.Text = $"Total Revenue: \n {total1:N2} PHP";

            display();




        }

        public void display()
        {

            string car1 = parking.GetVehicleFeeAsString("car");
            car.Text = $"Car: {car1}";

            string motor1 = parking.GetVehicleFeeAsString("motorcycle");
            motor.Text = $"Motorcycle: {motor1}";

            string bike1 = parking.GetVehicleFeeAsString("bike");
            bike.Text = $"Bike: {bike1}";

            string ebike1 = parking.GetVehicleFeeAsString("e-bike");
            ebike.Text = $"E-Bike: {ebike1}";

            int cicn = parking.GetAvailableSlotsCount("cics");
            cicsslot.Text = $"Available slots in CICS Department: {cicn}";

            int coen = parking.GetAvailableSlotsCount("coe");
            coeslot.Text = $"Available slots in COE Department: {coen}";

            int ceafan = parking.GetAvailableSlotsCount("ceafa");
            ceafaslot.Text = $"Available slots in CEAFA Department: {ceafan}";

            int citn = parking.GetAvailableSlotsCount("cit");
            citslot.Text = $"Available slots in CIT Department: {citn}";

        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            if (user == "admin")
            {
                adminpriv.Visible = true;
                
            }
            else
            {
                adminpriv.Visible=false;
            }
            display();
        }

        private void adminpriv_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void car_Click(object sender, EventArgs e)
        {

        }

        private void motor_Click(object sender, EventArgs e)
        {

        }

        private void bike_Click(object sender, EventArgs e)
        {

        }

        private void ebike_Click(object sender, EventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)
        {
            changefee();
            display();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void money_Click(object sender, EventArgs e)
        {

        }

        private void cics_Click(object sender, EventArgs e)
        {

        }

        private void ceafa_Click(object sender, EventArgs e)
        {

        }

        private void cit_Click(object sender, EventArgs e)
        {

        }

        private void coe_Click(object sender, EventArgs e)
        {

        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void cicsslot_Click(object sender, EventArgs e)
        {

        }

        private void ceafaslot_Click(object sender, EventArgs e)
        {

        }

        private void citslot_Click(object sender, EventArgs e)
        {

        }
    }
}
