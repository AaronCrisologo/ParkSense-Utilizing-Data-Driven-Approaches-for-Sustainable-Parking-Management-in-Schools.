namespace GUI
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            groupBox1 = new GroupBox();
            loginbtn = new Button();
            passwordtxt = new TextBox();
            label2 = new Label();
            usernametxt = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            exitbtn = new Button();
            wow = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(0, 192, 192);
            groupBox1.Controls.Add(loginbtn);
            groupBox1.Controls.Add(passwordtxt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(usernametxt);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(37, 138);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(271, 249);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter credentials";
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(84, 188);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(105, 43);
            loginbtn.TabIndex = 5;
            loginbtn.Text = "LOGIN";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // passwordtxt
            // 
            passwordtxt.Location = new Point(14, 135);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(247, 27);
            passwordtxt.TabIndex = 4;
            passwordtxt.TextChanged += passwordtxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 112);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Password:";
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(101, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(128, 255, 255);
            linkLabel1.Location = new Point(51, 402);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(231, 20);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Don't have an account? Click here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // exitbtn
            // 
            exitbtn.BackColor = Color.FromArgb(0, 192, 192);
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Location = new Point(331, 0);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(20, 29);
            exitbtn.TabIndex = 8;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = false;
            exitbtn.Click += exitbtn_Click;
            // 
            // wow
            // 
            wow.AutoSize = true;
            wow.Location = new Point(284, 87);
            wow.Name = "wow";
            wow.Size = new Size(50, 20);
            wow.TabIndex = 9;
            wow.Text = "label3";
            wow.Click += wow_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(350, 450);
            Controls.Add(wow);
            Controls.Add(exitbtn);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            Load += login_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button loginbtn;
        private TextBox passwordtxt;
        private Label label2;
        private TextBox usernametxt;
        private Label label1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Button exitbtn;
        private Label wow;
    }
}