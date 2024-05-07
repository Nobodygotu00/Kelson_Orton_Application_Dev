namespace Kelson_Orton_Application_Dev
{
    partial class Update_Appointment
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
            this.Start_Date_DTP = new System.Windows.Forms.DateTimePicker();
            this.Start_Date_Label = new System.Windows.Forms.Label();
            this.Ud_Meeting_RB = new System.Windows.Forms.RadioButton();
            this.Ud_Interview_RB = new System.Windows.Forms.RadioButton();
            this.Ud_Group_Meet_RB = new System.Windows.Forms.RadioButton();
            this.Ud_Lunch_Apt_RB = new System.Windows.Forms.RadioButton();
            this.Type_Label = new System.Windows.Forms.Label();
            this.Update_Cancel_Button = new System.Windows.Forms.Button();
            this.Add_Save_Button = new System.Windows.Forms.Button();
            this.Ud_Panel = new System.Windows.Forms.Panel();
            this.End_Date_Label = new System.Windows.Forms.Label();
            this.Ud_End_Date_CB = new System.Windows.Forms.ComboBox();
            this.Ud_Start_Date_CB = new System.Windows.Forms.ComboBox();
            this.Up_User_ID_TxtBx = new System.Windows.Forms.TextBox();
            this.Up_User_ID_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ud_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_Date_DTP
            // 
            this.Start_Date_DTP.Location = new System.Drawing.Point(150, 25);
            this.Start_Date_DTP.Name = "Start_Date_DTP";
            this.Start_Date_DTP.Size = new System.Drawing.Size(200, 20);
            this.Start_Date_DTP.TabIndex = 41;
            // 
            // Start_Date_Label
            // 
            this.Start_Date_Label.AutoSize = true;
            this.Start_Date_Label.Location = new System.Drawing.Point(147, 9);
            this.Start_Date_Label.Name = "Start_Date_Label";
            this.Start_Date_Label.Size = new System.Drawing.Size(95, 13);
            this.Start_Date_Label.TabIndex = 39;
            this.Start_Date_Label.Text = "Appointment Date:";
            // 
            // Ud_Meeting_RB
            // 
            this.Ud_Meeting_RB.AutoSize = true;
            this.Ud_Meeting_RB.Location = new System.Drawing.Point(3, 49);
            this.Ud_Meeting_RB.Name = "Ud_Meeting_RB";
            this.Ud_Meeting_RB.Size = new System.Drawing.Size(63, 17);
            this.Ud_Meeting_RB.TabIndex = 38;
            this.Ud_Meeting_RB.TabStop = true;
            this.Ud_Meeting_RB.Text = "Meeting";
            this.Ud_Meeting_RB.UseVisualStyleBackColor = true;
            // 
            // Ud_Interview_RB
            // 
            this.Ud_Interview_RB.AutoSize = true;
            this.Ud_Interview_RB.Location = new System.Drawing.Point(3, 26);
            this.Ud_Interview_RB.Name = "Ud_Interview_RB";
            this.Ud_Interview_RB.Size = new System.Drawing.Size(68, 17);
            this.Ud_Interview_RB.TabIndex = 36;
            this.Ud_Interview_RB.TabStop = true;
            this.Ud_Interview_RB.Text = "Interview";
            this.Ud_Interview_RB.UseVisualStyleBackColor = true;
            // 
            // Ud_Group_Meet_RB
            // 
            this.Ud_Group_Meet_RB.AutoSize = true;
            this.Ud_Group_Meet_RB.Location = new System.Drawing.Point(3, 72);
            this.Ud_Group_Meet_RB.Name = "Ud_Group_Meet_RB";
            this.Ud_Group_Meet_RB.Size = new System.Drawing.Size(81, 17);
            this.Ud_Group_Meet_RB.TabIndex = 37;
            this.Ud_Group_Meet_RB.TabStop = true;
            this.Ud_Group_Meet_RB.Text = "Group Meet";
            this.Ud_Group_Meet_RB.UseVisualStyleBackColor = true;
            // 
            // Ud_Lunch_Apt_RB
            // 
            this.Ud_Lunch_Apt_RB.AutoSize = true;
            this.Ud_Lunch_Apt_RB.Location = new System.Drawing.Point(3, 3);
            this.Ud_Lunch_Apt_RB.Name = "Ud_Lunch_Apt_RB";
            this.Ud_Lunch_Apt_RB.Size = new System.Drawing.Size(55, 17);
            this.Ud_Lunch_Apt_RB.TabIndex = 35;
            this.Ud_Lunch_Apt_RB.TabStop = true;
            this.Ud_Lunch_Apt_RB.Text = "Lunch";
            this.Ud_Lunch_Apt_RB.UseVisualStyleBackColor = true;
            // 
            // Type_Label
            // 
            this.Type_Label.AutoSize = true;
            this.Type_Label.Location = new System.Drawing.Point(12, 51);
            this.Type_Label.Name = "Type_Label";
            this.Type_Label.Size = new System.Drawing.Size(96, 13);
            this.Type_Label.TabIndex = 34;
            this.Type_Label.Text = "Appointment Type:";
            // 
            // Update_Cancel_Button
            // 
            this.Update_Cancel_Button.Location = new System.Drawing.Point(275, 136);
            this.Update_Cancel_Button.Name = "Update_Cancel_Button";
            this.Update_Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Update_Cancel_Button.TabIndex = 29;
            this.Update_Cancel_Button.Text = "Cancel";
            this.Update_Cancel_Button.UseVisualStyleBackColor = true;
            this.Update_Cancel_Button.Click += new System.EventHandler(this.Add_Cancel_Button_Click);
            // 
            // Add_Save_Button
            // 
            this.Add_Save_Button.Location = new System.Drawing.Point(194, 136);
            this.Add_Save_Button.Name = "Add_Save_Button";
            this.Add_Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Add_Save_Button.TabIndex = 28;
            this.Add_Save_Button.Text = "Save";
            this.Add_Save_Button.UseVisualStyleBackColor = true;
            this.Add_Save_Button.Click += new System.EventHandler(this.Update_Save_Button_Click);
            // 
            // Ud_Panel
            // 
            this.Ud_Panel.Controls.Add(this.Ud_Meeting_RB);
            this.Ud_Panel.Controls.Add(this.Ud_Interview_RB);
            this.Ud_Panel.Controls.Add(this.Ud_Group_Meet_RB);
            this.Ud_Panel.Controls.Add(this.Ud_Lunch_Apt_RB);
            this.Ud_Panel.Location = new System.Drawing.Point(12, 67);
            this.Ud_Panel.Name = "Ud_Panel";
            this.Ud_Panel.Size = new System.Drawing.Size(100, 105);
            this.Ud_Panel.TabIndex = 43;
            // 
            // End_Date_Label
            // 
            this.End_Date_Label.AutoSize = true;
            this.End_Date_Label.Location = new System.Drawing.Point(150, 93);
            this.End_Date_Label.Name = "End_Date_Label";
            this.End_Date_Label.Size = new System.Drawing.Size(55, 13);
            this.End_Date_Label.TabIndex = 40;
            this.End_Date_Label.Text = "End Time:";
            // 
            // Ud_End_Date_CB
            // 
            this.Ud_End_Date_CB.FormattingEnabled = true;
            this.Ud_End_Date_CB.Location = new System.Drawing.Point(151, 109);
            this.Ud_End_Date_CB.Name = "Ud_End_Date_CB";
            this.Ud_End_Date_CB.Size = new System.Drawing.Size(199, 21);
            this.Ud_End_Date_CB.TabIndex = 45;
            // 
            // Ud_Start_Date_CB
            // 
            this.Ud_Start_Date_CB.FormattingEnabled = true;
            this.Ud_Start_Date_CB.Location = new System.Drawing.Point(151, 69);
            this.Ud_Start_Date_CB.Name = "Ud_Start_Date_CB";
            this.Ud_Start_Date_CB.Size = new System.Drawing.Size(199, 21);
            this.Ud_Start_Date_CB.TabIndex = 44;
            this.Ud_Start_Date_CB.SelectedIndexChanged += new System.EventHandler(this.Ud_Start_Date_CB_SelectedIndexChanged);
            // 
            // Up_User_ID_TxtBx
            // 
            this.Up_User_ID_TxtBx.Location = new System.Drawing.Point(12, 25);
            this.Up_User_ID_TxtBx.Name = "Up_User_ID_TxtBx";
            this.Up_User_ID_TxtBx.ReadOnly = true;
            this.Up_User_ID_TxtBx.Size = new System.Drawing.Size(100, 20);
            this.Up_User_ID_TxtBx.TabIndex = 47;
            // 
            // Up_User_ID_Label
            // 
            this.Up_User_ID_Label.AutoSize = true;
            this.Up_User_ID_Label.Location = new System.Drawing.Point(12, 9);
            this.Up_User_ID_Label.Name = "Up_User_ID_Label";
            this.Up_User_ID_Label.Size = new System.Drawing.Size(46, 13);
            this.Up_User_ID_Label.TabIndex = 46;
            this.Up_User_ID_Label.Text = "User ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Start Time:";
            // 
            // Update_Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Up_User_ID_TxtBx);
            this.Controls.Add(this.Up_User_ID_Label);
            this.Controls.Add(this.Ud_End_Date_CB);
            this.Controls.Add(this.Ud_Start_Date_CB);
            this.Controls.Add(this.Ud_Panel);
            this.Controls.Add(this.Start_Date_DTP);
            this.Controls.Add(this.End_Date_Label);
            this.Controls.Add(this.Start_Date_Label);
            this.Controls.Add(this.Type_Label);
            this.Controls.Add(this.Update_Cancel_Button);
            this.Controls.Add(this.Add_Save_Button);
            this.Name = "Update_Appointment";
            this.Text = "Update Appointment";
            this.Ud_Panel.ResumeLayout(false);
            this.Ud_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker Start_Date_DTP;
        private System.Windows.Forms.Label Start_Date_Label;
        private System.Windows.Forms.RadioButton Ud_Meeting_RB;
        private System.Windows.Forms.RadioButton Ud_Interview_RB;
        private System.Windows.Forms.RadioButton Ud_Group_Meet_RB;
        private System.Windows.Forms.RadioButton Ud_Lunch_Apt_RB;
        private System.Windows.Forms.Label Type_Label;
        private System.Windows.Forms.Button Update_Cancel_Button;
        private System.Windows.Forms.Button Add_Save_Button;
        private System.Windows.Forms.Panel Ud_Panel;
        private System.Windows.Forms.Label End_Date_Label;
        private System.Windows.Forms.ComboBox Ud_End_Date_CB;
        private System.Windows.Forms.ComboBox Ud_Start_Date_CB;
        private System.Windows.Forms.TextBox Up_User_ID_TxtBx;
        private System.Windows.Forms.Label Up_User_ID_Label;
        private System.Windows.Forms.Label label1;
    }
}