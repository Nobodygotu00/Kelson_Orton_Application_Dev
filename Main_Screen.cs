using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelson_Orton_Application_Dev
{
    public partial class Main_Screen : Form
    {
        public Main_Screen()
        {
            InitializeComponent();
            this.FormClosed += Main_Screen_FormClosed;
        }

        private void Main_Screen_Schedule_Button_Click(object sender, EventArgs e)
        {
            // Instantiate the Schedule_Appointment form
            Schedule_Appointment scheduleAppointmentForm = new Schedule_Appointment();

            // Show the Schedule_Appointment form
            scheduleAppointmentForm.Show();

            // Hide the Main_Screen form
            this.Hide();
        }

        private void Main_Screen_Record_Button_Click(object sender, EventArgs e)
        {
            // Create instance of the Customer_Record form
            Customer_Record customerRecordForm = new Customer_Record();

            // Show the Customer_Record form
            customerRecordForm.Show();

            // Hide the Main_Screen form
            this.Hide();
        }

        private void Main_Screen_Exit_Button_Click(object sender, EventArgs e)
        {
            // Close the Main_Screen form
            this.Close();
        }
        private void Main_Screen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
