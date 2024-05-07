using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Update_Appointment : Form
    {
        private int appointmentId;
        private Appointment appointmentForm;
        private int loggedInUserId;
        private List<string> endTimes = new List<string> {
            "9:50 am", "10:50 am", "11:50 am", "12:50 pm",
            "1:50 pm", "2:50 pm", "3:50 pm", "4:50 pm"
        };


        public Update_Appointment(int appointmentId, int loggedInUserId, Appointment appointmentForm)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            this.appointmentForm = appointmentForm;
            this.loggedInUserId = loggedInUserId;
            Up_User_ID_TxtBx.Text = loggedInUserId.ToString();

            ConfigureDataGridView(appointmentForm.WeekAptDGV);
            ConfigureDataGridView(appointmentForm.MonthAptDGV);
            ConfigureDataGridView(appointmentForm.AllAptDGV);

            PopulateStartAndEndTimeComboBoxes();
            LoadAppointmentDetails();
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Create Date"))
            {
                dgv.Columns["Create Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }
            if (dgv.Columns.Contains("Start"))
            {
                dgv.Columns["Start"].DefaultCellStyle.Format = "h:mm tt";
            }
            if (dgv.Columns.Contains("End"))
            {
                dgv.Columns["End"].DefaultCellStyle.Format = "h:mm tt";
            }
            dgv.Refresh();
        }

        private void ConfigureDataGridViewColumn(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Create Date"))
            {
                dgv.Columns["Create Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            }
            if (dgv.Columns.Contains("Start"))
            {
                dgv.Columns["Start"].DefaultCellStyle.Format = "h:mm tt"; 
            }
            if (dgv.Columns.Contains("End"))
            {
                dgv.Columns["End"].DefaultCellStyle.Format = "h:mm tt"; 
            }
            dgv.Refresh();
        }

        private void Ud_Start_Date_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStart = Ud_Start_Date_CB.SelectedItem.ToString();
            DateTime startTime = DateTime.ParseExact(selectedStart, "h tt", CultureInfo.InvariantCulture);

            Ud_End_Date_CB.Items.Clear();
            foreach (string endTime in endTimes)
            {
                DateTime endDateTime = DateTime.ParseExact(endTime, "h:mm tt", CultureInfo.InvariantCulture);
                if (endDateTime.TimeOfDay > startTime.TimeOfDay)
                {
                    Ud_End_Date_CB.Items.Add(endTime);
                }
            }

            if (Ud_End_Date_CB.Items.Count > 0)
            {
                Ud_End_Date_CB.SelectedIndex = 0;
            }
        }

        private DateTime CombineDateAndTime(DateTime datePart, string timePart)
        {
            DateTime time = DateTime.ParseExact(timePart,
                timePart.Contains(":") ? "h:mm tt" : "h tt",
                CultureInfo.InvariantCulture);
            return new DateTime(datePart.Year, datePart.Month,
                datePart.Day, time.Hour, time.Minute, 0);
        }

        private void PopulateStartAndEndTimeComboBoxes()
        {
            string[] startTimes = { "9 am", "10 am", "11 am", "12 pm", "1 pm", "2 pm", "3 pm", "4 pm" };

            Ud_Start_Date_CB.Items.Clear();
            Ud_End_Date_CB.Items.Clear();

            foreach (string time in startTimes)
            {
                Ud_Start_Date_CB.Items.Add(time);
            }

            foreach (string time in endTimes)
            {
                Ud_End_Date_CB.Items.Add(time);
            }
        }

        private void LoadAppointmentDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT createDate, start, end, type FROM appointment WHERE appointmentId = @appointmentId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointmentId", this.appointmentId);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime createDate = Convert.ToDateTime(reader["createDate"]);
                        DateTime start = Convert.ToDateTime(reader["start"]);
                        DateTime end = Convert.ToDateTime(reader["end"]);
                        string type = reader["type"].ToString();

                        Start_Date_DTP.Value = createDate;
                        
                        Ud_Start_Date_CB.SelectedItem = start.ToString("h tt", CultureInfo.InvariantCulture);
                        Ud_End_Date_CB.SelectedItem = end.ToString("h:mm tt", CultureInfo.InvariantCulture);

                        foreach (RadioButton rb in Ud_Panel.Controls.OfType<RadioButton>())
                        {
                            if (rb.Text == type)
                            {
                                rb.Checked = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load appointment details: " + ex.Message);
                }
            }
        }

        private bool Appointment_Overlap_Update(DateTime selectedDate, DateTime startTime, int appointmentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT COUNT(*) 
                FROM appointment
                WHERE createDate = @SelectedDate
                AND start = @StartTime
                AND appointmentId <> @AppointmentId";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to check for overlapping appointments: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
        }

        public void SetDateTimeValues(string startTime, string endTime)
        {
            DateTime startDateTime = DateTime.Parse(startTime);
            DateTime endDateTime = DateTime.Parse(endTime);

            Ud_Start_Date_CB.Text = startDateTime.ToString("h:mm tt");
            Ud_End_Date_CB.Text = endDateTime.ToString("h:mm tt");
        }

        private void Update_Save_Button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ud_Start_Date_CB.Text) || string.IsNullOrEmpty(Ud_End_Date_CB.Text))
            {
                MessageBox.Show("Start and end times cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] formats = { "h:mm tt", "h tt" };
            DateTime startDateTime;
            DateTime endDateTime;

            try
            {
                startDateTime = DateTime.ParseExact(Ud_Start_Date_CB.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format for start time. Expected format: 'h:mm tt' or 'h tt'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                endDateTime = DateTime.ParseExact(Ud_End_Date_CB.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format for end time. Expected format: 'h:mm tt' or 'h tt'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (endDateTime <= startDateTime)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime createDate = Start_Date_DTP.Value;
            DateTime currentDateTime = DateTime.Now;

            if (createDate < currentDateTime.Date || (createDate == currentDateTime.Date && startDateTime < currentDateTime))
            {
                MessageBox.Show("Cannot update an appointment to a date and time older than the current date and time.", "Invalid Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Appointment_Overlap_Update(createDate, startDateTime, this.appointmentId))
            {
                MessageBox.Show("An appointment with the same date and start time already exists. Please choose a different date or time.", "Appointment Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string appointmentType = Ud_Panel.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(rb => rb.Checked)?.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE appointment SET start = @start, end = @end, type = @type, createDate = @createDate WHERE appointmentId = @appointmentId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@start", startDateTime);
                    command.Parameters.AddWithValue("@end", endDateTime);
                    command.Parameters.AddWithValue("@type", appointmentType);
                    command.Parameters.AddWithValue("@createDate", createDate);
                    command.Parameters.AddWithValue("@appointmentId", this.appointmentId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Appointment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            appointmentForm.RefreshAppointmentsDataWithDate(Start_Date_DTP.Value.Date);
            this.Close();
            appointmentForm.Show();
        }
        private void Add_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            appointmentForm.Show();
        }


    }
}