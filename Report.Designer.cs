namespace Kelson_Orton_Application_Dev
{
    partial class Report
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
            this.Apt_Type_Month_DGV = new System.Windows.Forms.DataGridView();
            this.Report_Sched_Month_DGV = new System.Windows.Forms.DataGridView();
            this.Report_Num_Cu_DGV = new System.Windows.Forms.DataGridView();
            this.Report_Num_Types_Label = new System.Windows.Forms.Label();
            this.Report_Sched_Month_Label = new System.Windows.Forms.Label();
            this.Report_Num_Cu_Label = new System.Windows.Forms.Label();
            this.Return_Button = new System.Windows.Forms.Button();
            this.Return_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Apt_Type_Month_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_Sched_Month_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_Num_Cu_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Apt_Type_Month_DGV
            // 
            this.Apt_Type_Month_DGV.AllowUserToAddRows = false;
            this.Apt_Type_Month_DGV.AllowUserToDeleteRows = false;
            this.Apt_Type_Month_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Apt_Type_Month_DGV.Location = new System.Drawing.Point(12, 25);
            this.Apt_Type_Month_DGV.MultiSelect = false;
            this.Apt_Type_Month_DGV.Name = "Apt_Type_Month_DGV";
            this.Apt_Type_Month_DGV.ReadOnly = true;
            this.Apt_Type_Month_DGV.Size = new System.Drawing.Size(267, 100);
            this.Apt_Type_Month_DGV.TabIndex = 0;
            // 
            // Report_Sched_Month_DGV
            // 
            this.Report_Sched_Month_DGV.AllowUserToAddRows = false;
            this.Report_Sched_Month_DGV.AllowUserToDeleteRows = false;
            this.Report_Sched_Month_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Report_Sched_Month_DGV.Location = new System.Drawing.Point(12, 156);
            this.Report_Sched_Month_DGV.MultiSelect = false;
            this.Report_Sched_Month_DGV.Name = "Report_Sched_Month_DGV";
            this.Report_Sched_Month_DGV.ReadOnly = true;
            this.Report_Sched_Month_DGV.Size = new System.Drawing.Size(661, 159);
            this.Report_Sched_Month_DGV.TabIndex = 1;
            // 
            // Report_Num_Cu_DGV
            // 
            this.Report_Num_Cu_DGV.AllowUserToAddRows = false;
            this.Report_Num_Cu_DGV.AllowUserToDeleteRows = false;
            this.Report_Num_Cu_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Report_Num_Cu_DGV.Location = new System.Drawing.Point(335, 25);
            this.Report_Num_Cu_DGV.MultiSelect = false;
            this.Report_Num_Cu_DGV.Name = "Report_Num_Cu_DGV";
            this.Report_Num_Cu_DGV.ReadOnly = true;
            this.Report_Num_Cu_DGV.Size = new System.Drawing.Size(338, 100);
            this.Report_Num_Cu_DGV.TabIndex = 2;
            // 
            // Report_Num_Types_Label
            // 
            this.Report_Num_Types_Label.AutoSize = true;
            this.Report_Num_Types_Label.Location = new System.Drawing.Point(12, 9);
            this.Report_Num_Types_Label.Name = "Report_Num_Types_Label";
            this.Report_Num_Types_Label.Size = new System.Drawing.Size(217, 13);
            this.Report_Num_Types_Label.TabIndex = 3;
            this.Report_Num_Types_Label.Text = "Report 1: Appointment types (Current Month)";
            // 
            // Report_Sched_Month_Label
            // 
            this.Report_Sched_Month_Label.AutoSize = true;
            this.Report_Sched_Month_Label.Location = new System.Drawing.Point(12, 140);
            this.Report_Sched_Month_Label.Name = "Report_Sched_Month_Label";
            this.Report_Sched_Month_Label.Size = new System.Drawing.Size(0, 13);
            this.Report_Sched_Month_Label.TabIndex = 4;
            // 
            // Report_Num_Cu_Label
            // 
            this.Report_Num_Cu_Label.AutoSize = true;
            this.Report_Num_Cu_Label.Location = new System.Drawing.Point(335, 9);
            this.Report_Num_Cu_Label.Name = "Report_Num_Cu_Label";
            this.Report_Num_Cu_Label.Size = new System.Drawing.Size(224, 13);
            this.Report_Num_Cu_Label.TabIndex = 5;
            this.Report_Num_Cu_Label.Text = "Report 2: Users and Total of Customers Listed";
            // 
            // Return_Button
            // 
            this.Return_Button.Location = new System.Drawing.Point(598, 348);
            this.Return_Button.Name = "Return_Button";
            this.Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Return_Button.TabIndex = 7;
            this.Return_Button.Text = "Return";
            this.Return_Button.UseVisualStyleBackColor = true;
            this.Return_Button.Click += new System.EventHandler(this.Return_Button_Click);
            // 
            // Return_Label
            // 
            this.Return_Label.AutoSize = true;
            this.Return_Label.Location = new System.Drawing.Point(559, 330);
            this.Return_Label.Name = "Return_Label";
            this.Return_Label.Size = new System.Drawing.Size(114, 13);
            this.Return_Label.TabIndex = 9;
            this.Return_Label.Text = "Return to Main Screen";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 383);
            this.Controls.Add(this.Return_Label);
            this.Controls.Add(this.Return_Button);
            this.Controls.Add(this.Report_Num_Cu_Label);
            this.Controls.Add(this.Report_Sched_Month_Label);
            this.Controls.Add(this.Report_Num_Types_Label);
            this.Controls.Add(this.Report_Num_Cu_DGV);
            this.Controls.Add(this.Report_Sched_Month_DGV);
            this.Controls.Add(this.Apt_Type_Month_DGV);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Apt_Type_Month_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_Sched_Month_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Report_Num_Cu_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Apt_Type_Month_DGV;
        private System.Windows.Forms.DataGridView Report_Sched_Month_DGV;
        private System.Windows.Forms.DataGridView Report_Num_Cu_DGV;
        private System.Windows.Forms.Label Report_Num_Types_Label;
        private System.Windows.Forms.Label Report_Sched_Month_Label;
        private System.Windows.Forms.Label Report_Num_Cu_Label;
        private System.Windows.Forms.Button Return_Button;
        private System.Windows.Forms.Label Return_Label;
    }
}