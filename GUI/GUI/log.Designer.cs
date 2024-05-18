namespace GUI
{
    partial class log
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
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            datacics = new DataGridView();
            loadbtn = new Button();
            parkingslot = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            vehicletype = new DataGridViewTextBoxColumn();
            vehiclenumber = new DataGridViewTextBoxColumn();
            entry = new DataGridViewTextBoxColumn();
            exit = new DataGridViewTextBoxColumn();
            duration = new DataGridViewTextBoxColumn();
            totalcost = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)datacics).BeginInit();
            SuspendLayout();
            // 
            // datacics
            // 
            datacics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datacics.Columns.AddRange(new DataGridViewColumn[] { parkingslot, name, vehicletype, vehiclenumber, entry, exit, duration, totalcost, Department });
            datacics.Location = new Point(12, 12);
            datacics.Name = "datacics";
            datacics.RowHeadersWidth = 51;
            datacics.Size = new Size(728, 465);
            datacics.TabIndex = 0;
            datacics.CellContentClick += datacics_CellContentClick;
            // 
            // loadbtn
            // 
            loadbtn.Location = new Point(299, 483);
            loadbtn.Name = "loadbtn";
            loadbtn.Size = new Size(145, 41);
            loadbtn.TabIndex = 1;
            loadbtn.Text = "REFRESH LOGS";
            loadbtn.UseVisualStyleBackColor = true;
            loadbtn.Click += loadbtn_Click;
            // 
            // parkingslot
            // 
            parkingslot.HeaderText = "Parking Slot";
            parkingslot.MinimumWidth = 6;
            parkingslot.Name = "parkingslot";
            parkingslot.Width = 125;
            // 
            // name
            // 
            name.HeaderText = "Full Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // vehicletype
            // 
            vehicletype.HeaderText = "Vehicle Type";
            vehicletype.MinimumWidth = 6;
            vehicletype.Name = "vehicletype";
            vehicletype.Width = 125;
            // 
            // vehiclenumber
            // 
            vehiclenumber.HeaderText = "Vehicle Number";
            vehiclenumber.MinimumWidth = 6;
            vehiclenumber.Name = "vehiclenumber";
            vehiclenumber.Width = 125;
            // 
            // entry
            // 
            entry.HeaderText = "Entry Time";
            entry.MinimumWidth = 6;
            entry.Name = "entry";
            entry.Width = 125;
            // 
            // exit
            // 
            exit.HeaderText = "Exit Time";
            exit.MinimumWidth = 6;
            exit.Name = "exit";
            exit.Width = 125;
            // 
            // duration
            // 
            duration.HeaderText = "Duration";
            duration.MinimumWidth = 6;
            duration.Name = "duration";
            duration.Width = 125;
            // 
            // totalcost
            // 
            totalcost.HeaderText = "Total Cost";
            totalcost.MinimumWidth = 6;
            totalcost.Name = "totalcost";
            totalcost.Width = 125;
            // 
            // Department
            // 
            Department.HeaderText = "Department";
            Department.MinimumWidth = 6;
            Department.Name = "Department";
            Department.Width = 125;
            // 
            // log
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 536);
            Controls.Add(loadbtn);
            Controls.Add(datacics);
            FormBorderStyle = FormBorderStyle.None;
            Name = "log";
            Text = "log";
            Load += log_Load;
            ((System.ComponentModel.ISupportInitialize)datacics).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private DataGridView datacics;
        private Button loadbtn;
        private DataGridViewTextBoxColumn parkingslot;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn vehicletype;
        private DataGridViewTextBoxColumn vehiclenumber;
        private DataGridViewTextBoxColumn entry;
        private DataGridViewTextBoxColumn exit;
        private DataGridViewTextBoxColumn duration;
        private DataGridViewTextBoxColumn totalcost;
        private DataGridViewTextBoxColumn Department;
    }
}