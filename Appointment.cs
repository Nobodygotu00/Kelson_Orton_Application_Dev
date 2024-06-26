﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Appointment : Form
    {
        private Main_Screen mainScreen;
        private int selectedCustomerId;
        private string selectedCustomerName;
        private int logged_In_User_Id;

        public DataGridView WeekAptDGV { get { return Week_Apt_DGV; } }
        public DataGridView MonthAptDGV { get { return Month_Apt_DGV; } }
        public DataGridView AllAptDGV { get { return All_Apt_DGV; } }

        public Appointment(int userId, int selectedCustomerId, string selectedCustomerName, Main_Screen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
            this.selectedCustomerId = selectedCustomerId;
            this.selectedCustomerName = selectedCustomerName;
            this.logged_In_User_Id = userId;

            ID_TxtBx.Text = selectedCustomerId.ToString();
            Name_TxtBx.Text = selectedCustomerName;
            User_ID_TxtBx.Text = userId.ToString();

            Load_Week_Appointments(selectedCustomerId);
            Load_Month_Appointments(selectedCustomerId, DateTime.Now.Date);
            LoadAllAppointments();

            ConfigureDataGridView(Week_Apt_DGV);
            ConfigureDataGridView(Month_Apt_DGV);
        }

        public static void CheckForUpcomingAppointments(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                DateTime now = DateTime.Now;
                DateTime alertTime = now.AddMinutes(15);

                string query = @"
                    SELECT COUNT(*) 
                    FROM appointment 
                    WHERE userId = @userId 
                    AND start BETWEEN @now AND @alertTime";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@now", now);
                command.Parameters.AddWithValue("@alertTime", alertTime);

                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("You have an appointment within the next 15 minutes.", "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Appointment ID",
                Name = "appointmentId",
                DataPropertyName = "Appointment ID"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer ID",
                Name = "customerId",
                DataPropertyName = "Customer ID"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Full Name",
                Name = "fullName",
                DataPropertyName = "Full Name"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Type",
                Name = "type",
                DataPropertyName = "Type"
            });

            var createDateColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Create Date",
                Name = "createDate",
                DataPropertyName = "Create Date"
            };
            createDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy";
            dgv.Columns.Add(createDateColumn);


            var startTimeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Start Time",
                Name = "start",
                DataPropertyName = "Start"
            };
            startTimeColumn.DefaultCellStyle.Format = "h:mm tt";
            dgv.Columns.Add(startTimeColumn);


            var endTimeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "End Time",
                Name = "end",
                DataPropertyName = "End"
            };
            endTimeColumn.DefaultCellStyle.Format = "h:mm tt";
            dgv.Columns.Add(endTimeColumn);

            dgv.Refresh();
        }

        private void Load_Week_Appointments(int customerId)
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DateTime currentDate = DateTime.Today;
                    DateTime startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
                    DateTime endOfWeek = startOfWeek.AddDays(7);

                    string query = @"
                SELECT 
                    a.appointmentId AS `Appointment ID`, 
                    a.customerId AS `Customer ID`,  
                    c.customerName AS `Full Name`,  
                    a.type AS `Type`, 
                    a.createDate AS `Create Date`, 
                    a.start AS `Start`, 
                    a.end AS `End` 
                FROM appointment a
                JOIN customer c ON a.customerId = c.customerId
                WHERE a.customerId = @customerId 
                AND a.start >= @startOfWeek 
                AND a.start < @endOfWeek
                ORDER BY a.start";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startOfWeek", startOfWeek);
                    command.Parameters.AddWithValue("@endOfWeek", endOfWeek);
                    command.Parameters.AddWithValue("@customerId", customerId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    Week_Apt_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading week appointments: " + ex.Message);
                }
            }
            ConfigureDataGridView(Week_Apt_DGV);
            Week_Apt_DGV.ClearSelection();
        }

        private void Load_Month_Appointments(int customerId, DateTime selectedDate)
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1);

                    string query = @"
                SELECT 
                    a.appointmentId AS `Appointment ID`, 
                    a.customerId AS `Customer ID`,  
                    c.customerName AS `Full Name`,  
                    a.type AS `Type`, 
                    a.createDate AS `Create Date`, 
                    a.start AS `Start`, 
                    a.end AS `End` 
                FROM appointment a
                JOIN customer c ON a.customerId = c.customerId
                WHERE a.customerId = @customerId 
                AND a.createDate >= @startOfMonth 
                AND a.createDate < @endOfMonth
                AND (a.createDate > @currentDate OR (a.createDate = @currentDate AND a.start >= @currentTime))
                ORDER BY a.createDate, a.start";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                    command.Parameters.AddWithValue("@endOfMonth", endOfMonth);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@currentDate", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@currentTime", DateTime.Now);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    Month_Apt_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading month appointments: " + ex.Message);
                }
            }
            Month_Apt_DGV.ClearSelection();
        }

        private void LoadAllAppointments()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    a.appointmentId AS `Appointment ID`, 
                    a.customerId AS `Customer ID`,  
                    c.customerName AS `Full Name`,  
                    a.type, 
                    a.createDate AS `Create Date`, 
                    a.start, 
                    a.end 
                FROM appointment a
                JOIN customer c ON a.customerId = c.customerId
                WHERE (a.createDate > @currentDate OR (a.createDate = @currentDate AND a.start >= @currentTime))
                ORDER BY a.createDate, a.start";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@currentDate", DateTime.Now.Date);
                    command.Parameters.AddWithValue("@currentTime", DateTime.Now);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    All_Apt_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading all appointments: " + ex.Message);
                }
            }
            ConfigureDataGridView(All_Apt_DGV);
            All_Apt_DGV.ClearSelection();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            mainScreen.Show();
        }


        private void Sch_App_Button_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateTime.Now; 
            if (Week_Apt_DGV.SelectedRows.Count > 0)
            {
                selectedDate = Convert.ToDateTime(Week_Apt_DGV.SelectedRows[0].Cells["createDate"].Value);
            }
            else if (Month_Apt_DGV.SelectedRows.Count > 0)
            {
                selectedDate = Convert.ToDateTime(Month_Apt_DGV.SelectedRows[0].Cells["createDate"].Value);
            }
            else if (All_Apt_DGV.SelectedRows.Count > 0)
            {
                selectedDate = Convert.ToDateTime(All_Apt_DGV.SelectedRows[0].Cells["createDate"].Value);
            }

            Add_Appointment addAppointmentForm = new Add_Appointment(logged_In_User_Id, selectedCustomerId, selectedDate, this);
            addAppointmentForm.Show();
            this.Hide();
        }

        private void Up_Week_Button_Click(object sender, EventArgs e)
        {
            if (Week_Apt_DGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Week_Apt_DGV.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
                string startTime = Convert.ToString(selectedRow.Cells["start"].Value);
                string endTime = Convert.ToString(selectedRow.Cells["end"].Value);

                Update_Appointment updateForm = new Update_Appointment(appointmentId, logged_In_User_Id, this);
                updateForm.SetDateTimeValues(startTime, endTime);
                updateForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a week appointment to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Up_Month_Button_Click(object sender, EventArgs e)
        {
            if (Month_Apt_DGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Month_Apt_DGV.SelectedRows[0];
                int appointmentId = Convert.ToInt32(selectedRow.Cells["appointmentId"].Value);
                string startTime = Convert.ToString(selectedRow.Cells["start"].Value);
                string endTime = Convert.ToString(selectedRow.Cells["end"].Value);

                Update_Appointment updateForm = new Update_Appointment(appointmentId, logged_In_User_Id, this);
                updateForm.SetDateTimeValues(startTime, endTime);
                updateForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a month appointment to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Delete_Week_Button_Click(object sender, EventArgs e)
        {
            Delete_Selected_Appointment(Week_Apt_DGV);
        }

        private void Delete_Month_Button_Click(object sender, EventArgs e)
        {
            Delete_Selected_Appointment(Month_Apt_DGV);
        }

        public void RefreshAppointmentsDataWithDate(DateTime selectedDate)
        {
            Load_Week_Appointments(selectedCustomerId);
            Load_Month_Appointments(selectedCustomerId, selectedDate);
            LoadAllAppointments();
        }

        private void Delete_Selected_Appointment(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int appointmentId = Convert.ToInt32(dgv.SelectedRows[0].Cells["appointmentId"].Value);
                if (MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                            MessageBox.Show("Appointment deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            
                            Load_Week_Appointments(selectedCustomerId);
                            Load_Month_Appointments(selectedCustomerId, DateTime.Now.Date);
                            LoadAllAppointments();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting appointment: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}