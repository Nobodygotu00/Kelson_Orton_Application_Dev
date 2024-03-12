using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using MySql.Data.MySqlClient;



namespace Kelson_Orton_Application_Dev
{
    public partial class Form1 : Form
    {
        private ResourceManager resourceManager;
        private string connectionString = "server=your_server;database=your_database;uid=your_username;pwd=your_password;";
        public Form1()
        {
            InitializeComponent();
            resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources", typeof(Form1).Assembly);
            
            // Change from english to german
            //CultureInfo.CurrentUICulture = new CultureInfo("de-DE");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Login_Username_Label.Text = resourceManager.GetString("Login_Username_Label", CultureInfo.CurrentUICulture);
            Login_Password_Label.Text = resourceManager.GetString("Login_Password_Label", CultureInfo.CurrentUICulture);
            Login_Login_Button.Text = resourceManager.GetString("Login_Login_Button", CultureInfo.CurrentUICulture);
        }

        private void Login_Login_Button_Click(object sender, EventArgs e)
        {
            string username = Login_Username_TxtBx.Text;
            string password = Login_Password_TxtBx.Text;

            // Verify the credentials
            if (VerifyCredentials(username, password))
            {
                // Credentials are correct, close Form1
                this.Hide();

                // Open Main_Screen
                Main_Screen mainScreen = new Main_Screen();
                mainScreen.Show();
            }
            else
            {
                // Credentials are incorrect, show an error message
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerifyCredentials(string username, string password)
        {
            // undo comment bellow to compare login with username and password
            // return username == "user" && password == "pass";

            // Remove return true; after undoing comment above
            return true;

        }
    }
}