
namespace GUI
{
    public partial class Form1 : Form
    {
        private string user;
        public Form1(string pass)
        {
            InitializeComponent();
            user = pass;

        }
        bool parkingExpand = true;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new ceafa());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            greet.Text = $"Welcome, {user}";
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            loadform(new dashboard(user));
        }

        private void cics_Click(object sender, EventArgs e)
        {
            loadform(new cics());
        }

        private void coe_Click(object sender, EventArgs e)
        {
            loadform(new coe());
        }

        private void cit_Click(object sender, EventArgs e)
        {
            loadform(new cit());
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void parkingcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void parkingbtn_Click(object sender, EventArgs e)
        {
            parkingtransition.Start();

        }

        private void parkingcontainer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void parkingtransition_Tick(object sender, EventArgs e)
        {
            if (parkingExpand == false)
            {
                parkingcontainer.Height += 10;
                if (parkingcontainer.Height >= 250)
                {
                    parkingtransition.Stop();
                    parkingExpand = true;
                }
            }
            else
            {
                parkingcontainer.Height -= 10;
                if (parkingcontainer.Height<= 50)
                {
                    parkingtransition.Stop();
                    parkingExpand = false;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadform(new log());
        }

        private void greet_Click(object sender, EventArgs e)
        {

        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Close();
            user = "";
        }
    }
}
