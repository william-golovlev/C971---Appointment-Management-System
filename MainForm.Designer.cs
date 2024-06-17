namespace Appointment_Management_System
{
    partial class MainForm
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
            this.MainFormTitle = new System.Windows.Forms.Label();
            this.OtherControls = new System.Windows.Forms.GroupBox();
            this.ReportsBtn = new System.Windows.Forms.Button();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.AptsGroupBox = new System.Windows.Forms.GroupBox();
            this.ShowAllApts = new System.Windows.Forms.Button();
            this.DateSelect = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.appointmentDataGrid = new System.Windows.Forms.DataGridView();
            this.AddApt = new System.Windows.Forms.Button();
            this.UpdateApt = new System.Windows.Forms.Button();
            this.DeleteApt = new System.Windows.Forms.Button();
            this.CustomersGroupBox = new System.Windows.Forms.GroupBox();
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.DeleteCust = new System.Windows.Forms.Button();
            this.UpdateCust = new System.Windows.Forms.Button();
            this.AddCust = new System.Windows.Forms.Button();
            this.OtherControls.SuspendLayout();
            this.AptsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).BeginInit();
            this.CustomersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainFormTitle
            // 
            this.MainFormTitle.AutoSize = true;
            this.MainFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainFormTitle.Location = new System.Drawing.Point(484, 9);
            this.MainFormTitle.Name = "MainFormTitle";
            this.MainFormTitle.Size = new System.Drawing.Size(106, 25);
            this.MainFormTitle.TabIndex = 0;
            this.MainFormTitle.Text = "Main Page";
            // 
            // OtherControls
            // 
            this.OtherControls.Controls.Add(this.ReportsBtn);
            this.OtherControls.Controls.Add(this.LogoutBtn);
            this.OtherControls.Location = new System.Drawing.Point(908, 281);
            this.OtherControls.Name = "OtherControls";
            this.OtherControls.Size = new System.Drawing.Size(286, 254);
            this.OtherControls.TabIndex = 4;
            this.OtherControls.TabStop = false;
            this.OtherControls.Text = "Other";
            // 
            // ReportsBtn
            // 
            this.ReportsBtn.Location = new System.Drawing.Point(50, 64);
            this.ReportsBtn.Name = "ReportsBtn";
            this.ReportsBtn.Size = new System.Drawing.Size(188, 51);
            this.ReportsBtn.TabIndex = 6;
            this.ReportsBtn.Text = "Reports";
            this.ReportsBtn.UseVisualStyleBackColor = true;
            this.ReportsBtn.Click += new System.EventHandler(this.ReportsBtn_Click);
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(50, 137);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(188, 53);
            this.LogoutBtn.TabIndex = 7;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // AptsGroupBox
            // 
            this.AptsGroupBox.Controls.Add(this.ShowAllApts);
            this.AptsGroupBox.Controls.Add(this.DateSelect);
            this.AptsGroupBox.Controls.Add(this.monthCalendar1);
            this.AptsGroupBox.Controls.Add(this.appointmentDataGrid);
            this.AptsGroupBox.Controls.Add(this.AddApt);
            this.AptsGroupBox.Controls.Add(this.UpdateApt);
            this.AptsGroupBox.Controls.Add(this.DeleteApt);
            this.AptsGroupBox.Location = new System.Drawing.Point(17, 37);
            this.AptsGroupBox.Name = "AptsGroupBox";
            this.AptsGroupBox.Size = new System.Drawing.Size(1193, 238);
            this.AptsGroupBox.TabIndex = 0;
            this.AptsGroupBox.TabStop = false;
            this.AptsGroupBox.Text = "Appointments";
            // 
            // ShowAllApts
            // 
            this.ShowAllApts.Location = new System.Drawing.Point(1025, 210);
            this.ShowAllApts.Name = "ShowAllApts";
            this.ShowAllApts.Size = new System.Drawing.Size(128, 26);
            this.ShowAllApts.TabIndex = 7;
            this.ShowAllApts.Text = "Show All";
            this.ShowAllApts.UseVisualStyleBackColor = true;
            this.ShowAllApts.Click += new System.EventHandler(this.ShowAllApts_Click);
            // 
            // DateSelect
            // 
            this.DateSelect.Location = new System.Drawing.Point(891, 209);
            this.DateSelect.Name = "DateSelect";
            this.DateSelect.Size = new System.Drawing.Size(128, 26);
            this.DateSelect.TabIndex = 6;
            this.DateSelect.Text = "Search for Date:";
            this.DateSelect.UseVisualStyleBackColor = true;
            this.DateSelect.Click += new System.EventHandler(this.DateSelect_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(891, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // appointmentDataGrid
            // 
            this.appointmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGrid.Location = new System.Drawing.Point(0, 21);
            this.appointmentDataGrid.Name = "appointmentDataGrid";
            this.appointmentDataGrid.RowHeadersWidth = 51;
            this.appointmentDataGrid.RowTemplate.Height = 24;
            this.appointmentDataGrid.Size = new System.Drawing.Size(879, 182);
            this.appointmentDataGrid.TabIndex = 5;
            // 
            // AddApt
            // 
            this.AddApt.Location = new System.Drawing.Point(48, 209);
            this.AddApt.Name = "AddApt";
            this.AddApt.Size = new System.Drawing.Size(75, 29);
            this.AddApt.TabIndex = 0;
            this.AddApt.Text = "Add";
            this.AddApt.UseVisualStyleBackColor = true;
            this.AddApt.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateApt
            // 
            this.UpdateApt.Location = new System.Drawing.Point(129, 209);
            this.UpdateApt.Name = "UpdateApt";
            this.UpdateApt.Size = new System.Drawing.Size(75, 29);
            this.UpdateApt.TabIndex = 1;
            this.UpdateApt.Text = "Update";
            this.UpdateApt.UseVisualStyleBackColor = true;
            this.UpdateApt.Click += new System.EventHandler(this.UpdateApt_Click);
            // 
            // DeleteApt
            // 
            this.DeleteApt.Location = new System.Drawing.Point(210, 209);
            this.DeleteApt.Name = "DeleteApt";
            this.DeleteApt.Size = new System.Drawing.Size(75, 29);
            this.DeleteApt.TabIndex = 2;
            this.DeleteApt.Text = "Delete";
            this.DeleteApt.UseVisualStyleBackColor = true;
            this.DeleteApt.Click += new System.EventHandler(this.DeleteApt_Click);
            // 
            // CustomersGroupBox
            // 
            this.CustomersGroupBox.Controls.Add(this.customerDataGrid);
            this.CustomersGroupBox.Controls.Add(this.DeleteCust);
            this.CustomersGroupBox.Controls.Add(this.UpdateCust);
            this.CustomersGroupBox.Controls.Add(this.AddCust);
            this.CustomersGroupBox.Location = new System.Drawing.Point(17, 281);
            this.CustomersGroupBox.Name = "CustomersGroupBox";
            this.CustomersGroupBox.Size = new System.Drawing.Size(879, 254);
            this.CustomersGroupBox.TabIndex = 0;
            this.CustomersGroupBox.TabStop = false;
            this.CustomersGroupBox.Text = "Customers";
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(0, 21);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.RowHeadersWidth = 51;
            this.customerDataGrid.RowTemplate.Height = 24;
            this.customerDataGrid.Size = new System.Drawing.Size(879, 197);
            this.customerDataGrid.TabIndex = 5;
            // 
            // DeleteCust
            // 
            this.DeleteCust.Location = new System.Drawing.Point(210, 224);
            this.DeleteCust.Name = "DeleteCust";
            this.DeleteCust.Size = new System.Drawing.Size(75, 29);
            this.DeleteCust.TabIndex = 5;
            this.DeleteCust.Text = "Delete";
            this.DeleteCust.UseVisualStyleBackColor = true;
            this.DeleteCust.Click += new System.EventHandler(this.DeleteCust_Click);
            // 
            // UpdateCust
            // 
            this.UpdateCust.Location = new System.Drawing.Point(129, 224);
            this.UpdateCust.Name = "UpdateCust";
            this.UpdateCust.Size = new System.Drawing.Size(75, 29);
            this.UpdateCust.TabIndex = 4;
            this.UpdateCust.Text = "Update";
            this.UpdateCust.UseVisualStyleBackColor = true;
            this.UpdateCust.Click += new System.EventHandler(this.UpdateCust_Click);
            // 
            // AddCust
            // 
            this.AddCust.Location = new System.Drawing.Point(48, 224);
            this.AddCust.Name = "AddCust";
            this.AddCust.Size = new System.Drawing.Size(75, 29);
            this.AddCust.TabIndex = 3;
            this.AddCust.Text = "Add";
            this.AddCust.UseVisualStyleBackColor = true;
            this.AddCust.Click += new System.EventHandler(this.AddCust_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 547);
            this.Controls.Add(this.AptsGroupBox);
            this.Controls.Add(this.CustomersGroupBox);
            this.Controls.Add(this.OtherControls);
            this.Controls.Add(this.MainFormTitle);
            this.Name = "MainForm";
            this.Text = "Scheduler Form";
            this.OtherControls.ResumeLayout(false);
            this.AptsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).EndInit();
            this.CustomersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainFormTitle;
        private System.Windows.Forms.GroupBox OtherControls;
        private System.Windows.Forms.GroupBox AptsGroupBox;
        private System.Windows.Forms.GroupBox CustomersGroupBox;
        private System.Windows.Forms.Button AddApt;
        private System.Windows.Forms.Button UpdateApt;
        private System.Windows.Forms.Button DeleteApt;
        private System.Windows.Forms.Button DeleteCust;
        private System.Windows.Forms.Button UpdateCust;
        private System.Windows.Forms.Button AddCust;
        private System.Windows.Forms.DataGridView appointmentDataGrid;
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.Button ReportsBtn;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button DateSelect;
        private System.Windows.Forms.Button ShowAllApts;
    }
}