﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Add_Appointment : Form
    {
        private Appointment appointmentForm;
        private int customerId;
        private int loggedInUserId;
        private DateTime selectedDate;
        private List<string> endTimes = new List<string> {
        "9:50 am", "10:50 am", "11:50 am", "12:50 pm",
        "1:50 pm", "2:50 pm", "3:50 pm", "4:50 pm"
    };

        public Add_Appointment(int loggedInUserId, int customerId, DateTime selectedDate, Appointment appointmentForm)
        {
            InitializeComponent();
            Start_Time_ComboBox();
            this.appointmentForm = appointmentForm;
            this.customerId = customerId;
            this.loggedInUserId = loggedInUserId;
            Add_User_ID_TxtBx.Text = loggedInUserId.ToString();
            this.selectedDate = selectedDate; 
            Start_Date_DTP.Value = selectedDate; 

            Start_Date_CB.SelectedIndexChanged += Start_Date_CB_SelectedIndexChanged;
            this.Add_Cancel_Button.Click += Add_Cancel_Button_Click;
        }

        private void Start_Time_ComboBox()
        {
            List<string> startTimes = new List<string> {
                "9 am", "10 am", "11 am", "12 pm",
                "1 pm", "2 pm", "3 pm", "4 pm"
            };

            foreach (string time in startTimes)
            {
                Start_Date_CB.Items.Add(time);
            }

            if (Start_Date_CB.Items.Count > 0)
                Start_Date_CB.SelectedIndex = 0;
        }

        private void Start_Date_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Start_Date_CB.SelectedIndex < 0) return;

            string selectedStart = Start_Date_CB.SelectedItem.ToString();
            TimeSpan selectedStartTime = DateTime.ParseExact(selectedStart, "h tt", CultureInfo.InvariantCulture).TimeOfDay;

            End_Date_CB.Items.Clear();
            foreach (var endTime in endTimes)
            {
                TimeSpan endSlotTime = DateTime.ParseExact(endTime, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
                if (endSlotTime > selectedStartTime)
                {
                    End_Date_CB.Items.Add(endTime);
                }
            }

            if (End_Date_CB.Items.Count > 0)
                End_Date_CB.SelectedIndex = 0;
        }

        private DateTime GetSelectedStartTime()
        {
            string selectedTime = Start_Date_CB.SelectedItem.ToString();
            return DateTime.ParseExact(selectedTime, "h tt", CultureInfo.InvariantCulture);
        }

        private DateTime GetSelectedEndTime()
        {
            string selectedTime = End_Date_CB.SelectedItem.ToString();
            return DateTime.ParseExact(selectedTime, "h:mm tt", CultureInfo.InvariantCulture);
        }

        private bool Appointment_Overlap(DateTime selectedDate, DateTime startTime)
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
                AND start = @StartTime";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    command.Parameters.AddWithValue("@StartTime", startTime);

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

        private void Save_Appointment(DateTime startTime, DateTime endTime, string appointmentType)
        {
            DateTime selectedDate = Start_Date_DTP.Value.Date;
            DateTime currentDateTime = DateTime.Now;


            if (selectedDate < currentDateTime.Date || (selectedDate == currentDateTime.Date && startTime < currentDateTime))
            {
                MessageBox.Show("Cannot add an appointment older than the current date and time.", "Invalid Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Appointment_Overlap(selectedDate, startTime))
            {
                MessageBox.Show("An appointment with the same date and start time already exists. Please choose a different date or time.", "Appointment Overlap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
            INSERT INTO appointment 
            (customerId, userId, title, description, location, contact, type, url, createDate, start, end, createdBy, lastUpdate, lastUpdateBy)
            VALUES 
            (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @createDate, @start, @end, @createdBy, NOW(), @lastUpdateBy);";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerId", this.customerId);
                    command.Parameters.AddWithValue("@userId", loggedInUserId);
                    command.Parameters.AddWithValue("@title", "New Appointment");
                    command.Parameters.AddWithValue("@description", "Description of the appointment");
                    command.Parameters.AddWithValue("@location", "Location of the appointment");
                    command.Parameters.AddWithValue("@contact", "Contact details");
                    command.Parameters.AddWithValue("@type", appointmentType);
                    command.Parameters.AddWithValue("@url", "http://example.com");
                    command.Parameters.AddWithValue("@createDate", selectedDate);
                    command.Parameters.AddWithValue("@start", startTime);
                    command.Parameters.AddWithValue("@end", endTime);
                    command.Parameters.AddWithValue("@createdBy", "Admin");
                    command.Parameters.AddWithValue("@lastUpdateBy", "Admin");

                    command.ExecuteNonQuery();
                    MessageBox.Show("Appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save the appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            appointmentForm.RefreshAppointmentsDataWithDate(Start_Date_DTP.Value.Date);

            this.Close();
            appointmentForm.Show();
        }

        private void Add_Save_Button_Click(object sender, EventArgs e)
        {
            DateTime selectedStartTime = GetSelectedStartTime();
            DateTime selectedEndTime = GetSelectedEndTime();

            string appointmentType = GetSelectedAppointmentType();

            Save_Appointment(selectedStartTime, selectedEndTime, appointmentType);
        }

        private string GetSelectedAppointmentType()
        {
            if (Lunch_Apt_RB.Checked)
            {
                return "Lunch";
            }
            else if (Interview_RB.Checked)
            {
                return "Interview";
            }
            else if (Meeting_RB.Checked)
            {
                return "Meeting";
            }
            else if (Group_Meet_RB.Checked)
            {
                return "Group Meeting";
            }
            else
            {
                return "Other";
            }
        }

        private void Add_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            appointmentForm.Show();
        }
    }
}