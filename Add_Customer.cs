using System;
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
           
            if (string.IsNullOrWhiteSpace(Full_Name_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Address_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(City_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Country_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Phone_Num_TxtBx.Text))
            {
                MessageBox.Show("Please fill in all required fields: Full Name," +
                    " Address, City, Country, and Phone Number.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (SaveCustomer())
            {
              
                Main_Screen mainScreen = new Main_Screen();
                mainScreen.Show();
                this.Close();
            }
            else
            {
                
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

              
                var country = Country_TxtBx.Text;
                var city = City_TxtBx.Text;
                var address = Address_TxtBx.Text;
                var address2 = "";
                var customer = Full_Name_TxtBx.Text;
                var phone = Phone_Num_TxtBx.Text;

              
                string insertCountry = @"INSERT INTO Country (country, createDate,
                                       createdBy, lastUpdate, lastUpdateBy) 
                                 VALUES (@country, NOW(), 'user', NOW(), 'user')";
                MySqlCommand countryCommand = new MySqlCommand(insertCountry, Connection);
                countryCommand.Parameters.AddWithValue("@country", country);
                countryCommand.ExecuteNonQuery();
                int countryId = (int)countryCommand.LastInsertedId;

             
                string insertCity = @"INSERT INTO city (city, countryId,
                                    createDate, createdBy, lastUpdate, lastUpdateBy) 
                              VALUES (@city, @countryId, NOW(), 'user', NOW(), 'user')";
                MySqlCommand cityCommand = new MySqlCommand(insertCity, Connection);
                cityCommand.Parameters.AddWithValue("@city", city);
                cityCommand.Parameters.AddWithValue("@countryId", countryId);
                cityCommand.ExecuteNonQuery();
                int cityId = (int)cityCommand.LastInsertedId;

               
                string insertAddress = @"INSERT INTO address (address, address2,
                                       cityId, postalCode, phone, createDate,
                                       createdBy, lastUpdate, lastUpdateBy)
                                 VALUES (@address, @address2, @cityId, '', @phone,
                                       NOW(), 'user', NOW(), 'user')";
                MySqlCommand addressCommand = new MySqlCommand(insertAddress, Connection);
                addressCommand.Parameters.AddWithValue("@address", address);
                addressCommand.Parameters.AddWithValue("@address2", address2);
                addressCommand.Parameters.AddWithValue("@cityId", cityId);
                addressCommand.Parameters.AddWithValue("@phone", phone);
                addressCommand.ExecuteNonQuery();
                int addressId = (int)addressCommand.LastInsertedId;

           
                string insertCustomer = @"INSERT INTO customer (customerName,
                                        addressId, active, createDate,
                                        createdBy, lastUpdate, lastUpdateBy) 
                                  VALUES (@customerName, @addressId, 1, NOW(), 'user', NOW(), 'user')";
                MySqlCommand customerCommand = new MySqlCommand(insertCustomer, Connection);
                customerCommand.Parameters.AddWithValue("@customerName", customer);
                customerCommand.Parameters.AddWithValue("@addressId", addressId);
                customerCommand.ExecuteNonQuery();

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
       
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-')
            {
       
                int hyphenCount = (sender as TextBox).Text.Count(c => c == '-');
                if (hyphenCount >= 2 || (sender as TextBox).Text.EndsWith("-"))
                {
                    e.Handled = true;
                }
            }
        }

     //   private void Zip_Code_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
     //   {
     //    
     //      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
     //       {
     //           e.Handled = true;
     //       }
     //   }
    }
}