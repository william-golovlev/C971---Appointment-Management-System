using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Management_System
{
    public partial class ReportChoices : Form
    {
        public ReportChoices()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report report = new Report(0);
            report.Name = "Report";
            report.Report_Name = "Monthly Report";
            report.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report = new Report(1);
            report.Name = "Report";
            report.Report_Name = "User Schedules";
            report.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report report = new Report(2);
            report.Name = "Report";
            report.Report_Name = "Appointments By Type";
            report.Show();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
