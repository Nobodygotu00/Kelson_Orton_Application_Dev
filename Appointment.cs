using System;
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

        public DataGridView WeekAptDGV { get { return Week_Apt_DGV; } }
        public DataGridView MonthAptDGV { get { return Month_Apt_DGV; } }
        public DataGridView AllAptDGV { get { return All_Apt_DGV; } }

        public Appointment(int selectedCustomerId, string selectedCustomerName, Main_Screen mainScreen)
        {
            InitializeComponent();
            this.mainScreen = mainScreen;
            this.selectedCustomerId = selectedCustomerId;
            this.selectedCustomerName = selectedCustomerName;

            ID_TxtBx.Text = selectedCustomerId.ToString();
            Name_TxtBx.Text = selectedCustomerName;

            Load_Week_Appointments(selectedCustomerId);
            Load_Month_Appointments(selectedCustomerId);
            LoadAllAppointments();

            ConfigureDataGridView(Week_Apt_DGV);
            ConfigureDataGridView(Month_Apt_DGV);
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

            // Format the Start column to show only time
            var startTimeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Start Time",
                Name = "start",
                DataPropertyName = "Start"
            };
            startTimeColumn.DefaultCellStyle.Format = "h:mm tt"; 
            dgv.Columns.Add(startTimeColumn);

            // Format the End column to show only time
            var endTimeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "End Time",
                Name = "end",
                DataPropertyName = "End"
            };
            endTimeColumn.DefaultCellStyle.Format = "h:mm tt"; 
            dgv.Columns.Add(endTimeColumn);

            dgv.Refresh(); // Refresh the DataGridView to show updated column configurations
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
                    DateTime now = DateTime.Now;
                    DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek);
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
                AND a.start < @endOfWeek";

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
            ConfigureDataGridView(Week_Apt_DGV); // Ensure the DataGridView is configured
            Week_Apt_DGV.ClearSelection();
        }

        private void Load_Month_Appointments(int customerId)
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DateTime now = DateTime.Now;
                    DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
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
                AND a.start >= @startOfMonth 
                AND a.start < @endOfMonth";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                    command.Parameters.AddWithValue("@endOfMonth", endOfMonth);
                    command.Parameters.AddWithValue("@customerId", customerId);

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
                    // Corrected query to include SQL-style comments
                    string query = @"
                SELECT 
                    a.appointmentId AS `Appointment ID`, 
                    a.customerId AS `Customer ID`,  
                    c.customerName AS `Full Name`,  
                    a.type, 
                    a.createDate AS `Create Date`, 
                    a.start, 
                    a.end 
                FROM appointment a  -- Use alias a for appointment table
                JOIN customer c ON a.customerId = c.customerId"; // Use alias c for customer table
                    MySqlCommand command = new MySqlCommand(query, connection);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    All_Apt_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading all appointments: " + ex.Message);
                }
            }
            ConfigureDataGridView(All_Apt_DGV); // Reconfigure DataGridView columns
            All_Apt_DGV.ClearSelection();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the Appointment form
            mainScreen.Show();
        }

        // Event handler for the FormClosed event
        private void Sch_App_Button_Click(object sender, EventArgs e)
        {
            // Create a new instance of Add_Appointment, passing in the selectedCustomerId
            Add_Appointment addAppointmentForm = new Add_Appointment(this, selectedCustomerId);
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

                Update_Appointment updateForm = new Update_Appointment(appointmentId, this);
                updateForm.SetDateTimeValues(startTime, endTime); // Method to set values
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

                Update_Appointment updateForm = new Update_Appointment(appointmentId, this);
                updateForm.SetDateTimeValues(startTime, endTime);
                updateForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a month appointment to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Up_All_Button_Click(object sender, EventArgs e)
        {
            if (All_Apt_DGV.SelectedRows.Count > 0)
            {
                OpenUpdateAppointmentForm(All_Apt_DGV);
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenUpdateAppointmentForm(DataGridView dgv)
        {
            int appointmentId = Convert.ToInt32(dgv.SelectedRows[0].Cells["appointmentId"].Value);
            Update_Appointment updateForm = new Update_Appointment(appointmentId, this);
            updateForm.Show();
            this.Hide();
        }

        private void Delete_Week_Button_Click(object sender, EventArgs e)
        {
            Delete_Selected_Appointment(Week_Apt_DGV);
        }

        private void Delete_Month_Button_Click(object sender, EventArgs e)
        {
            Delete_Selected_Appointment(Month_Apt_DGV);
        }

        public void RefreshAppointmentsData()
        {
            Load_Week_Appointments(selectedCustomerId);
            Load_Month_Appointments(selectedCustomerId);
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
        // Additional methods and event handlers for Appointment...

    }
}