using MySql.Data.MySqlClient;
using System;

namespace Kelson_Orton_Application_Dev
{
    public class Customer_Add_Class
    {
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public Customer_Add_Class() { }

        public Customer_Add_Class(string customerName, string address1, 
            string address2, string city, string state, string zipCode, 
            string phoneNumber)
        {
            CustomerName = customerName.Trim();
            Address1 = address1.Trim();
            Address2 = address2?.Trim();
            City = city.Trim();
            State = state.Trim();
            ZipCode = zipCode.Trim();
            PhoneNumber = phoneNumber.Trim();
        }

        public void AddCustomer(Customer_Add_Class customer, string _connectionString)
        {
            if (string.IsNullOrWhiteSpace(customer.CustomerName) ||
                string.IsNullOrWhiteSpace(customer.Address1) ||
                string.IsNullOrWhiteSpace(customer.Address2) || 
                string.IsNullOrWhiteSpace(customer.City) ||
                string.IsNullOrWhiteSpace(customer.State) ||
                string.IsNullOrWhiteSpace(customer.ZipCode) ||
                string.IsNullOrWhiteSpace(customer.PhoneNumber))
            {
                throw new ArgumentException("All fields must be filled out.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(customer.PhoneNumber, @"^[0-9-]+$"))
            {
                throw new FormatException("Phone number must contain only digits and dashes.");
            }

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        var addressQuery = @"INSERT INTO address (address, address2, cityId, postalCode, phone) 
                                             VALUES (@Address1, @Address2, (SELECT cityId FROM city WHERE city = @City AND state = @State LIMIT 1), @PostalCode, @Phone); 
                                             SELECT LAST_INSERT_ID();";

                        using (var addressCommand = new MySqlCommand(addressQuery, connection))
                        {
                            addressCommand.Transaction = transaction;
                            addressCommand.Parameters.AddWithValue("@Address1", customer.Address1);
                            addressCommand.Parameters.AddWithValue("@Address2", customer.Address2);
                            addressCommand.Parameters.AddWithValue("@City", customer.City);
                            addressCommand.Parameters.AddWithValue("@State", customer.State);
                            addressCommand.Parameters.AddWithValue("@PostalCode", customer.ZipCode);
                            addressCommand.Parameters.AddWithValue("@Phone", customer.PhoneNumber);


                            var addressId = Convert.ToInt32(addressCommand.ExecuteScalar());

                            if (addressId > 0)
                            {
                                var customerQuery = @"INSERT INTO customer (customerName, addressId) 
                                                      VALUES (@CustomerName, @AddressId);";

                                using (var customerCommand = new MySqlCommand(customerQuery, connection))
                                {
                                    customerCommand.Transaction = transaction;
                                    customerCommand.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                                    customerCommand.Parameters.AddWithValue("@AddressId", addressId);
                                    customerCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception($"An error occurred while adding the customer: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}", ex);
            }
        }
    }
}