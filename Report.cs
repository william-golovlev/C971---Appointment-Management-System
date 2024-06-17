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
    public partial class Report : Form
    {
        public Report(int choice)
        {
            InitializeComponent();
            dataGridView1.DataSource = Database.Report(choice);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string Report_Name { get { return ReportName.Text; } set { ReportName.Text = value; } }
    }
}
