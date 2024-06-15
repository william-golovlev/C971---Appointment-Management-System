namespace Appointment_Management_System
{
    partial class AppointmentForm
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AptIDLabel = new System.Windows.Forms.Label();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.AptTitleLabel = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.URLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.EndLabel = new System.Windows.Forms.Label();
            this.StartComboBox = new System.Windows.Forms.ComboBox();
            this.EndComboBox = new System.Windows.Forms.ComboBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.TypeTextComboBox = new System.Windows.Forms.ComboBox();
            this.DescTextBox = new System.Windows.Forms.TextBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.ContactComboBox = new System.Windows.Forms.ComboBox();
            this.IDtextbox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.StartDayCombo = new System.Windows.Forms.ComboBox();
            this.EndDayCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(157, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(172, 25);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Appointment Form";
            // 
            // AptIDLabel
            // 
            this.AptIDLabel.AutoSize = true;
            this.AptIDLabel.Location = new System.Drawing.Point(24, 65);
            this.AptIDLabel.Name = "AptIDLabel";
            this.AptIDLabel.Size = new System.Drawing.Size(20, 16);
            this.AptIDLabel.TabIndex = 1;
            this.AptIDLabel.Text = "ID";
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Location = new System.Drawing.Point(24, 129);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(52, 16);
            this.ContactLabel.TabIndex = 2;
            this.ContactLabel.Text = "Contact";
            // 
            // AptTitleLabel
            // 
            this.AptTitleLabel.AutoSize = true;
            this.AptTitleLabel.Location = new System.Drawing.Point(24, 189);
            this.AptTitleLabel.Name = "AptTitleLabel";
            this.AptTitleLabel.Size = new System.Drawing.Size(33, 16);
            this.AptTitleLabel.TabIndex = 3;
            this.AptTitleLabel.Text = "Title";
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(24, 256);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(75, 16);
            this.DescLabel.TabIndex = 4;
            this.DescLabel.Text = "Description";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(24, 318);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(58, 16);
            this.LocationLabel.TabIndex = 5;
            this.LocationLabel.Text = "Location";
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(24, 387);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(39, 16);
            this.TypeLabel.TabIndex = 6;
            this.TypeLabel.Text = "Type";
            // 
            // URLabel
            // 
            this.URLabel.AutoSize = true;
            this.URLabel.Location = new System.Drawing.Point(24, 455);
            this.URLabel.Name = "URLabel";
            this.URLabel.Size = new System.Drawing.Size(34, 16);
            this.URLabel.TabIndex = 7;
            this.URLabel.Text = "URL";
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(24, 522);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(68, 16);
            this.StartLabel.TabIndex = 8;
            this.StartLabel.Text = "Start Time";
            // 
            // EndLabel
            // 
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(24, 582);
            this.EndLabel.Name = "EndLabel";
            this.EndLabel.Size = new System.Drawing.Size(65, 16);
            this.EndLabel.TabIndex = 9;
            this.EndLabel.Text = "End Time";
            // 
            // StartComboBox
            // 
            this.StartComboBox.FormattingEnabled = true;
            this.StartComboBox.Location = new System.Drawing.Point(98, 519);
            this.StartComboBox.Name = "StartComboBox";
            this.StartComboBox.Size = new System.Drawing.Size(174, 24);
            this.StartComboBox.TabIndex = 10;
            // 
            // EndComboBox
            // 
            this.EndComboBox.FormattingEnabled = true;
            this.EndComboBox.Location = new System.Drawing.Point(98, 579);
            this.EndComboBox.Name = "EndComboBox";
            this.EndComboBox.Size = new System.Drawing.Size(174, 24);
            this.EndComboBox.TabIndex = 11;
            this.EndComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(98, 455);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(319, 22);
            this.UrlTextBox.TabIndex = 12;
            this.UrlTextBox.Text = "https://";
            // 
            // TypeTextComboBox
            // 
            this.TypeTextComboBox.FormattingEnabled = true;
            this.TypeTextComboBox.Location = new System.Drawing.Point(98, 387);
            this.TypeTextComboBox.Name = "TypeTextComboBox";
            this.TypeTextComboBox.Size = new System.Drawing.Size(210, 24);
            this.TypeTextComboBox.TabIndex = 13;
            // 
            // DescTextBox
            // 
            this.DescTextBox.Location = new System.Drawing.Point(98, 256);
            this.DescTextBox.Name = "DescTextBox";
            this.DescTextBox.Size = new System.Drawing.Size(319, 22);
            this.DescTextBox.TabIndex = 14;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(98, 315);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(210, 22);
            this.LocationTextBox.TabIndex = 15;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(98, 189);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(210, 22);
            this.TitleTextBox.TabIndex = 16;
            // 
            // ContactComboBox
            // 
            this.ContactComboBox.FormattingEnabled = true;
            this.ContactComboBox.Location = new System.Drawing.Point(98, 126);
            this.ContactComboBox.Name = "ContactComboBox";
            this.ContactComboBox.Size = new System.Drawing.Size(210, 24);
            this.ContactComboBox.TabIndex = 17;
            // 
            // IDtextbox
            // 
            this.IDtextbox.Location = new System.Drawing.Point(98, 65);
            this.IDtextbox.Name = "IDtextbox";
            this.IDtextbox.ReadOnly = true;
            this.IDtextbox.Size = new System.Drawing.Size(210, 22);
            this.IDtextbox.TabIndex = 18;
            // 
            // SaveBtn
            // 
            this.SaveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveBtn.Location = new System.Drawing.Point(378, 533);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(114, 37);
            this.SaveBtn.TabIndex = 19;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(378, 579);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(114, 34);
            this.CancelBtn.TabIndex = 20;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // StartDayCombo
            // 
            this.StartDayCombo.FormattingEnabled = true;
            this.StartDayCombo.Location = new System.Drawing.Point(283, 519);
            this.StartDayCombo.Name = "StartDayCombo";
            this.StartDayCombo.Size = new System.Drawing.Size(52, 24);
            this.StartDayCombo.TabIndex = 21;
            // 
            // EndDayCombo
            // 
            this.EndDayCombo.FormattingEnabled = true;
            this.EndDayCombo.Location = new System.Drawing.Point(283, 579);
            this.EndDayCombo.Name = "EndDayCombo";
            this.EndDayCombo.Size = new System.Drawing.Size(52, 24);
            this.EndDayCombo.TabIndex = 22;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 636);
            this.Controls.Add(this.EndDayCombo);
            this.Controls.Add(this.StartDayCombo);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.IDtextbox);
            this.Controls.Add(this.ContactComboBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.DescTextBox);
            this.Controls.Add(this.TypeTextComboBox);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.EndComboBox);
            this.Controls.Add(this.StartComboBox);
            this.Controls.Add(this.EndLabel);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.URLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.AptTitleLabel);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.AptIDLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AptIDLabel;
        private System.Windows.Forms.Label ContactLabel;
        private System.Windows.Forms.Label AptTitleLabel;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label URLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.ComboBox StartComboBox;
        private System.Windows.Forms.ComboBox EndComboBox;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.ComboBox TypeTextComboBox;
        private System.Windows.Forms.TextBox DescTextBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ComboBox ContactComboBox;
        private System.Windows.Forms.TextBox IDtextbox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ComboBox StartDayCombo;
        private System.Windows.Forms.ComboBox EndDayCombo;
    }
}