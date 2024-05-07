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
                int selectedCustomerId = Convert.ToInt32(Customer_DaGrVi.SelectedRows[0].Cells["ID"].Value); 
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

                SelectedFullName = Customer_DaGrVi.SelectedRows[0].Cells["FullName"].Value.ToString();
            }
            else
            {

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

                Form1 loginForm = (Form1)Application.OpenForms["Form1"];
                int logged_In_User_Id = loginForm.Logged_In_User_Id;

                Appointment appointmentForm = new Appointment(logged_In_User_Id, selectedCustomerId, selectedCustomerName, this);

                appointmentForm.Show();

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
                ci.city AS `City`,
                co.country AS `Country`, 
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
            if (Customer_DaGrVi.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Customer_DaGrVi.SelectedRows[0];

                    int customerId = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                    bool deletionSuccessful = DeleteCustomer(customerId);

                    if (deletionSuccessful)
                    {
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
            Report reportForm = new Report();

            reportForm.Show();

            this.Hide();

            reportForm.FormClosed += (s, args) => this.Show();
        }
    }
}