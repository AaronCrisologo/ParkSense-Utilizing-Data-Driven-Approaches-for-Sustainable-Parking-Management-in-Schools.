namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelside = new Panel();
            ceafa = new Button();
            coe = new Button();
            cics = new Button();
            greet = new Label();
            logbtn = new Button();
            parkingcontainer = new FlowLayoutPanel();
            cit = new Button();
            pictureBox1 = new PictureBox();
            dashboardbtn = new Button();
            parkingbtn = new Button();
            logoutbtn = new Button();
            panelhead = new Panel();
            label1 = new Label();
            btnclose = new Button();
            mainpanel = new Panel();
            parkingtransition = new System.Windows.Forms.Timer(components);
            panelside.SuspendLayout();
            parkingcontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelhead.SuspendLayout();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = Color.FromArgb(0, 192, 192);
            panelside.Controls.Add(greet);
            panelside.Controls.Add(logbtn);
            panelside.Controls.Add(parkingcontainer);
            panelside.Controls.Add(pictureBox1);
            panelside.Controls.Add(dashboardbtn);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 66);
            panelside.Margin = new Padding(4);
            panelside.Name = "panelside";
            panelside.Size = new Size(224, 670);
            panelside.TabIndex = 0;
            panelside.Paint += panel1_Paint;
            // 
            // ceafa
            // 
            ceafa.BackColor = Color.FromArgb(0, 192, 192);
            ceafa.BackgroundImageLayout = ImageLayout.Zoom;
            ceafa.FlatAppearance.BorderSize = 0;
            ceafa.FlatStyle = FlatStyle.Flat;
            ceafa.Image = (Image)resources.GetObject("ceafa.Image");
            ceafa.ImageAlign = ContentAlignment.MiddleLeft;
            ceafa.Location = new Point(4, 116);
            ceafa.Margin = new Padding(4);
            ceafa.Name = "ceafa";
            ceafa.Size = new Size(218, 46);
            ceafa.TabIndex = 4;
            ceafa.Text = "      CEAFA";
            ceafa.UseVisualStyleBackColor = false;
            ceafa.Click += button3_Click;
            // 
            // coe
            // 
            coe.BackColor = Color.FromArgb(0, 192, 192);
            coe.BackgroundImageLayout = ImageLayout.Zoom;
            coe.FlatAppearance.BorderSize = 0;
            coe.FlatStyle = FlatStyle.Flat;
            coe.Image = (Image)resources.GetObject("coe.Image");
            coe.ImageAlign = ContentAlignment.MiddleLeft;
            coe.Location = new Point(4, 62);
            coe.Margin = new Padding(4);
            coe.Name = "coe";
            coe.Size = new Size(218, 46);
            coe.TabIndex = 3;
            coe.Text = "      COE";
            coe.UseVisualStyleBackColor = false;
            coe.Click += coe_Click;
            // 
            // cics
            // 
            cics.BackColor = Color.FromArgb(0, 192, 192);
            cics.BackgroundImageLayout = ImageLayout.Zoom;
            cics.FlatAppearance.BorderSize = 0;
            cics.FlatStyle = FlatStyle.Flat;
            cics.Image = (Image)resources.GetObject("cics.Image");
            cics.ImageAlign = ContentAlignment.MiddleLeft;
            cics.Location = new Point(4, 224);
            cics.Margin = new Padding(4);
            cics.Name = "cics";
            cics.Size = new Size(218, 46);
            cics.TabIndex = 2;
            cics.Text = "      CICS";
            cics.UseVisualStyleBackColor = false;
            cics.Click += cics_Click;
            // 
            // greet
            // 
            greet.AutoSize = true;
            greet.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            greet.Location = new Point(9, 25);
            greet.Margin = new Padding(4, 0, 4, 0);
            greet.Name = "greet";
            greet.Size = new Size(0, 32);
            greet.TabIndex = 8;
            greet.Click += greet_Click;
            // 
            // logbtn
            // 
            logbtn.BackColor = Color.FromArgb(0, 192, 192);
            logbtn.BackgroundImageLayout = ImageLayout.Zoom;
            logbtn.FlatAppearance.BorderSize = 0;
            logbtn.FlatStyle = FlatStyle.Flat;
            logbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logbtn.Image = (Image)resources.GetObject("logbtn.Image");
            logbtn.ImageAlign = ContentAlignment.MiddleLeft;
            logbtn.Location = new Point(2, 327);
            logbtn.Margin = new Padding(4);
            logbtn.Name = "logbtn";
            logbtn.Size = new Size(218, 61);
            logbtn.TabIndex = 7;
            logbtn.Text = "   LOG";
            logbtn.UseVisualStyleBackColor = false;
            logbtn.Click += button1_Click_1;
            // 
            // parkingcontainer
            // 
            parkingcontainer.Controls.Add(parkingbtn);
            parkingcontainer.Controls.Add(coe);
            parkingcontainer.Controls.Add(ceafa);
            parkingcontainer.Controls.Add(cit);
            parkingcontainer.Controls.Add(cics);
            parkingcontainer.Location = new Point(2, 405);
            parkingcontainer.Margin = new Padding(4);
            parkingcontainer.Name = "parkingcontainer";
            parkingcontainer.Size = new Size(225, 66);
            parkingcontainer.TabIndex = 6;
            parkingcontainer.Paint += parkingcontainer_Paint_1;
            // 
            // cit
            // 
            cit.BackColor = Color.FromArgb(0, 192, 192);
            cit.BackgroundImageLayout = ImageLayout.Zoom;
            cit.FlatAppearance.BorderSize = 0;
            cit.FlatStyle = FlatStyle.Flat;
            cit.Image = (Image)resources.GetObject("cit.Image");
            cit.ImageAlign = ContentAlignment.MiddleLeft;
            cit.Location = new Point(4, 170);
            cit.Margin = new Padding(4);
            cit.Name = "cit";
            cit.Size = new Size(218, 46);
            cit.TabIndex = 5;
            cit.Text = "      CIT";
            cit.UseVisualStyleBackColor = false;
            cit.Click += cit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 25);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(222, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dashboardbtn
            // 
            dashboardbtn.BackColor = Color.FromArgb(0, 192, 192);
            dashboardbtn.BackgroundImageLayout = ImageLayout.Zoom;
            dashboardbtn.FlatAppearance.BorderSize = 0;
            dashboardbtn.FlatStyle = FlatStyle.Flat;
            dashboardbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbtn.Image = (Image)resources.GetObject("dashboardbtn.Image");
            dashboardbtn.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardbtn.Location = new Point(6, 248);
            dashboardbtn.Margin = new Padding(4);
            dashboardbtn.Name = "dashboardbtn";
            dashboardbtn.Size = new Size(218, 61);
            dashboardbtn.TabIndex = 0;
            dashboardbtn.Text = "    DASHBOARD";
            dashboardbtn.UseVisualStyleBackColor = false;
            dashboardbtn.Click += dashboardbtn_Click;
            // 
            // parkingbtn
            // 
            parkingbtn.BackColor = Color.FromArgb(0, 192, 192);
            parkingbtn.BackgroundImageLayout = ImageLayout.Zoom;
            parkingbtn.FlatAppearance.BorderSize = 0;
            parkingbtn.FlatStyle = FlatStyle.Flat;
            parkingbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            parkingbtn.Image = (Image)resources.GetObject("parkingbtn.Image");
            parkingbtn.ImageAlign = ContentAlignment.MiddleLeft;
            parkingbtn.Location = new Point(4, 4);
            parkingbtn.Margin = new Padding(4);
            parkingbtn.Name = "parkingbtn";
            parkingbtn.Size = new Size(218, 50);
            parkingbtn.TabIndex = 1;
            parkingbtn.Text = "      PARKING";
            parkingbtn.UseVisualStyleBackColor = false;
            parkingbtn.Click += parkingbtn_Click;
            // 
            // logoutbtn
            // 
            logoutbtn.BackColor = Color.Teal;
            logoutbtn.BackgroundImageLayout = ImageLayout.Zoom;
            logoutbtn.FlatAppearance.BorderSize = 0;
            logoutbtn.FlatStyle = FlatStyle.Flat;
            logoutbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutbtn.ImageAlign = ContentAlignment.MiddleLeft;
            logoutbtn.Location = new Point(946, 11);
            logoutbtn.Margin = new Padding(4);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(144, 42);
            logoutbtn.TabIndex = 9;
            logoutbtn.Text = "LOG OUT";
            logoutbtn.UseVisualStyleBackColor = false;
            logoutbtn.Click += logoutbtn_Click;
            // 
            // panelhead
            // 
            panelhead.BackColor = Color.Teal;
            panelhead.Controls.Add(logoutbtn);
            panelhead.Controls.Add(label1);
            panelhead.Controls.Add(btnclose);
            panelhead.Dock = DockStyle.Top;
            panelhead.Location = new Point(0, 0);
            panelhead.Margin = new Padding(4);
            panelhead.Name = "panelhead";
            panelhead.Size = new Size(1164, 66);
            panelhead.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(231, 48);
            label1.TabIndex = 7;
            label1.Text = "ParkSense";
            // 
            // btnclose
            // 
            btnclose.BackColor = Color.Teal;
            btnclose.BackgroundImageLayout = ImageLayout.Zoom;
            btnclose.FlatAppearance.BorderSize = 0;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.ImageAlign = ContentAlignment.MiddleLeft;
            btnclose.Location = new Point(1098, 0);
            btnclose.Margin = new Padding(4);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(66, 66);
            btnclose.TabIndex = 6;
            btnclose.Text = "X";
            btnclose.UseVisualStyleBackColor = false;
            btnclose.Click += button1_Click;
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(224, 66);
            mainpanel.Margin = new Padding(4);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(940, 670);
            mainpanel.TabIndex = 2;
            mainpanel.Paint += mainpanel_Paint;
            // 
            // parkingtransition
            // 
            parkingtransition.Enabled = true;
            parkingtransition.Interval = 10;
            parkingtransition.Tick += parkingtransition_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1164, 736);
            Controls.Add(mainpanel);
            Controls.Add(panelside);
            Controls.Add(panelhead);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelside.ResumeLayout(false);
            panelside.PerformLayout();
            parkingcontainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelhead.ResumeLayout(false);
            panelhead.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelside;
        private Panel panelhead;
        private Panel mainpanel;
        private Button dashboardbtn;
        private PictureBox pictureBox1;
        private Button btnclose;
        private System.Windows.Forms.Timer parkingtransition;
        private Button parkingbtn;
        private Button cit;
        private Button ceafa;
        private Button coe;
        private Button cics;
        private FlowLayoutPanel parkingcontainer;
        private Label label1;
        private Button logbtn;
        private Label greet;
        private Button logoutbtn;
    }
}
