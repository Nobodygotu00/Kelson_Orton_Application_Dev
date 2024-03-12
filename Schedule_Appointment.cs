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
    public partial class Schedule_Appointment : Form
    {
        public Schedule_Appointment()
        {
            InitializeComponent();
        }

        private void Schedule_Appointment_Update_Button_Click(object sender, EventArgs e)
        {
            // Create instance of the Schedule_Appointment_Update form
            Schedule_Appointment_Update scheduleAppointmentUpdateForm = new Schedule_Appointment_Update();

            // Show the Schedule_Appointment_Update form
            scheduleAppointmentUpdateForm.Show();

            // Hide the Schedule_Appointment form
            this.Hide();
        }

        private void Schedule_Appointment_Add_Button_Click(object sender, EventArgs e)
        {
            // Create instance of the Schedule_Appointment_Add form
            Schedule_Appointment_Add scheduleAppointmentAddForm = new Schedule_Appointment_Add();

            // Show the Schedule_Appointment_Add form
            scheduleAppointmentAddForm.Show();

            // Hide the Schedule_Appointment form
            this.Hide();
        }

        private void Schedule_Appointment_Return_Button_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the Schedule_Appointment form

            Main_Screen main = new Main_Screen();
            main.Show(); // Show the Main_Screen form again
        }
    }
}
