using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Update_Customer : Form
    {
        private int customerId;
        // Define fields to store the customer details
        private string customerName;
        private string address1;
        private string address2;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private int selectedCustomerId; // Added field to store the selected customer ID

        public Update_Customer(int customerId) // Modified constructor to accept customerId
        {
            InitializeComponent();
            this.customerId = customerId;
            // Store the selected customer ID
            selectedCustomerId = customerId;
            UP_ID_TxtBx.Text = this.customerId.ToString();

            // Fetch customer details based on the provided customerId
            FetchCustomerDetails(customerId);

            // Attach event handler
            UP_Phone_Num_TxtBx.KeyPress += Phone_Num_TxtBx_KeyPress;
        }


        private void Phone_Num_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and hyphen
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-' || (sender as TextBox).Text.Count(f => f == '-') >= 2))
            {
                e.Handled = true;
            }

            // Allow backspace
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void FetchCustomerDetails(int customerId) // Modified method to accept customerId
        {
            string connectionString = "server=localhost;port=3306;database=client_schedule;uid=root;pwd=Passw0rd!;";

            string query = @"
                SELECT 
                    c.customerName, 
                    a.address, 
                    a.address2, 
                    ci.city,
                    co.country,
                    a.postalCode, 
                    a.phone 
                FROM customer c 
                JOIN address a ON c.addressId = a.addressId 
                JOIN city ci ON a.cityId = ci.cityId 
                JOIN country co ON ci.countryID = co.countryId
                WHERE c.customerId = @customerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Store customer details in fields
                                customerName = reader.GetString("customerName");
                                address1 = reader.GetString("address");
                                address2 = reader.GetString("address2");
                                city = reader.GetString("city");
                                string country = reader.GetString("country");
                                postalCode = reader.GetString("postalCode");
                                phoneNumber = reader.GetString("phone");

                                // Populate TextBoxes with customer details
                                UP_Full_Name_TxtBx.Text = customerName;
                                UP_Address_TxtBx.Text = address1;
                                UP_City_TxtBx.Text = city;
                                UP_Country_TxtBx.Text = country;
                                UP_Phone_Num_TxtBx.Text = phoneNumber;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while fetching customer details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UP_Add_Cu_Cancel_Click(object sender, EventArgs e)
        {
            Main_Screen mainScreen = new Main_Screen();
            mainScreen.Show();
            this.Close();
        }

        private void UP_Add_Cu_Save_Click(object sender, EventArgs e)
        {
            // Validate customer details before saving
            if (ValidateCustomerDetails())
            {
                // Call a method to save the changes
                UpdateCustomerDetails();

                // Close the Update_Customer form
                this.Close();
            }
        }

        private bool ValidateCustomerDetails()
        {
            // Check if any of the required fields are empty
            if (string.IsNullOrWhiteSpace(UP_Full_Name_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(UP_Address_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(UP_City_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(UP_Country_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(UP_Phone_Num_TxtBx.Text))
            {
                // Show a message box indicating that all fields must be filled
                MessageBox.Show("Please fill in all required fields: Full Name, Address, City, Country, and Phone Number.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Validation failed
            }

            return true; // Validation passed
        }

        private void UpdateCustomerDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Begin a transaction
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int countryId;
                    int cityId;

                    // Check if the country exists in the database
                    string queryCountry = "SELECT countryId FROM country WHERE country = @country";
                    MySqlCommand countryCommand = new MySqlCommand(queryCountry, connection, transaction);
                    countryCommand.Parameters.AddWithValue("@country", UP_Country_TxtBx.Text);

                    object resultCountry = countryCommand.ExecuteScalar();

                    if (resultCountry != null)
                    {
                        // Country exists
                        countryId = Convert.ToInt32(resultCountry);
                    }
                    else
                    {
                        // Insert new country
                        string insertCountry = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@country, NOW(), 'user', NOW(), 'user')";
                        MySqlCommand insertCountryCommand = new MySqlCommand(insertCountry, connection, transaction);
                        insertCountryCommand.Parameters.AddWithValue("@country", UP_Country_TxtBx.Text);
                        insertCountryCommand.ExecuteNonQuery();
                        countryId = (int)insertCountryCommand.LastInsertedId;
                    }

                    // Check if the city exists in this country
                    string queryCity = "SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";
                    MySqlCommand cityCommand = new MySqlCommand(queryCity, connection, transaction);
                    cityCommand.Parameters.AddWithValue("@city", UP_City_TxtBx.Text);
                    cityCommand.Parameters.AddWithValue("@countryId", countryId);

                    object resultCity = cityCommand.ExecuteScalar();

                    if (resultCity != null)
                    {
                        // City exists
                        cityId = Convert.ToInt32(resultCity);
                    }
                    else
                    {
                        // Insert new city
                        string insertCity = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES (@city, @countryId, NOW(), 'user', NOW(), 'user')";
                        MySqlCommand insertCityCommand = new MySqlCommand(insertCity, connection, transaction);
                        insertCityCommand.Parameters.AddWithValue("@city", UP_City_TxtBx.Text);
                        insertCityCommand.Parameters.AddWithValue("@countryId", countryId);
                        insertCityCommand.ExecuteNonQuery();
                        cityId = (int)insertCityCommand.LastInsertedId;
                    }

                    // Update the address
                    string updateAddress = @"
                UPDATE address a
                JOIN customer c ON a.addressId = c.addressId
                SET a.address = @address, 
                    a.cityId = @cityId, 
                    a.postalCode = @postalCode, 
                    a.phone = @phone, 
                    a.lastUpdate = NOW(), 
                    a.lastUpdateBy = 'user'
                WHERE c.customerId = @customerId";

                    MySqlCommand addressCommand = new MySqlCommand(updateAddress, connection, transaction);
                    addressCommand.Parameters.AddWithValue("@address", UP_Address_TxtBx.Text);
                    addressCommand.Parameters.AddWithValue("@cityId", cityId);
                    addressCommand.Parameters.AddWithValue("@postalCode", ""); // Assuming postalCode can be empty or add a textbox for it
                    addressCommand.Parameters.AddWithValue("@phone", UP_Phone_Num_TxtBx.Text);
                    addressCommand.Parameters.AddWithValue("@customerId", selectedCustomerId);
                    addressCommand.ExecuteNonQuery();

                    // Update the customer's name
                    string updateCustomer = "UPDATE customer SET customerName = @customerName, lastUpdate = NOW(), lastUpdateBy = 'user' WHERE customerId = @customerId";
                    MySqlCommand customerCommand = new MySqlCommand(updateCustomer, connection, transaction);
                    customerCommand.Parameters.AddWithValue("@customerName", UP_Full_Name_TxtBx.Text);
                    customerCommand.Parameters.AddWithValue("@customerId", selectedCustomerId);
                    customerCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Customer details updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                catch (MySqlException ex)
                {
                    // Attempt to roll back the transaction
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (MySqlException exRollback)
                    {
                        MessageBox.Show("An error occurred while attempting to roll back the transaction: " + exRollback.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("An error occurred while updating customer details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            if (success)
            {
                this.Close(); // Close the Update_Customer form
                Main_Screen mainScreen = new Main_Screen(); // Open the Main_Screen form
                mainScreen.Show();
            }
            // Otherwise, the form stays open for the user to correct any issues and try saving again.
        }
    }
}