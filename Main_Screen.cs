using System;
using System.Configuration;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Main_Screen : Form
    {
        public string SelectedFullName { get; set; }
        public Main_Screen()
        {
            InitializeComponent();

            Customer_DaGrVi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Add_Cu_Button_Click(object sender, EventArgs e)
        {
            Add_Customer addCustomerForm = new Add_Customer();
            addCustomerForm.Show();
            this.Hide();
        }

        private void Update_Cu_Button_Click(object sender, EventArgs e)
        {
            if (Customer_DaGrVi.SelectedRows.Count > 0)
            {
                int selectedCustomerId = Convert.ToInt32(Customer_DaGrVi.SelectedRows[0].Cells["ID"].Value); // Make sure "ID" matches your DataGridView's column name
                Update_Customer updateCustomerForm = new Update_Customer(selectedCustomerId);
                updateCustomerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Close_App_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Screen_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void Customer_DaGrVi_SelectionChanged(object sender, EventArgs e)
        {
            if (Customer_DaGrVi.SelectedRows.Count > 0)
            {
                // Get the full name from the selected row
                SelectedFullName = Customer_DaGrVi.SelectedRows[0].Cells["FullName"].Value.ToString();
            }
            else
            {
                // If no row is selected, clear the SelectedFullName property
                SelectedFullName = "";
            }
        }

        private void Appointment_Button_Click(object sender, EventArgs e)
        {
            if (Customer_DaGrVi.SelectedRows.Count > 0)
            {
                var selectedRow = Customer_DaGrVi.SelectedRows[0];
                int selectedCustomerId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                string selectedCustomerName = Convert.ToString(selectedRow.Cells["FullName"].Value);

                // Create the Appointment form instance and pass the selected customer information
                Appointment appointmentForm = new Appointment(selectedCustomerId, selectedCustomerName, this);

                // Show the Appointment form
                appointmentForm.Show();

                // Hide the Main_Screen form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a customer first.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FILLDGV()
        {
            string connectionString =
                "server=localhost;port=3306;database=client_schedule;uid=root;pwd=Passw0rd!;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sqlQuery =
                        @"SELECT 
                c.customerId AS `ID`, 
                c.customerName AS `FullName`, 
                a.address AS `Address1`, 
                a.address2 AS `Address2`, 
                ci.city AS `City`,
                co.country AS `Country`,
                a.postalCode AS `ZipCode`, 
                a.phone AS `PhoneNumber` 
                FROM customer c 
                JOIN address a ON c.addressId = a.addressId 
                JOIN city ci ON a.cityId = ci.cityId
                JOIN country co ON ci.countryId = co.countryId";

                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            Customer_DaGrVi.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delete_Cu_Button_Click(object sender, EventArgs e)
        {
            // Check if any row is selected
            if (Customer_DaGrVi.SelectedRows.Count > 0)
            {
                // Confirm deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = Customer_DaGrVi.SelectedRows[0];

                    // Extract the customer ID from the selected row
                    int customerId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                    // Perform the deletion in the database
                    bool deletionSuccessful = DeleteCustomer(customerId);

                    if (deletionSuccessful)
                    {
                        // Remove the selected row from the DataGridView
                        Customer_DaGrVi.Rows.RemoveAt(selectedRow.Index);

                        MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool DeleteCustomer(int customerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            string query = "DELETE FROM customer WHERE customerId = @customerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("An error occurred while deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void Report_Button_Click(object sender, EventArgs e)
        {
            // Instantiate your Report form.
            Report reportForm = new Report();

            // Show the Report form.
            reportForm.Show();

            // Hide the Main_Screen form.
            this.Hide();

            // Optionally, you can set an event to re-show the Main_Screen when the Report form is closed.
            reportForm.FormClosed += (s, args) => this.Show();
        }
    }
}