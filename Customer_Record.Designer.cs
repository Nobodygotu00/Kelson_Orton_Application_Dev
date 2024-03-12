namespace Kelson_Orton_Application_Dev
{
    partial class Customer_Record
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
            this.Customer_Record_DaGrVi = new System.Windows.Forms.DataGridView();
            this.Customer_Record_Add_Button = new System.Windows.Forms.Button();
            this.Customer_Record_Update_Button = new System.Windows.Forms.Button();
            this.Customer_Record_Delete_Button = new System.Windows.Forms.Button();
            this.Customer_Record_Return_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_Record_DaGrVi)).BeginInit();
            this.SuspendLayout();
            // 
            // Customer_Record_DaGrVi
            // 
            this.Customer_Record_DaGrVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Customer_Record_DaGrVi.Location = new System.Drawing.Point(90, 12);
            this.Customer_Record_DaGrVi.MultiSelect = false;
            this.Customer_Record_DaGrVi.Name = "Customer_Record_DaGrVi";
            this.Customer_Record_DaGrVi.ReadOnly = true;
            this.Customer_Record_DaGrVi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Customer_Record_DaGrVi.Size = new System.Drawing.Size(645, 230);
            this.Customer_Record_DaGrVi.TabIndex = 0;
            // 
            // Customer_Record_Add_Button
            // 
            this.Customer_Record_Add_Button.Location = new System.Drawing.Point(417, 264);
            this.Customer_Record_Add_Button.Name = "Customer_Record_Add_Button";
            this.Customer_Record_Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Customer_Record_Add_Button.TabIndex = 1;
            this.Customer_Record_Add_Button.Text = "Add";
            this.Customer_Record_Add_Button.UseVisualStyleBackColor = true;
            this.Customer_Record_Add_Button.Click += new System.EventHandler(this.Customer_Record_Add_Button_Click);
            // 
            // Customer_Record_Update_Button
            // 
            this.Customer_Record_Update_Button.Location = new System.Drawing.Point(498, 264);
            this.Customer_Record_Update_Button.Name = "Customer_Record_Update_Button";
            this.Customer_Record_Update_Button.Size = new System.Drawing.Size(75, 23);
            this.Customer_Record_Update_Button.TabIndex = 2;
            this.Customer_Record_Update_Button.Text = "Update";
            this.Customer_Record_Update_Button.UseVisualStyleBackColor = true;
            this.Customer_Record_Update_Button.Click += new System.EventHandler(this.Customer_Record_Update_Button_Click);
            // 
            // Customer_Record_Delete_Button
            // 
            this.Customer_Record_Delete_Button.Location = new System.Drawing.Point(579, 264);
            this.Customer_Record_Delete_Button.Name = "Customer_Record_Delete_Button";
            this.Customer_Record_Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Customer_Record_Delete_Button.TabIndex = 3;
            this.Customer_Record_Delete_Button.Text = "Delete";
            this.Customer_Record_Delete_Button.UseVisualStyleBackColor = true;
            this.Customer_Record_Delete_Button.Click += new System.EventHandler(this.Customer_Record_Delete_Button_Click);
            // 
            // Customer_Record_Return_Button
            // 
            this.Customer_Record_Return_Button.Location = new System.Drawing.Point(660, 264);
            this.Customer_Record_Return_Button.Name = "Customer_Record_Return_Button";
            this.Customer_Record_Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Customer_Record_Return_Button.TabIndex = 4;
            this.Customer_Record_Return_Button.Text = "Return";
            this.Customer_Record_Return_Button.UseVisualStyleBackColor = true;
            this.Customer_Record_Return_Button.Click += new System.EventHandler(this.Customer_Record_Return_Button_Click);
            // 
            // Customer_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 299);
            this.Controls.Add(this.Customer_Record_Return_Button);
            this.Controls.Add(this.Customer_Record_Delete_Button);
            this.Controls.Add(this.Customer_Record_Update_Button);
            this.Controls.Add(this.Customer_Record_Add_Button);
            this.Controls.Add(this.Customer_Record_DaGrVi);
            this.Name = "Customer_Record";
            this.Text = "Customer Record";
            this.Load += new System.EventHandler(this.Customer_Record_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_Record_DaGrVi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView Customer_Record_DaGrVi;
        private System.Windows.Forms.Button Customer_Record_Add_Button;
        private System.Windows.Forms.Button Customer_Record_Update_Button;
        private System.Windows.Forms.Button Customer_Record_Delete_Button;
        private System.Windows.Forms.Button Customer_Record_Return_Button;
    }
}