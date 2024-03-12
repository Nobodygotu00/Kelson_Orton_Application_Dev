using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Make sure to add a reference to the MySql.Data DLL

namespace Kelson_Orton_Application_Dev
{
    public partial class Customer_Record : Form
    {
        // connection string
        private string connectionString = "SERVER=localhost;DATABASE=client_schedule;UID=sqlUser;PASSWORD=Passw0rd!;";
        public Main_Screen MainScreen { get; set; }

        public Customer_Record()
        {
            InitializeComponent();
        }

        private void Customer_Record_Load(object sender, EventArgs e)
        {
            Load_Customer_Data();
        }
        public void AddCustomerRow(string fullName, string address, string phoneNumber)
        {
            // Check if the DataGridView is accessible and not in a state that would throw exceptions
            if (Customer_Record_DaGrVi != null && !Customer_Record_DaGrVi.IsDisposed)
            {
                var rowIndex = Customer_Record_DaGrVi.Rows.Add();
                var newRow = Customer_Record_DaGrVi.Rows[rowIndex];
                newRow.Cells["Full Name"].Value = fullName;
                newRow.Cells["Address"].Value = address;
                newRow.Cells["Phone Number"].Value = phoneNumber;
            }
        }

        private void Load_Customer_Data()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT c.name AS 'Full Name', a.address AS 'Address', a.phone_number AS 'Phone Number'
                FROM customer c
                JOIN address a ON c.address_id = a.id;
            ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Clear existing columns 
                            Customer_Record_DaGrVi.Columns.Clear();

                            // AutoGenerateColumns to true to create columns automatically
                            Customer_Record_DaGrVi.AutoGenerateColumns = true;

                            // Set the DataSource to your DataTable
                            Customer_Record_DaGrVi.DataSource = dataTable;

                            // After setting the DataSource, format the 'Phone Number' column
                            if (Customer_Record_DaGrVi.Columns["Phone Number"] != null)
                            {
                                Customer_Record_DaGrVi.Columns["Phone Number"].DefaultCellStyle.Format = "0"; // Format as whole number
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }



        private void Customer_Record_Add_Button_Click(object sender, EventArgs e)
        {
            // Create instance of the Customer_Record_Add form and pass 'this' as the argument
            Customer_Record_Add customerRecordAddForm = new Customer_Record_Add(this);

            // Show Customer_Record_Add form
            customerRecordAddForm.Show();

            // Hide Customer_Record form
            this.Hide();
        }

        private void Customer_Record_Update_Button_Click(object sender, EventArgs e)
        {
            // Create instance of the Customer_Record_Update form
            Customer_Record_Update customerRecordUpdateForm = new Customer_Record_Update();

            // Show the Customer_Record_Update form
            customerRecordUpdateForm.Show();

            // Hide the Customer_Record form
            this.Hide();
        }

        private void Customer_Record_Return_Button_Click(object sender, EventArgs e)
        {
            // Close
            this.Close(); // Close the Customer_Record form

            Main_Screen main = new Main_Screen();
            main.Show(); // Show the Main_Screen form again
        }

        private void Customer_Record_Delete_Button_Click(object sender, EventArgs e)
        {

        }
    }
}