namespace Kelson_Orton_Application_Dev
{
    partial class Schedule_Appointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Schedule_Appointment_Add_Button = new System.Windows.Forms.Button();
            this.Schedule_Appointment_Update_Button = new System.Windows.Forms.Button();
            this.Schedule_Appointment_Delete_Button = new System.Windows.Forms.Button();
            this.Schedule_Appointment_Return_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // Schedule_Appointment_Add_Button
            // 
            this.Schedule_Appointment_Add_Button.Location = new System.Drawing.Point(170, 192);
            this.Schedule_Appointment_Add_Button.Name = "Schedule_Appointment_Add_Button";
            this.Schedule_Appointment_Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Schedule_Appointment_Add_Button.TabIndex = 2;
            this.Schedule_Appointment_Add_Button.Text = "Add";
            this.Schedule_Appointment_Add_Button.UseVisualStyleBackColor = true;
            this.Schedule_Appointment_Add_Button.Click += new System.EventHandler(this.Schedule_Appointment_Add_Button_Click);
            // 
            // Schedule_Appointment_Update_Button
            // 
            this.Schedule_Appointment_Update_Button.Location = new System.Drawing.Point(89, 192);
            this.Schedule_Appointment_Update_Button.Name = "Schedule_Appointment_Update_Button";
            this.Schedule_Appointment_Update_Button.Size = new System.Drawing.Size(75, 23);
            this.Schedule_Appointment_Update_Button.TabIndex = 3;
            this.Schedule_Appointment_Update_Button.Text = "Update";
            this.Schedule_Appointment_Update_Button.UseVisualStyleBackColor = true;
            this.Schedule_Appointment_Update_Button.Click += new System.EventHandler(this.Schedule_Appointment_Update_Button_Click);
            // 
            // Schedule_Appointment_Delete_Button
            // 
            this.Schedule_Appointment_Delete_Button.Location = new System.Drawing.Point(170, 221);
            this.Schedule_Appointment_Delete_Button.Name = "Schedule_Appointment_Delete_Button";
            this.Schedule_Appointment_Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Schedule_Appointment_Delete_Button.TabIndex = 4;
            this.Schedule_Appointment_Delete_Button.Text = "Delete";
            this.Schedule_Appointment_Delete_Button.UseVisualStyleBackColor = true;
            // 
            // Schedule_Appointment_Return_Button
            // 
            this.Schedule_Appointment_Return_Button.Location = new System.Drawing.Point(170, 250);
            this.Schedule_Appointment_Return_Button.Name = "Schedule_Appointment_Return_Button";
            this.Schedule_Appointment_Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Schedule_Appointment_Return_Button.TabIndex = 5;
            this.Schedule_Appointment_Return_Button.Text = "Return";
            this.Schedule_Appointment_Return_Button.UseVisualStyleBackColor = true;
            this.Schedule_Appointment_Return_Button.Click += new System.EventHandler(this.Schedule_Appointment_Return_Button_Click);
            // 
            // Schedule_Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 282);
            this.Controls.Add(this.Schedule_Appointment_Return_Button);
            this.Controls.Add(this.Schedule_Appointment_Delete_Button);
            this.Controls.Add(this.Schedule_Appointment_Update_Button);
            this.Controls.Add(this.Schedule_Appointment_Add_Button);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Schedule_Appointment";
            this.Text = "Schedule Appointment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button Schedule_Appointment_Add_Button;
        private System.Windows.Forms.Button Schedule_Appointment_Update_Button;
        private System.Windows.Forms.Button Schedule_Appointment_Delete_Button;
        private System.Windows.Forms.Button Schedule_Appointment_Return_Button;
    }
}