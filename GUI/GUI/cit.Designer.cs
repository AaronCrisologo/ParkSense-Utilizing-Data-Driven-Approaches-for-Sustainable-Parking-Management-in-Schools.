namespace GUI
{
    partial class cit
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
            slot10lbl = new Label();
            slot8lbl = new Label();
            slot7lbl = new Label();
            groupBox1 = new GroupBox();
            leavebtn = new Button();
            addbtn = new Button();
            yesrbtn = new RadioButton();
            label5 = new Label();
            vehicletypecombo = new ComboBox();
            label4 = new Label();
            vehicletxtbox = new TextBox();
            label3 = new Label();
            nametxtbox = new TextBox();
            label2 = new Label();
            slot6lbl = new Label();
            slot5lbl = new Label();
            slot4lbl = new Label();
            slot3lbl = new Label();
            pictureBox1 = new PictureBox();
            slot1lbl = new Label();
            slot9lbl = new Label();
            slot2lbl = new Label();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // slot10lbl
            // 
            slot10lbl.AutoSize = true;
            slot10lbl.BackColor = Color.Transparent;
            slot10lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot10lbl.Location = new Point(460, 110);
            slot10lbl.Name = "slot10lbl";
            slot10lbl.Size = new Size(0, 17);
            slot10lbl.TabIndex = 36;
            slot10lbl.Click += slot10lbl_Click;
            // 
            // slot8lbl
            // 
            slot8lbl.AutoSize = true;
            slot8lbl.BackColor = Color.Transparent;
            slot8lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot8lbl.Location = new Point(355, 340);
            slot8lbl.Name = "slot8lbl";
            slot8lbl.Size = new Size(0, 17);
            slot8lbl.TabIndex = 34;
            slot8lbl.Click += slot8lbl_Click;
            // 
            // slot7lbl
            // 
            slot7lbl.AutoSize = true;
            slot7lbl.BackColor = Color.Transparent;
            slot7lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot7lbl.Location = new Point(355, 110);
            slot7lbl.Name = "slot7lbl";
            slot7lbl.Size = new Size(0, 17);
            slot7lbl.TabIndex = 33;
            slot7lbl.Click += slot7lbl_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(leavebtn);
            groupBox1.Controls.Add(addbtn);
            groupBox1.Controls.Add(yesrbtn);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(vehicletypecombo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(vehicletxtbox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(nametxtbox);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(-1, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 533);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "CIT Department Enter Information";
            // 
            // leavebtn
            // 
            leavebtn.Location = new Point(31, 441);
            leavebtn.Name = "leavebtn";
            leavebtn.Size = new Size(143, 40);
            leavebtn.TabIndex = 10;
            leavebtn.Text = "LEAVE";
            leavebtn.UseVisualStyleBackColor = true;
            leavebtn.Click += leavebtn_Click;
            // 
            // addbtn
            // 
            addbtn.Location = new Point(31, 395);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(143, 40);
            addbtn.TabIndex = 9;
            addbtn.Text = "ADD";
            addbtn.UseVisualStyleBackColor = true;
            addbtn.Click += addbtn_Click;
            // 
            // yesrbtn
            // 
            yesrbtn.AutoSize = true;
            yesrbtn.Location = new Point(19, 317);
            yesrbtn.Name = "yesrbtn";
            yesrbtn.Size = new Size(51, 24);
            yesrbtn.TabIndex = 7;
            yesrbtn.TabStop = true;
            yesrbtn.Text = "Yes";
            yesrbtn.UseVisualStyleBackColor = true;
            yesrbtn.CheckedChanged += yesrbtn_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 294);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 6;
            label5.Text = "PWD";
            // 
            // vehicletypecombo
            // 
            vehicletypecombo.FormattingEnabled = true;
            vehicletypecombo.Items.AddRange(new object[] { "Car", "Motorcycle", "Bike", "E-Bike" });
            vehicletypecombo.Location = new Point(6, 245);
            vehicletypecombo.Name = "vehicletypecombo";
            vehicletypecombo.Size = new Size(203, 28);
            vehicletypecombo.TabIndex = 5;
            vehicletypecombo.SelectedIndexChanged += vehicletypecombo_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 222);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 4;
            label4.Text = "Vehicle Type";
            // 
            // vehicletxtbox
            // 
            vehicletxtbox.Location = new Point(6, 179);
            vehicletxtbox.Name = "vehicletxtbox";
            vehicletxtbox.Size = new Size(203, 27);
            vehicletxtbox.TabIndex = 3;
            vehicletxtbox.TextChanged += vehicletxtbox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 146);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 2;
            label3.Text = "Vehicle Number";
            // 
            // nametxtbox
            // 
            nametxtbox.Location = new Point(6, 100);
            nametxtbox.Name = "nametxtbox";
            nametxtbox.Size = new Size(203, 27);
            nametxtbox.TabIndex = 1;
            nametxtbox.TextChanged += nametxtbox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 70);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // slot6lbl
            // 
            slot6lbl.AutoSize = true;
            slot6lbl.BackColor = Color.Transparent;
            slot6lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot6lbl.Location = new Point(242, 340);
            slot6lbl.Name = "slot6lbl";
            slot6lbl.Size = new Size(0, 17);
            slot6lbl.TabIndex = 32;
            slot6lbl.Click += slot6lbl_Click;
            // 
            // slot5lbl
            // 
            slot5lbl.AutoSize = true;
            slot5lbl.BackColor = Color.Transparent;
            slot5lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot5lbl.Location = new Point(242, 110);
            slot5lbl.Name = "slot5lbl";
            slot5lbl.Size = new Size(0, 17);
            slot5lbl.TabIndex = 31;
            slot5lbl.Click += slot5lbl_Click;
            // 
            // slot4lbl
            // 
            slot4lbl.AutoSize = true;
            slot4lbl.BackColor = Color.Transparent;
            slot4lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot4lbl.Location = new Point(129, 340);
            slot4lbl.Name = "slot4lbl";
            slot4lbl.Size = new Size(0, 17);
            slot4lbl.TabIndex = 30;
            slot4lbl.Click += slot4lbl_Click;
            // 
            // slot3lbl
            // 
            slot3lbl.AutoSize = true;
            slot3lbl.BackColor = Color.Transparent;
            slot3lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot3lbl.Location = new Point(129, 110);
            slot3lbl.Name = "slot3lbl";
            slot3lbl.Size = new Size(0, 17);
            slot3lbl.TabIndex = 29;
            slot3lbl.Click += slot3lbl_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.next_parking;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(533, 537);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // slot1lbl
            // 
            slot1lbl.AutoSize = true;
            slot1lbl.BackColor = Color.Transparent;
            slot1lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot1lbl.Location = new Point(27, 110);
            slot1lbl.Name = "slot1lbl";
            slot1lbl.Size = new Size(0, 17);
            slot1lbl.TabIndex = 27;
            slot1lbl.Click += slot1lbl_Click;
            // 
            // slot9lbl
            // 
            slot9lbl.AutoSize = true;
            slot9lbl.BackColor = Color.Transparent;
            slot9lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot9lbl.Location = new Point(460, 340);
            slot9lbl.Name = "slot9lbl";
            slot9lbl.Size = new Size(0, 17);
            slot9lbl.TabIndex = 35;
            slot9lbl.Click += slot9lbl_Click;
            // 
            // slot2lbl
            // 
            slot2lbl.AutoSize = true;
            slot2lbl.BackColor = Color.Transparent;
            slot2lbl.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slot2lbl.Location = new Point(27, 340);
            slot2lbl.Name = "slot2lbl";
            slot2lbl.Size = new Size(0, 17);
            slot2lbl.TabIndex = 28;
            slot2lbl.Click += slot2lbl_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(531, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 536);
            panel1.TabIndex = 25;
            // 
            // cit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(752, 536);
            Controls.Add(slot9lbl);
            Controls.Add(slot1lbl);
            Controls.Add(slot2lbl);
            Controls.Add(slot10lbl);
            Controls.Add(slot8lbl);
            Controls.Add(slot7lbl);
            Controls.Add(slot6lbl);
            Controls.Add(slot5lbl);
            Controls.Add(slot4lbl);
            Controls.Add(slot3lbl);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "cit";
            Text = "cit";
            Load += cit_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label slot10lbl;
        private Label slot8lbl;
        private Label slot7lbl;
        private GroupBox groupBox1;
        private Button leavebtn;
        private Button addbtn;
        private RadioButton yesrbtn;
        private Label label5;
        private ComboBox vehicletypecombo;
        private Label label4;
        private TextBox vehicletxtbox;
        private Label label3;
        private TextBox nametxtbox;
        private Label label2;
        private Label slot6lbl;
        private Label slot5lbl;
        private Label slot4lbl;
        private Label slot3lbl;
        private PictureBox pictureBox1;
        private Label slot1lbl;
        private Label slot9lbl;
        private Label slot2lbl;
        private Panel panel1;
    }
}