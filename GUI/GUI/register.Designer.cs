namespace GUI
{
    partial class register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            groupBox1 = new GroupBox();
            createbtn = new Button();
            passwordtxt = new TextBox();
            label2 = new Label();
            usernametxt = new TextBox();
            label1 = new Label();
            exitbtn = new Button();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            cnfrmpass = new TextBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(0, 192, 192);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cnfrmpass);
            groupBox1.Controls.Add(createbtn);
            groupBox1.Controls.Add(passwordtxt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(usernametxt);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(32, 152);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(271, 266);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter credentials";
            // 
            // createbtn
            // 
            createbtn.Location = new Point(69, 217);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(139, 43);
            createbtn.TabIndex = 5;
            createbtn.Text = "Register Account";
            createbtn.UseVisualStyleBackColor = true;
            createbtn.Click += createbtn_Click;
            // 
            // passwordtxt
            // 
            passwordtxt.Location = new Point(10, 111);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(247, 27);
            passwordtxt.TabIndex = 4;
            passwordtxt.TextChanged += passwordtxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 88);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Password:";
            label2.Click += label2_Click;
            // 
            // usernametxt
            // 
            usernametxt.Location = new Point(14, 58);
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(247, 27);
            usernametxt.TabIndex = 1;
            usernametxt.TextChanged += usernametxt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // exitbtn
            // 
            exitbtn.BackColor = Color.FromArgb(0, 192, 192);
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Location = new Point(330, 0);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(20, 29);
            exitbtn.TabIndex = 12;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = false;
            exitbtn.Click += exitbtn_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Teal;
            linkLabel1.LinkColor = Color.FromArgb(128, 255, 255);
            linkLabel1.Location = new Point(42, 421);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(251, 20);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Already have an account? Login now";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(101, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // cnfrmpass
            // 
            cnfrmpass.AcceptsReturn = true;
            cnfrmpass.Location = new Point(10, 159);
            cnfrmpass.Name = "cnfrmpass";
            cnfrmpass.Size = new Size(247, 27);
            cnfrmpass.TabIndex = 6;
            cnfrmpass.TextChanged += cnfrmpass_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 136);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 7;
            label3.Text = "Confirm Password:";
            label3.Click += label3_Click;
            // 
            // register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(350, 450);
            Controls.Add(groupBox1);
            Controls.Add(exitbtn);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "register";
            Load += register_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button createbtn;
        private TextBox passwordtxt;
        private Label label2;
        private TextBox usernametxt;
        private Label label1;
        private Button exitbtn;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private Label label3;
        private TextBox cnfrmpass;
    }
}