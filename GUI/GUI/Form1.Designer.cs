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
            parkingcontainer = new FlowLayoutPanel();
            parkingbtn = new Button();
            cit = new Button();
            ceafa = new Button();
            coe = new Button();
            cics = new Button();
            pictureBox1 = new PictureBox();
            dashboardbtn = new Button();
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
            panelside.Controls.Add(parkingcontainer);
            panelside.Controls.Add(pictureBox1);
            panelside.Controls.Add(dashboardbtn);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 53);
            panelside.Name = "panelside";
            panelside.Size = new Size(179, 536);
            panelside.TabIndex = 0;
            panelside.Paint += panel1_Paint;
            // 
            // parkingcontainer
            // 
            parkingcontainer.Controls.Add(parkingbtn);
            parkingcontainer.Controls.Add(cit);
            parkingcontainer.Controls.Add(ceafa);
            parkingcontainer.Controls.Add(coe);
            parkingcontainer.Controls.Add(cics);
            parkingcontainer.Location = new Point(0, 209);
            parkingcontainer.Name = "parkingcontainer";
            parkingcontainer.Size = new Size(180, 45);
            parkingcontainer.TabIndex = 6;
            parkingcontainer.Paint += parkingcontainer_Paint_1;
            // 
            // parkingbtn
            // 
            parkingbtn.BackColor = Color.FromArgb(0, 192, 192);
            parkingbtn.BackgroundImageLayout = ImageLayout.Zoom;
            parkingbtn.FlatStyle = FlatStyle.Flat;
            parkingbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            parkingbtn.Image = (Image)resources.GetObject("parkingbtn.Image");
            parkingbtn.ImageAlign = ContentAlignment.MiddleLeft;
            parkingbtn.Location = new Point(3, 3);
            parkingbtn.Name = "parkingbtn";
            parkingbtn.Size = new Size(174, 40);
            parkingbtn.TabIndex = 1;
            parkingbtn.Text = "      PARKING";
            parkingbtn.UseVisualStyleBackColor = false;
            parkingbtn.Click += parkingbtn_Click;
            // 
            // cit
            // 
            cit.BackColor = Color.FromArgb(0, 192, 192);
            cit.BackgroundImageLayout = ImageLayout.Zoom;
            cit.FlatStyle = FlatStyle.Flat;
            cit.Image = (Image)resources.GetObject("cit.Image");
            cit.ImageAlign = ContentAlignment.MiddleLeft;
            cit.Location = new Point(3, 49);
            cit.Name = "cit";
            cit.Size = new Size(174, 37);
            cit.TabIndex = 5;
            cit.Text = "      CIT";
            cit.UseVisualStyleBackColor = false;
            cit.Click += cit_Click;
            // 
            // ceafa
            // 
            ceafa.BackColor = Color.FromArgb(0, 192, 192);
            ceafa.BackgroundImageLayout = ImageLayout.Zoom;
            ceafa.FlatStyle = FlatStyle.Flat;
            ceafa.Image = (Image)resources.GetObject("ceafa.Image");
            ceafa.ImageAlign = ContentAlignment.MiddleLeft;
            ceafa.Location = new Point(3, 92);
            ceafa.Name = "ceafa";
            ceafa.Size = new Size(174, 37);
            ceafa.TabIndex = 4;
            ceafa.Text = "      CEAFA";
            ceafa.UseVisualStyleBackColor = false;
            ceafa.Click += button3_Click;
            // 
            // coe
            // 
            coe.BackColor = Color.FromArgb(0, 192, 192);
            coe.BackgroundImageLayout = ImageLayout.Zoom;
            coe.FlatStyle = FlatStyle.Flat;
            coe.Image = (Image)resources.GetObject("coe.Image");
            coe.ImageAlign = ContentAlignment.MiddleLeft;
            coe.Location = new Point(3, 135);
            coe.Name = "coe";
            coe.Size = new Size(174, 37);
            coe.TabIndex = 3;
            coe.Text = "      COE";
            coe.UseVisualStyleBackColor = false;
            coe.Click += coe_Click;
            // 
            // cics
            // 
            cics.BackColor = Color.FromArgb(0, 192, 192);
            cics.BackgroundImageLayout = ImageLayout.Zoom;
            cics.FlatStyle = FlatStyle.Flat;
            cics.Image = (Image)resources.GetObject("cics.Image");
            cics.ImageAlign = ContentAlignment.MiddleLeft;
            cics.Location = new Point(3, 178);
            cics.Name = "cics";
            cics.Size = new Size(174, 37);
            cics.TabIndex = 2;
            cics.Text = "      CICS";
            cics.UseVisualStyleBackColor = false;
            cics.Click += cics_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dashboardbtn
            // 
            dashboardbtn.BackColor = Color.FromArgb(0, 192, 192);
            dashboardbtn.BackgroundImageLayout = ImageLayout.Zoom;
            dashboardbtn.FlatStyle = FlatStyle.Flat;
            dashboardbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbtn.Image = (Image)resources.GetObject("dashboardbtn.Image");
            dashboardbtn.ImageAlign = ContentAlignment.MiddleLeft;
            dashboardbtn.Location = new Point(3, 166);
            dashboardbtn.Name = "dashboardbtn";
            dashboardbtn.Size = new Size(174, 37);
            dashboardbtn.TabIndex = 0;
            dashboardbtn.Text = "    DASHBOARD";
            dashboardbtn.UseVisualStyleBackColor = false;
            dashboardbtn.Click += dashboardbtn_Click;
            // 
            // panelhead
            // 
            panelhead.BackColor = Color.Teal;
            panelhead.Controls.Add(label1);
            panelhead.Controls.Add(btnclose);
            panelhead.Dock = DockStyle.Top;
            panelhead.Location = new Point(0, 0);
            panelhead.Name = "panelhead";
            panelhead.Size = new Size(931, 53);
            panelhead.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(7, 6);
            label1.Name = "label1";
            label1.Size = new Size(197, 41);
            label1.TabIndex = 7;
            label1.Text = "ParkSense";
            // 
            // btnclose
            // 
            btnclose.BackColor = Color.Teal;
            btnclose.BackgroundImageLayout = ImageLayout.Zoom;
            btnclose.FlatStyle = FlatStyle.Flat;
            btnclose.ImageAlign = ContentAlignment.MiddleLeft;
            btnclose.Location = new Point(866, 0);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(53, 53);
            btnclose.TabIndex = 6;
            btnclose.Text = "X";
            btnclose.UseVisualStyleBackColor = false;
            btnclose.Click += button1_Click;
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(179, 53);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(752, 536);
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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(931, 589);
            Controls.Add(mainpanel);
            Controls.Add(panelside);
            Controls.Add(panelhead);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelside.ResumeLayout(false);
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
    }
}
