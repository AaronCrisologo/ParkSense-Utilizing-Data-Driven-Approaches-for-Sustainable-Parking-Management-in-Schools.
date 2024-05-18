namespace GUI
{
    partial class dashboard
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
            adminpriv = new GroupBox();
            change = new Button();
            ebike = new Label();
            bike = new Label();
            motor = new Label();
            car = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            cics = new Label();
            ceafa = new Label();
            cit = new Label();
            coe = new Label();
            total = new Label();
            cicsslot = new Label();
            ceafaslot = new Label();
            coeslot = new Label();
            citslot = new Label();
            adminpriv.SuspendLayout();
            SuspendLayout();
            // 
            // adminpriv
            // 
            adminpriv.Controls.Add(change);
            adminpriv.Controls.Add(ebike);
            adminpriv.Controls.Add(bike);
            adminpriv.Controls.Add(motor);
            adminpriv.Controls.Add(car);
            adminpriv.Controls.Add(label2);
            adminpriv.Controls.Add(label1);
            adminpriv.Controls.Add(textBox1);
            adminpriv.Controls.Add(comboBox1);
            adminpriv.Location = new Point(150, 347);
            adminpriv.Name = "adminpriv";
            adminpriv.Size = new Size(490, 177);
            adminpriv.TabIndex = 0;
            adminpriv.TabStop = false;
            adminpriv.Text = "Change Rates";
            adminpriv.Enter += adminpriv_Enter;
            // 
            // change
            // 
            change.Location = new Point(28, 83);
            change.Name = "change";
            change.Size = new Size(68, 34);
            change.TabIndex = 9;
            change.Text = "Apply";
            change.UseVisualStyleBackColor = true;
            change.Click += change_Click;
            // 
            // ebike
            // 
            ebike.AutoSize = true;
            ebike.Location = new Point(387, 140);
            ebike.Name = "ebike";
            ebike.Size = new Size(51, 20);
            ebike.TabIndex = 8;
            ebike.Text = "E-bike";
            ebike.Click += ebike_Click;
            // 
            // bike
            // 
            bike.AutoSize = true;
            bike.Location = new Point(387, 90);
            bike.Name = "bike";
            bike.Size = new Size(37, 20);
            bike.TabIndex = 7;
            bike.Text = "Bike";
            bike.Click += bike_Click;
            // 
            // motor
            // 
            motor.AutoSize = true;
            motor.Location = new Point(265, 140);
            motor.Name = "motor";
            motor.Size = new Size(50, 20);
            motor.TabIndex = 6;
            motor.Text = "Motor";
            motor.Click += motor_Click;
            // 
            // car
            // 
            car.AutoSize = true;
            car.Location = new Point(304, 90);
            car.Name = "car";
            car.Size = new Size(31, 20);
            car.TabIndex = 5;
            car.Text = "Car";
            car.Click += car_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 90);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 4;
            label2.Text = "Current rate per hour:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(215, 17);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 3;
            label1.Text = "Enter new fee:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(218, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Car", "Bike", "E-bike", "Motorcycle" });
            comboBox1.Location = new Point(28, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(173, 28);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cics
            // 
            cics.AutoSize = true;
            cics.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cics.Location = new Point(41, 55);
            cics.Name = "cics";
            cics.Size = new Size(59, 23);
            cics.TabIndex = 1;
            cics.Text = "label3";
            cics.Click += cics_Click;
            // 
            // ceafa
            // 
            ceafa.AutoSize = true;
            ceafa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ceafa.Location = new Point(41, 113);
            ceafa.Name = "ceafa";
            ceafa.Size = new Size(59, 23);
            ceafa.TabIndex = 2;
            ceafa.Text = "label3";
            ceafa.Click += ceafa_Click;
            // 
            // cit
            // 
            cit.AutoSize = true;
            cit.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cit.Location = new Point(41, 175);
            cit.Name = "cit";
            cit.Size = new Size(59, 23);
            cit.TabIndex = 3;
            cit.Text = "label3";
            cit.Click += cit_Click;
            // 
            // coe
            // 
            coe.AutoSize = true;
            coe.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coe.Location = new Point(41, 230);
            coe.Name = "coe";
            coe.Size = new Size(59, 23);
            coe.TabIndex = 4;
            coe.Text = "label3";
            coe.Click += coe_Click;
            // 
            // total
            // 
            total.AutoSize = true;
            total.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            total.Location = new Point(256, 270);
            total.Name = "total";
            total.Size = new Size(59, 23);
            total.TabIndex = 5;
            total.Text = "label3";
            total.Click += total_Click;
            // 
            // cicsslot
            // 
            cicsslot.AutoSize = true;
            cicsslot.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cicsslot.Location = new Point(415, 55);
            cicsslot.Name = "cicsslot";
            cicsslot.Size = new Size(59, 23);
            cicsslot.TabIndex = 6;
            cicsslot.Text = "label3";
            cicsslot.Click += cicsslot_Click;
            // 
            // ceafaslot
            // 
            ceafaslot.AutoSize = true;
            ceafaslot.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ceafaslot.Location = new Point(415, 175);
            ceafaslot.Name = "ceafaslot";
            ceafaslot.Size = new Size(59, 23);
            ceafaslot.TabIndex = 8;
            ceafaslot.Text = "label3";
            ceafaslot.Click += ceafaslot_Click;
            // 
            // coeslot
            // 
            coeslot.AutoSize = true;
            coeslot.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            coeslot.Location = new Point(415, 113);
            coeslot.Name = "coeslot";
            coeslot.Size = new Size(59, 23);
            coeslot.TabIndex = 9;
            coeslot.Text = "label3";
            // 
            // citslot
            // 
            citslot.AutoSize = true;
            citslot.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            citslot.Location = new Point(415, 230);
            citslot.Name = "citslot";
            citslot.Size = new Size(59, 23);
            citslot.TabIndex = 10;
            citslot.Text = "label3";
            citslot.Click += citslot_Click;
            // 
            // dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(752, 536);
            Controls.Add(citslot);
            Controls.Add(coeslot);
            Controls.Add(ceafaslot);
            Controls.Add(cicsslot);
            Controls.Add(total);
            Controls.Add(coe);
            Controls.Add(cit);
            Controls.Add(ceafa);
            Controls.Add(cics);
            Controls.Add(adminpriv);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboard";
            Text = "dashboard";
            Load += dashboard_Load;
            adminpriv.ResumeLayout(false);
            adminpriv.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox adminpriv;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label car;
        private Label label2;
        private Label ebike;
        private Label bike;
        private Label motor;
        private Button change;
        private Label cics;
        private Label ceafa;
        private Label cit;
        private Label coe;
        private Label total;
        private Label cicsslot;
        private Label ceafaslot;
        private Label coeslot;
        private Label citslot;
    }
}