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
    public partial class Customer_Record_Update : Form
    {
        public Customer_Record_Update()
        {
            InitializeComponent(string fullName, string address, string phoneNumber);
            Update_Name_TxtBx.Text = fullName;
            Update_Address_TxtBx.Text = address;
            Update_Phone_Number_TxtBx.Text = phoneNumber;
        }

        private void Customer_Record_Update_Save_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
