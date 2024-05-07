namespace Kelson_Orton_Application_Dev
{
    partial class Appointment
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
            this.Name_Label = new System.Windows.Forms.Label();
            this.Name_TxtBx = new System.Windows.Forms.TextBox();
            this.Sche_App_Label = new System.Windows.Forms.Label();
            this.Sch_App_Button = new System.Windows.Forms.Button();
            this.Up_Week_Label = new System.Windows.Forms.Label();
            this.Up_Week_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Week_Apt_DGV = new System.Windows.Forms.DataGridView();
            this.Week_Apt_Label = new System.Windows.Forms.Label();
            this.ID_TxtBx = new System.Windows.Forms.TextBox();
            this.ID_Label = new System.Windows.Forms.Label();
            this.All_Apt_DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Cancel_Label = new System.Windows.Forms.Label();
            this.Month_Apt_DGV = new System.Windows.Forms.DataGridView();
            this.Month_Label = new System.Windows.Forms.Label();
            this.Delete_Month_Button = new System.Windows.Forms.Button();
            this.Delete_Month_Label = new System.Windows.Forms.Label();
            this.Delete_Week_Button = new System.Windows.Forms.Button();
            this.Week_Delete_Label = new System.Windows.Forms.Label();
            this.Up_Month_Button = new System.Windows.Forms.Button();
            this.Up_Month_Label = new System.Windows.Forms.Label();
            this.User_ID_TxtBx = new System.Windows.Forms.TextBox();
            this.User_ID_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Week_Apt_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.All_Apt_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month_Apt_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.Location = new System.Drawing.Point(253, 9);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(85, 13);
            this.Name_Label.TabIndex = 0;
            this.Name_Label.Text = "Customer Name:";
            // 
            // Name_TxtBx
            // 
            this.Name_TxtBx.Location = new System.Drawing.Point(253, 25);
            this.Name_TxtBx.Name = "Name_TxtBx";
            this.Name_TxtBx.ReadOnly = true;
            this.Name_TxtBx.Size = new System.Drawing.Size(100, 20);
            this.Name_TxtBx.TabIndex = 1;
            // 
            // Sche_App_Label
            // 
            this.Sche_App_Label.AutoSize = true;
            this.Sche_App_Label.Location = new System.Drawing.Point(502, 9);
            this.Sche_App_Label.Name = "Sche_App_Label";
            this.Sche_App_Label.Size = new System.Drawing.Size(114, 13);
            this.Sche_App_Label.TabIndex = 2;
            this.Sche_App_Label.Text = "Schedule Appointment";
            // 
            // Sch_App_Button
            // 
            this.Sch_App_Button.Location = new System.Drawing.Point(505, 25);
            this.Sch_App_Button.Name = "Sch_App_Button";
            this.Sch_App_Button.Size = new System.Drawing.Size(75, 23);
            this.Sch_App_Button.TabIndex = 3;
            this.Sch_App_Button.Text = "Add";
            this.Sch_App_Button.UseVisualStyleBackColor = true;
            this.Sch_App_Button.Click += new System.EventHandler(this.Sch_App_Button_Click);
            // 
            // Up_Week_Label
            // 
            this.Up_Week_Label.AutoSize = true;
            this.Up_Week_Label.Location = new System.Drawing.Point(412, 174);
            this.Up_Week_Label.Name = "Up_Week_Label";
            this.Up_Week_Label.Size = new System.Drawing.Size(136, 13);
            this.Up_Week_Label.TabIndex = 4;
            this.Up_Week_Label.Text = "Update Week Appointment";
            // 
            // Up_Week_Button
            // 
            this.Up_Week_Button.Location = new System.Drawing.Point(473, 190);
            this.Up_Week_Button.Name = "Up_Week_Button";
            this.Up_Week_Button.Size = new System.Drawing.Size(75, 23);
            this.Up_Week_Button.TabIndex = 5;
            this.Up_Week_Button.Text = "Update";
            this.Up_Week_Button.UseVisualStyleBackColor = true;
            this.Up_Week_Button.Click += new System.EventHandler(this.Up_Week_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(660, 25);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Week_Apt_DGV
            // 
            this.Week_Apt_DGV.AllowDrop = true;
            this.Week_Apt_DGV.AllowUserToAddRows = false;
            this.Week_Apt_DGV.AllowUserToDeleteRows = false;
            this.Week_Apt_DGV.AllowUserToResizeColumns = false;
            this.Week_Apt_DGV.AllowUserToResizeRows = false;
            this.Week_Apt_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Week_Apt_DGV.Location = new System.Drawing.Point(12, 72);
            this.Week_Apt_DGV.MultiSelect = false;
            this.Week_Apt_DGV.Name = "Week_Apt_DGV";
            this.Week_Apt_DGV.ReadOnly = true;
            this.Week_Apt_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Week_Apt_DGV.Size = new System.Drawing.Size(723, 99);
            this.Week_Apt_DGV.TabIndex = 9;
            // 
            // Week_Apt_Label
            // 
            this.Week_Apt_Label.AutoSize = true;
            this.Week_Apt_Label.Location = new System.Drawing.Point(12, 56);
            this.Week_Apt_Label.Name = "Week_Apt_Label";
            this.Week_Apt_Label.Size = new System.Drawing.Size(106, 13);
            this.Week_Apt_Label.TabIndex = 10;
            this.Week_Apt_Label.Text = "Week Appointments ";
            // 
            // ID_TxtBx
            // 
            this.ID_TxtBx.Location = new System.Drawing.Point(135, 25);
            this.ID_TxtBx.Name = "ID_TxtBx";
            this.ID_TxtBx.ReadOnly = true;
            this.ID_TxtBx.Size = new System.Drawing.Size(100, 20);
            this.ID_TxtBx.TabIndex = 12;
            // 
            // ID_Label
            // 
            this.ID_Label.AutoSize = true;
            this.ID_Label.Location = new System.Drawing.Point(135, 9);
            this.ID_Label.Name = "ID_Label";
            this.ID_Label.Size = new System.Drawing.Size(68, 13);
            this.ID_Label.TabIndex = 11;
            this.ID_Label.Text = "Customer ID:";
            // 
            // All_Apt_DGV
            // 
            this.All_Apt_DGV.AllowUserToAddRows = false;
            this.All_Apt_DGV.AllowUserToDeleteRows = false;
            this.All_Apt_DGV.AllowUserToResizeColumns = false;
            this.All_Apt_DGV.AllowUserToResizeRows = false;
            this.All_Apt_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.All_Apt_DGV.Location = new System.Drawing.Point(12, 372);
            this.All_Apt_DGV.MultiSelect = false;
            this.All_Apt_DGV.Name = "All_Apt_DGV";
            this.All_Apt_DGV.ReadOnly = true;
            this.All_Apt_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.All_Apt_DGV.Size = new System.Drawing.Size(720, 140);
            this.All_Apt_DGV.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "All Appointments ";
            // 
            // Cancel_Label
            // 
            this.Cancel_Label.AutoSize = true;
            this.Cancel_Label.Location = new System.Drawing.Point(622, 9);
            this.Cancel_Label.Name = "Cancel_Label";
            this.Cancel_Label.Size = new System.Drawing.Size(114, 13);
            this.Cancel_Label.TabIndex = 15;
            this.Cancel_Label.Text = "Return to Main Screen";
            // 
            // Month_Apt_DGV
            // 
            this.Month_Apt_DGV.AllowUserToAddRows = false;
            this.Month_Apt_DGV.AllowUserToDeleteRows = false;
            this.Month_Apt_DGV.AllowUserToResizeColumns = false;
            this.Month_Apt_DGV.AllowUserToResizeRows = false;
            this.Month_Apt_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Month_Apt_DGV.Location = new System.Drawing.Point(12, 219);
            this.Month_Apt_DGV.MultiSelect = false;
            this.Month_Apt_DGV.Name = "Month_Apt_DGV";
            this.Month_Apt_DGV.ReadOnly = true;
            this.Month_Apt_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Month_Apt_DGV.Size = new System.Drawing.Size(723, 105);
            this.Month_Apt_DGV.TabIndex = 16;
            // 
            // Month_Label
            // 
            this.Month_Label.AutoSize = true;
            this.Month_Label.Location = new System.Drawing.Point(9, 203);
            this.Month_Label.Name = "Month_Label";
            this.Month_Label.Size = new System.Drawing.Size(107, 13);
            this.Month_Label.TabIndex = 17;
            this.Month_Label.Text = "Month Appointments ";
            // 
            // Delete_Month_Button
            // 
            this.Delete_Month_Button.Location = new System.Drawing.Point(660, 343);
            this.Delete_Month_Button.Name = "Delete_Month_Button";
            this.Delete_Month_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Month_Button.TabIndex = 19;
            this.Delete_Month_Button.Text = "Delete";
            this.Delete_Month_Button.UseVisualStyleBackColor = true;
            this.Delete_Month_Button.Click += new System.EventHandler(this.Delete_Month_Button_Click);
            // 
            // Delete_Month_Label
            // 
            this.Delete_Month_Label.AutoSize = true;
            this.Delete_Month_Label.Location = new System.Drawing.Point(580, 327);
            this.Delete_Month_Label.Name = "Delete_Month_Label";
            this.Delete_Month_Label.Size = new System.Drawing.Size(156, 13);
            this.Delete_Month_Label.TabIndex = 18;
            this.Delete_Month_Label.Text = "Delete from Month Appointment";
            // 
            // Delete_Week_Button
            // 
            this.Delete_Week_Button.Location = new System.Drawing.Point(660, 190);
            this.Delete_Week_Button.Name = "Delete_Week_Button";
            this.Delete_Week_Button.Size = new System.Drawing.Size(75, 23);
            this.Delete_Week_Button.TabIndex = 21;
            this.Delete_Week_Button.Text = "Delete";
            this.Delete_Week_Button.UseVisualStyleBackColor = true;
            this.Delete_Week_Button.Click += new System.EventHandler(this.Delete_Week_Button_Click);
            // 
            // Week_Delete_Label
            // 
            this.Week_Delete_Label.AutoSize = true;
            this.Week_Delete_Label.Location = new System.Drawing.Point(580, 174);
            this.Week_Delete_Label.Name = "Week_Delete_Label";
            this.Week_Delete_Label.Size = new System.Drawing.Size(155, 13);
            this.Week_Delete_Label.TabIndex = 20;
            this.Week_Delete_Label.Text = "Delete from Week Appointment";
            // 
            // Up_Month_Button
            // 
            this.Up_Month_Button.Location = new System.Drawing.Point(473, 343);
            this.Up_Month_Button.Name = "Up_Month_Button";
            this.Up_Month_Button.Size = new System.Drawing.Size(75, 23);
            this.Up_Month_Button.TabIndex = 23;
            this.Up_Month_Button.Text = "Update";
            this.Up_Month_Button.UseVisualStyleBackColor = true;
            this.Up_Month_Button.Click += new System.EventHandler(this.Up_Month_Button_Click);
            // 
            // Up_Month_Label
            // 
            this.Up_Month_Label.AutoSize = true;
            this.Up_Month_Label.Location = new System.Drawing.Point(411, 327);
            this.Up_Month_Label.Name = "Up_Month_Label";
            this.Up_Month_Label.Size = new System.Drawing.Size(137, 13);
            this.Up_Month_Label.TabIndex = 22;
            this.Up_Month_Label.Text = "Update Month Appointment";
            // 
            // User_ID_TxtBx
            // 
            this.User_ID_TxtBx.Location = new System.Drawing.Point(12, 25);
            this.User_ID_TxtBx.Name = "User_ID_TxtBx";
            this.User_ID_TxtBx.ReadOnly = true;
            this.User_ID_TxtBx.Size = new System.Drawing.Size(100, 20);
            this.User_ID_TxtBx.TabIndex = 25;
            // 
            // User_ID_Label
            // 
            this.User_ID_Label.AutoSize = true;
            this.User_ID_Label.Location = new System.Drawing.Point(12, 9);
            this.User_ID_Label.Name = "User_ID_Label";
            this.User_ID_Label.Size = new System.Drawing.Size(46, 13);
            this.User_ID_Label.TabIndex = 24;
            this.User_ID_Label.Text = "User ID:";
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 524);
            this.Controls.Add(this.User_ID_TxtBx);
            this.Controls.Add(this.User_ID_Label);
            this.Controls.Add(this.Up_Month_Button);
            this.Controls.Add(this.Up_Month_Label);
            this.Controls.Add(this.Delete_Week_Button);
            this.Controls.Add(this.Week_Delete_Label);
            this.Controls.Add(this.Delete_Month_Button);
            this.Controls.Add(this.Delete_Month_Label);
            this.Controls.Add(this.Month_Label);
            this.Controls.Add(this.Month_Apt_DGV);
            this.Controls.Add(this.Cancel_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.All_Apt_DGV);
            this.Controls.Add(this.ID_TxtBx);
            this.Controls.Add(this.ID_Label);
            this.Controls.Add(this.Week_Apt_Label);
            this.Controls.Add(this.Week_Apt_DGV);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Up_Week_Button);
            this.Controls.Add(this.Up_Week_Label);
            this.Controls.Add(this.Sch_App_Button);
            this.Controls.Add(this.Sche_App_Label);
            this.Controls.Add(this.Name_TxtBx);
            this.Controls.Add(this.Name_Label);
            this.Name = "Appointment";
            this.Text = "Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.Week_Apt_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.All_Apt_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month_Apt_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.TextBox Name_TxtBx;
        private System.Windows.Forms.Label Sche_App_Label;
        private System.Windows.Forms.Button Sch_App_Button;
        private System.Windows.Forms.Label Up_Week_Label;
        private System.Windows.Forms.Button Up_Week_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.DataGridView Week_Apt_DGV;
        private System.Windows.Forms.Label Week_Apt_Label;
        private System.Windows.Forms.TextBox ID_TxtBx;
        private System.Windows.Forms.Label ID_Label;
        private System.Windows.Forms.DataGridView All_Apt_DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Cancel_Label;
        private System.Windows.Forms.DataGridView Month_Apt_DGV;
        private System.Windows.Forms.Label Month_Label;
        private System.Windows.Forms.Button Delete_Month_Button;
        private System.Windows.Forms.Label Delete_Month_Label;
        private System.Windows.Forms.Button Delete_Week_Button;
        private System.Windows.Forms.Label Week_Delete_Label;
        private System.Windows.Forms.Button Up_Month_Button;
        private System.Windows.Forms.Label Up_Month_Label;
        private System.Windows.Forms.TextBox User_ID_TxtBx;
        private System.Windows.Forms.Label User_ID_Label;
    }
}