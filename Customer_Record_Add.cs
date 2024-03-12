using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelson_Orton_Application_Dev
{
    public partial class Customer_Record_Add : Form
    {
        private Customer_Record _customerRecordForm;
        public Customer_Record_Add(Customer_Record customerRecordForm)
        {
            InitializeComponent();
            _customerRecordForm = customerRecordForm;
            Customer_Record_Add_Phone_Number_TxtBx.KeyPress += Customer_Record_Add_Phone_Number_TxtBx_KeyPress;
        }
        private void Customer_Record_Add_Phone_Number_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit or a control character (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not, then ignore this key press by setting Handled to true
                e.Handled = true;
            }
        }
        private void Customer_Record_Add_Save_Button_Click(object sender, EventArgs e)
        {
            // Validate input (make sure text boxes are not empty, etc.)
            if (string.IsNullOrWhiteSpace(Customer_Record_Add_Name_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Customer_Record_Add_Address_TxtBx.Text) ||
                string.IsNullOrWhiteSpace(Customer_Record_Add_Phone_Number_TxtBx.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rowIndex = _customerRecordForm.Customer_Record_DaGrVi.Rows.Add();
            var newRow = _customerRecordForm.Customer_Record_DaGrVi.Rows[rowIndex];

            // Set cell values for the new row
            newRow.Cells["Full Name"].Value = Customer_Record_Add_Name_TxtBx.Text;
            newRow.Cells["Address"].Value = Customer_Record_Add_Address_TxtBx.Text;
            newRow.Cells["Phone Number"].Value = Customer_Record_Add_Phone_Number_TxtBx.Text;

            // clear the text boxes after adding the new row
            Customer_Record_Add_Name_TxtBx.Text = "";
            Customer_Record_Add_Address_TxtBx.Text = "";
            Customer_Record_Add_Phone_Number_TxtBx.Text = "";

            MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Customer_Record_Add_Cancel_Button_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();

            // Check if the instance of Customer_Record is still open/exists and show it
            if (_customerRecordForm != null && !_customerRecordForm.IsDisposed)
            {
                _customerRecordForm.Show();
            }
            else
            {
                // The reference is null or the form is disposed, create a new instance and show it
                _customerRecordForm = new Customer_Record();
                _customerRecordForm.Show();
            }
        }
    }
}
