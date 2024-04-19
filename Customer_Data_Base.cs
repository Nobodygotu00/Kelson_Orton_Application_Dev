using System;
using MySql.Data.MySqlClient;

namespace Kelson_Orton_Application_Dev
{
    public class Customer_Data_Base
    {
        private readonly string _connectionString;

        public Customer_Data_Base(string host, string database, string username, string password)
        {
            _connectionString = $"Server={host};Database={database};Uid={username};Pwd={password};";
        }

        // This method assumes that 'address' table only requires address1, address2, city, state, and zipCode.
        public int InsertAddress(Customer_Add_Class customer)
        {
            int addressId = 0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = @"INSERT INTO address (address, address2, city, state, postalCode, phone) 
                  VALUES (@Address1, @Address2, @City, @State, @PostalCode, @Phone); 
                  SELECT LAST_INSERT_ID();";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Address1", customer.Address1);
                        command.Parameters.AddWithValue("@Address2", customer.Address2);
                        command.Parameters.AddWithValue("@City", customer.City);
                        command.Parameters.AddWithValue("@State", customer.State);
                        command.Parameters.AddWithValue("@PostalCode", customer.ZipCode);

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            addressId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while inserting the address: {ex.Message}", ex);
                }
            }
            return addressId;
        }

        public int GetUserIdByCustomerId(int customerId)
        {
            int userId = 0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "SELECT userId FROM appointment WHERE customerId = @CustomerId LIMIT 1;"; // Adjust according to your database schema

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("No user found for the given customer ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while getting the user ID by customer ID: {ex.Message}", ex);
                }
            }
            return userId;
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = "DELETE FROM customer WHERE customerId = @CustomerId;"; // Adjust according to your database schema

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("No customer found with the given ID, or the customer could not be deleted.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while deleting the customer: {ex.Message}", ex);
                }
            }
        }

        public void UpdateCustomer(int customerId, string fullName, string address1, string address2, string city, string state, string zipCode, string phoneNumber)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    var query = @"
                UPDATE customer c
                JOIN address a ON c.addressId = a.addressId
                SET c.customerName = @FullName,
                    a.address = @Address1,
                    a.address2 = @Address2,
                    a.city = @City, -- Ensure your schema supports this
                    a.state = @State, -- Ensure your schema supports this
                    a.postalCode = @ZipCode,
                    a.phone = @PhoneNumber
                WHERE c.customerId = @CustomerId;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Address1", address1);
                        command.Parameters.AddWithValue("@Address2", address2);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@State", state);
                        command.Parameters.AddWithValue("@ZipCode", zipCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while updating the customer: {ex.Message}", ex);
                }
            }
        }

        // This method inserts the customer using only the customerName and links the address via addressId.
        public void InsertCustomer(Customer_Add_Class customer, int addressId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = @"INSERT INTO customer (customerName, addressId) 
                                  VALUES (@CustomerName, @AddressId);";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        command.Parameters.AddWithValue("@AddressId", addressId);
                        command.Parameters.AddWithValue("@Phone", customer.PhoneNumber);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while inserting the customer: {ex.Message}", ex);
                }
            }
        }

        // Add other methods as needed, such as DeleteCustomer, UpdateCustomer, etc.
        // Make sure they align with the fields and requirements specified.
    }
}