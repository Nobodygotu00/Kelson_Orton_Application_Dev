using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelson_Orton_Application_Dev
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            this.Load += new EventHandler(Report_Load);
        }

        private void Return_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Appointment_Types_Month();
            Load_Report_Sched_Month();
            Load_User_Data_And_Customer_Count();
        }

        private void Appointment_Types_Month()
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
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                    string query = @"
                SELECT type, COUNT(*) as 'TypeCount' 
                FROM appointment 
                WHERE start >= @startOfMonth AND start <= @endOfMonth 
                GROUP BY type
                ORDER BY 'TypeCount' DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                        command.Parameters.AddWithValue("@endOfMonth", endOfMonth);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointment types for the month: " + ex.Message);
                }
            }

            Apt_Type_Month_DGV.DataSource = dataTable;
        }

        private void Load_Report_Sched_Month()
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
            WHERE a.start >= @startOfMonth 
            AND a.start < @endOfMonth
            ORDER BY a.start;";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                    command.Parameters.AddWithValue("@endOfMonth", endOfMonth);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    Report_Sched_Month_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading report schedule for the month: " + ex.Message);
                }
            }

            Report_Sched_Month_DGV.ClearSelection();
        }

        private void Load_User_Data_And_Customer_Count()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string userQuery = "SELECT userId, userName FROM user;";
                    MySqlCommand userCommand = new MySqlCommand(userQuery, connection);
                    MySqlDataAdapter userAdapter = new MySqlDataAdapter(userCommand);
                    userAdapter.Fill(dataTable);

                    
                    string customerCountQuery = "SELECT COUNT(*) AS NumberOfCustomers FROM customer;";
                    MySqlCommand customerCountCommand = new MySqlCommand(customerCountQuery, connection);
                    int customerCount = Convert.ToInt32(customerCountCommand.ExecuteScalar());

                    
                    dataTable.Columns.Add("NumberOfCustomers", typeof(int));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["NumberOfCustomers"] = customerCount;
                    }

                    Report_Num_Cu_DGV.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user data and customer count: " + ex.Message);
                }
            }

            Report_Num_Cu_DGV.ClearSelection();
        }

    }
}
