using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace Kelson_Orton_Application_Dev
{
    public partial class Form1 : Form
    {
        private ResourceManager resourceManager;
        private string connectionString = "server=localhost;port=3306;database=client_schedule;uid=root;pwd=Passw0rd!;";
        private string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Kelson_Orton_Application_Dev");

        public Form1()
        {
          
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            CultureInfo currentCulture = CultureInfo.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;
            if (currentCulture.TwoLetterISOLanguageName == "de")
            {
                resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources.de", typeof(Form1).Assembly);
            }
            else
            {
                resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources", typeof(Form1).Assembly);
            }
            InitializeComponent();
            resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources", typeof(Form1).Assembly);
            EnsureDirectoryExists();
        }

        private void EnsureDirectoryExists()
        {
            string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Kelson_Orton_Application_Dev");

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login_Username_Label.Text = resourceManager.GetString("Login_Username_Label", CultureInfo.CurrentUICulture);
            Login_Password_Label.Text = resourceManager.GetString("Login_Password_Label", CultureInfo.CurrentUICulture);
            Login_Button.Text = resourceManager.GetString("Login_Button", CultureInfo.CurrentUICulture);
        }

        private int VerifyCredentials(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT userId FROM user WHERE userName = @username AND password = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        LogToFile("Login successful for user: " + username);
                        return Convert.ToInt32(result);
                    }
                    LogToFile("Failed login attempt for user: " + username);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred during login: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogToFile("Exception during login for user: " + username + " | Error: " + ex.Message);
                }
            }
            return -1;
        }

        private void LogToFile(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(logPath, "LoginLog.txt"), true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to log file: " + ex.Message);
            }
        }

        private void Login_Button_Click_1(object sender, EventArgs e)
        {
            string username = Login_Username_TxtBx.Text;
            string password = Login_Password_TxtBx.Text;

            int userId = VerifyCredentials(username, password);
            if (userId > 0)
            {
                this.Hide();
                Main_Screen mainScreen = new Main_Screen();
                mainScreen.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Username_Label_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void Login_Password_Label_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void Login_Username_TxtBx_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void Login_Password_TxtBx_TextChanged(object sender, EventArgs e)
        {
            // Placeholder
        }
    }
}