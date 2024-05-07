namespace Kelson_Orton_Application_Dev
{
    partial class Add_Appointment
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
            this.Add_Save_Button = new System.Windows.Forms.Button();
            this.Add_Cancel_Button = new System.Windows.Forms.Button();
            this.Type_Label = new System.Windows.Forms.Label();
            this.Lunch_Apt_RB = new System.Windows.Forms.RadioButton();
            this.Group_Meet_RB = new System.Windows.Forms.RadioButton();
            this.Interview_RB = new System.Windows.Forms.RadioButton();
            this.Meeting_RB = new System.Windows.Forms.RadioButton();
            this.Start_Date_Label = new System.Windows.Forms.Label();
            this.End_Date_Label = new System.Windows.Forms.Label();
            this.Start_Date_DTP = new System.Windows.Forms.DateTimePicker();
            this.Apt_RB_Panel = new System.Windows.Forms.Panel();
            this.Start_Date_CB = new System.Windows.Forms.ComboBox();
            this.End_Date_CB = new System.Windows.Forms.ComboBox();
            this.Add_User_ID_TxtBx = new System.Windows.Forms.TextBox();
            this.Add_User_ID_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Apt_RB_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add_Save_Button
            // 
            this.Add_Save_Button.Location = new System.Drawing.Point(194, 136);
            this.Add_Save_Button.Name = "Add_Save_Button";
            this.Add_Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Save_Button.TabIndex = 14;
            this.Add_Save_Button.Text = "Save";
            this.Add_Save_Button.UseVisualStyleBackColor = true;
            this.Add_Save_Button.Click += new System.EventHandler(this.Add_Save_Button_Click);
            // 
            // Add_Cancel_Button
            // 
            this.Add_Cancel_Button.Location = new System.Drawing.Point(275, 136);
            this.Add_Cancel_Button.Name = "Add_Cancel_Button";
            this.Add_Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Cancel_Button.TabIndex = 15;
            this.Add_Cancel_Button.Text = "Cancel";
            this.Add_Cancel_Button.UseVisualStyleBackColor = true;
            this.Add_Cancel_Button.Click += new System.EventHandler(this.Add_Cancel_Button_Click);
            // 
            // Type_Label
            // 
            this.Type_Label.AutoSize = true;
            this.Type_Label.Location = new System.Drawing.Point(12, 50);
            this.Type_Label.Name = "Type_Label";
            this.Type_Label.Size = new System.Drawing.Size(99, 13);
            this.Type_Label.TabIndex = 20;
            this.Type_Label.Text = "Appointment Type: ";
            // 
            // Lunch_Apt_RB
            // 
            this.Lunch_Apt_RB.AutoSize = true;
            this.Lunch_Apt_RB.Location = new System.Drawing.Point(3, 3);
            this.Lunch_Apt_RB.Name = "Lunch_Apt_RB";
            this.Lunch_Apt_RB.Size = new System.Drawing.Size(55, 17);
            this.Lunch_Apt_RB.TabIndex = 21;
            this.Lunch_Apt_RB.TabStop = true;
            this.Lunch_Apt_RB.Text = "Lunch";
            this.Lunch_Apt_RB.UseVisualStyleBackColor = true;
            // 
            // Group_Meet_RB
            // 
            this.Group_Meet_RB.AutoSize = true;
            this.Group_Meet_RB.Location = new System.Drawing.Point(3, 72);
            this.Group_Meet_RB.Name = "Group_Meet_RB";
            this.Group_Meet_RB.Size = new System.Drawing.Size(81, 17);
            this.Group_Meet_RB.TabIndex = 22;
            this.Group_Meet_RB.TabStop = true;
            this.Group_Meet_RB.Text = "Group Meet";
            this.Group_Meet_RB.UseVisualStyleBackColor = true;
            // 
            // Interview_RB
            // 
            this.Interview_RB.AutoSize = true;
            this.Interview_RB.Location = new System.Drawing.Point(3, 26);
            this.Interview_RB.Name = "Interview_RB";
            this.Interview_RB.Size = new System.Drawing.Size(68, 17);
            this.Interview_RB.TabIndex = 22;
            this.Interview_RB.TabStop = true;
            this.Interview_RB.Text = "Interview";
            this.Interview_RB.UseVisualStyleBackColor = true;
            // 
            // Meeting_RB
            // 
            this.Meeting_RB.AutoSize = true;
            this.Meeting_RB.Location = new System.Drawing.Point(3, 49);
            this.Meeting_RB.Name = "Meeting_RB";
            this.Meeting_RB.Size = new System.Drawing.Size(63, 17);
            this.Meeting_RB.TabIndex = 23;
            this.Meeting_RB.TabStop = true;
            this.Meeting_RB.Text = "Meeting";
            this.Meeting_RB.UseVisualStyleBackColor = true;
            // 
            // Start_Date_Label
            // 
            this.Start_Date_Label.AutoSize = true;
            this.Start_Date_Label.Location = new System.Drawing.Point(150, 9);
            this.Start_Date_Label.Name = "Start_Date_Label";
            this.Start_Date_Label.Size = new System.Drawing.Size(95, 13);
            this.Start_Date_Label.TabIndex = 24;
            this.Start_Date_Label.Text = "Appointment Date:";
            // 
            // End_Date_Label
            // 
            this.End_Date_Label.AutoSize = true;
            this.End_Date_Label.Location = new System.Drawing.Point(150, 93);
            this.End_Date_Label.Name = "End_Date_Label";
            this.End_Date_Label.Size = new System.Drawing.Size(55, 13);
            this.End_Date_Label.TabIndex = 25;
            this.End_Date_Label.Text = "End Time:";
            // 
            // Start_Date_DTP
            // 
            this.Start_Date_DTP.Location = new System.Drawing.Point(150, 25);
            this.Start_Date_DTP.Name = "Start_Date_DTP";
            this.Start_Date_DTP.Size = new System.Drawing.Size(200, 20);
            this.Start_Date_DTP.TabIndex = 26;
            // 
            // Apt_RB_Panel
            // 
            this.Apt_RB_Panel.Controls.Add(this.Lunch_Apt_RB);
            this.Apt_RB_Panel.Controls.Add(this.Group_Meet_RB);
            this.Apt_RB_Panel.Controls.Add(this.Interview_RB);
            this.Apt_RB_Panel.Controls.Add(this.Meeting_RB);
            this.Apt_RB_Panel.Location = new System.Drawing.Point(12, 66);
            this.Apt_RB_Panel.Name = "Apt_RB_Panel";
            this.Apt_RB_Panel.Size = new System.Drawing.Size(99, 105);
            this.Apt_RB_Panel.TabIndex = 28;
            // 
            // Start_Date_CB
            // 
            this.Start_Date_CB.FormattingEnabled = true;
            this.Start_Date_CB.Location = new System.Drawing.Point(151, 69);
            this.Start_Date_CB.Name = "Start_Date_CB";
            this.Start_Date_CB.Size = new System.Drawing.Size(199, 21);
            this.Start_Date_CB.TabIndex = 29;
            // 
            // End_Date_CB
            // 
            this.End_Date_CB.FormattingEnabled = true;
            this.End_Date_CB.Location = new System.Drawing.Point(151, 109);
            this.End_Date_CB.Name = "End_Date_CB";
            this.End_Date_CB.Size = new System.Drawing.Size(199, 21);
            this.End_Date_CB.TabIndex = 30;
            // 
            // Add_User_ID_TxtBx
            // 
            this.Add_User_ID_TxtBx.Location = new System.Drawing.Point(12, 25);
            this.Add_User_ID_TxtBx.Name = "Add_User_ID_TxtBx";
            this.Add_User_ID_TxtBx.ReadOnly = true;
            this.Add_User_ID_TxtBx.Size = new System.Drawing.Size(100, 20);
            this.Add_User_ID_TxtBx.TabIndex = 32;
            // 
            // Add_User_ID_Label
            // 
            this.Add_User_ID_Label.AutoSize = true;
            this.Add_User_ID_Label.Location = new System.Drawing.Point(12, 9);
            this.Add_User_ID_Label.Name = "Add_User_ID_Label";
            this.Add_User_ID_Label.Size = new System.Drawing.Size(46, 13);
            this.Add_User_ID_Label.TabIndex = 31;
            this.Add_User_ID_Label.Text = "User ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Start Time:";
            // 
            // Add_Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Add_User_ID_TxtBx);
            this.Controls.Add(this.Add_User_ID_Label);
            this.Controls.Add(this.End_Date_CB);
            this.Controls.Add(this.Start_Date_CB);
            this.Controls.Add(this.Apt_RB_Panel);
            this.Controls.Add(this.Start_Date_DTP);
            this.Controls.Add(this.End_Date_Label);
            this.Controls.Add(this.Start_Date_Label);
            this.Controls.Add(this.Type_Label);
            this.Controls.Add(this.Add_Cancel_Button);
            this.Controls.Add(this.Add_Save_Button);
            this.Name = "Add_Appointment";
            this.Text = "Add Appointment";
            this.Apt_RB_Panel.ResumeLayout(false);
            this.Apt_RB_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Add_Save_Button;
        private System.Windows.Forms.Button Add_Cancel_Button;
        private System.Windows.Forms.Label Type_Label;
        private System.Windows.Forms.RadioButton Lunch_Apt_RB;
        private System.Windows.Forms.RadioButton Group_Meet_RB;
        private System.Windows.Forms.RadioButton Interview_RB;
        private System.Windows.Forms.RadioButton Meeting_RB;
        private System.Windows.Forms.Label Start_Date_Label;
        private System.Windows.Forms.Label End_Date_Label;
        private System.Windows.Forms.DateTimePicker Start_Date_DTP;
        private System.Windows.Forms.Panel Apt_RB_Panel;
        private System.Windows.Forms.ComboBox Start_Date_CB;
        private System.Windows.Forms.ComboBox End_Date_CB;
        private System.Windows.Forms.TextBox Add_User_ID_TxtBx;
        private System.Windows.Forms.Label Add_User_ID_Label;
        private System.Windows.Forms.Label label1;
    }
}