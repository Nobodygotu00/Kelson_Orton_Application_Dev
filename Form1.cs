using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;
using System.Configuration;

namespace Kelson_Orton_Application_Dev
{
    public partial class Form1 : Form
    {
        private ResourceManager resourceManager;
        private CultureInfo currentCulture;
        private string connectionString = "server=localhost;port=3306;database=client_schedule;uid=root;pwd=Passw0rd!;";
        private string logPath = "LoginLogs";
        public int Logged_In_User_Id { get; set; }

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

        private void AdjustAppointmentTimes()
        {            
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
        }

        private void SetUserLocale()
        {
            
            currentCulture = CultureInfo.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            // Load the appropriate resource file based on the user's locale
            if (currentCulture.Name == "de-DE")
            {
                resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources.de", typeof(Form1).Assembly);
            }
            else
            {
                resourceManager = new ResourceManager("Kelson_Orton_Application_Dev.Resources", typeof(Form1).Assembly);
            }
        }

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUserLocale();
            AdjustAppointmentTimes();

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
                        int userId = Convert.ToInt32(result);
                        LogToFile("Login successful for user: " + username);
                        return userId; 
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
                string logFilePath = Path.Combine(logPath, "LoginLog.txt");

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to write to log file: " + ex.Message);
            }
        }

        public static void CheckForUpcomingAppointments(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Localdb"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                DateTime now = DateTime.Now;
                DateTime alertTime = now.AddMinutes(15);

                string query = @"
            SELECT COUNT(*) 
            FROM appointment 
            WHERE userId = @userId 
            AND start BETWEEN @now AND @alertTime";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@now", now);
                command.Parameters.AddWithValue("@alertTime", alertTime);

                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("You have an appointment within the next 15 minutes.", "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                Logged_In_User_Id = userId;
                Main_Screen mainScreen = new Main_Screen();
                mainScreen.Show();
                LogToFile($"Login successful for user: {username}");

                
                AdjustAppointmentTimes();

                
                Appointment.CheckForUpcomingAppointments(userId);
            }
            else
            {
                string errorMessage = resourceManager.GetString("Login_Error_Message");
                MessageBox.Show(errorMessage, resourceManager.GetString("Login_Failed"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogToFile($"Failed login attempt for user: {username}");
            }
        }


        void Login_Username_Label_Click(object sender, EventArgs e)
        {
            
        }

        void Login_Password_Label_Click(object sender, EventArgs e)
        {
            
        }

        void Login_Username_TxtBx_TextChanged(object sender, EventArgs e)
        {
            
        }

        void Login_Password_TxtBx_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}