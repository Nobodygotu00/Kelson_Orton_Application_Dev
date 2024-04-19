﻿using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public partial class Add_Customer : Form
    {
        public Add_Customer()
        {
            InitializeComponent();
            ID_TxtBx.ReadOnly = true;

            // Attach event handlers
            Phone_Num_TxtBx.KeyPress += Phone_Num_TxtBx_KeyPress;
        }

        private void Add_Cu_Cancel_Click(object sender, EventArgs e)
        {
            Main_Screen mainScreen = new Main_Screen();
            mainScreen.Show();
            this.Close();
        }

        private void Add_Cu_Save_Click(object sender, EventArgs e)
        {
            // Validate input before saving
            if (string.IsNullOrWhiteSpace(Full_Name_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Address_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(City_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Country_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Phone_Num_TxtBx.Text))
            {
                MessageBox.Show("Please fill in all required fields: Full Name," +
                    " Address, City, Country, and Phone Number.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the save process if any field is empty
            }

            // If validation passes, attempt to save the customer
            if (SaveCustomer())
            {
                // If SaveCustomer returns true, the customer was saved successfully
                MessageBox.Show("Customer saved successfully!");

                // Open the 'Main_Screen' form and close the current form
                Main_Screen mainScreen = new Main_Screen();
                mainScreen.Show();
                this.Close();
            }
            else
            {
                // If SaveCustomer returns false, an error occurred
                MessageBox.Show("An error occurred while saving the customer.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveCustomer()
        {
            string Connection_String = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            MySqlConnection Connection = new MySqlConnection(Connection_String);
            bool success = false;

            try
            {
                Connection.Open();

                // Get values from form fields
                var country = Country_TxtBx.Text;
                var city = City_TxtBx.Text;
                var address = Address_TxtBx.Text;
                var address2 = ""; // Set this to an appropriate value or leave empty if it's optional
                var customer = Full_Name_TxtBx.Text;
                var phone = Phone_Num_TxtBx.Text;

                // Insert country
                string insertCountry = @"INSERT INTO Country (country, createDate,
                                       createdBy, lastUpdate, lastUpdateBy) 
                                 VALUES (@country, NOW(), 'user', NOW(), 'user')";
                MySqlCommand countryCommand = new MySqlCommand(insertCountry, Connection);
                countryCommand.Parameters.AddWithValue("@country", country);
                countryCommand.ExecuteNonQuery();
                int countryId = (int)countryCommand.LastInsertedId;

                // Insert city
                string insertCity = @"INSERT INTO city (city, countryId,
                                    createDate, createdBy, lastUpdate, lastUpdateBy) 
                              VALUES (@city, @countryId, NOW(), 'user', NOW(), 'user')";
                MySqlCommand cityCommand = new MySqlCommand(insertCity, Connection);
                cityCommand.Parameters.AddWithValue("@city", city);
                cityCommand.Parameters.AddWithValue("@countryId", countryId);
                cityCommand.ExecuteNonQuery();
                int cityId = (int)cityCommand.LastInsertedId;

                // Insert address
                string insertAddress = @"INSERT INTO address (address, address2,
                                       cityId, postalCode, phone, createDate,
                                       createdBy, lastUpdate, lastUpdateBy)
                                 VALUES (@address, @address2, @cityId, '', @phone,
                                       NOW(), 'user', NOW(), 'user')"; // Assuming postalCode can be empty
                MySqlCommand addressCommand = new MySqlCommand(insertAddress, Connection);
                addressCommand.Parameters.AddWithValue("@address", address);
                addressCommand.Parameters.AddWithValue("@address2", address2); // If this is optional, it can be an empty string
                addressCommand.Parameters.AddWithValue("@cityId", cityId);
                addressCommand.Parameters.AddWithValue("@phone", phone);
                addressCommand.ExecuteNonQuery();
                int addressId = (int)addressCommand.LastInsertedId;

                // Insert customer
                string insertCustomer = @"INSERT INTO customer (customerName,
                                        addressId, active, createDate,
                                        createdBy, lastUpdate, lastUpdateBy) 
                                  VALUES (@customerName, @addressId, 1, NOW(), 'user', NOW(), 'user')"; // Assuming the 'active' column is a boolean and the customer should be active
                MySqlCommand customerCommand = new MySqlCommand(insertCustomer, Connection);
                customerCommand.Parameters.AddWithValue("@customerName", customer);
                customerCommand.Parameters.AddWithValue("@addressId", addressId);
                customerCommand.ExecuteNonQuery();
                // If Id need new customer's ID for something, uncomment the line below
                // int customerId = (int)customerCommand.LastInsertedId;

                MessageBox.Show("Customer saved successfully!");
                success = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred while saving the customer: " + ex.Message);
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }

            return success;
        }

        private void Phone_Num_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and hyphen
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-')
            {
                // Allow only up to two hyphens
                int hyphenCount = (sender as TextBox).Text.Count(c => c == '-');
                if (hyphenCount >= 2 || (sender as TextBox).Text.EndsWith("-"))
                {
                    e.Handled = true;
                }
            }
        }

        private void Zip_Code_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}