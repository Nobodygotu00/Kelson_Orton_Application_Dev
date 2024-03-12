namespace Kelson_Orton_Application_Dev
{
    partial class Main_Screen
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
            this.Main_Screen_CuRec_Button = new System.Windows.Forms.Button();
            this.Main_Screen_Sch_Button = new System.Windows.Forms.Button();
            this.Main_Screen_Schedule_Button = new System.Windows.Forms.Button();
            this.Main_Screen_Record_Button = new System.Windows.Forms.Button();
            this.Main_Screen_Exit_Button = new System.Windows.Forms.Button();
            this.Main_Screen_Schedule_Label = new System.Windows.Forms.Label();
            this.Main_Screen_Customer_Rec_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Main_Screen_CuRec_Button
            // 
            this.Main_Screen_CuRec_Button.Location = new System.Drawing.Point(85, 346);
            this.Main_Screen_CuRec_Button.Name = "Main_Screen_CuRec_Button";
            this.Main_Screen_CuRec_Button.Size = new System.Drawing.Size(75, 23);
            this.Main_Screen_CuRec_Button.TabIndex = 0;
            this.Main_Screen_CuRec_Button.Text = "Record";
            this.Main_Screen_CuRec_Button.UseVisualStyleBackColor = true;
            // 
            // Main_Screen_Sch_Button
            // 
            this.Main_Screen_Sch_Button.Location = new System.Drawing.Point(644, 346);
            this.Main_Screen_Sch_Button.Name = "Main_Screen_Sch_Button";
            this.Main_Screen_Sch_Button.Size = new System.Drawing.Size(75, 23);
            this.Main_Screen_Sch_Button.TabIndex = 1;
            this.Main_Screen_Sch_Button.Text = "Schedule";
            this.Main_Screen_Sch_Button.UseVisualStyleBackColor = true;
            // 
            // Main_Screen_Schedule_Button
            // 
            this.Main_Screen_Schedule_Button.Location = new System.Drawing.Point(145, 42);
            this.Main_Screen_Schedule_Button.Name = "Main_Screen_Schedule_Button";
            this.Main_Screen_Schedule_Button.Size = new System.Drawing.Size(75, 23);
            this.Main_Screen_Schedule_Button.TabIndex = 2;
            this.Main_Screen_Schedule_Button.Text = "Schedule ";
            this.Main_Screen_Schedule_Button.UseVisualStyleBackColor = true;
            this.Main_Screen_Schedule_Button.Click += new System.EventHandler(this.Main_Screen_Schedule_Button_Click);
            // 
            // Main_Screen_Record_Button
            // 
            this.Main_Screen_Record_Button.Location = new System.Drawing.Point(145, 94);
            this.Main_Screen_Record_Button.Name = "Main_Screen_Record_Button";
            this.Main_Screen_Record_Button.Size = new System.Drawing.Size(75, 23);
            this.Main_Screen_Record_Button.TabIndex = 3;
            this.Main_Screen_Record_Button.Text = "Records";
            this.Main_Screen_Record_Button.UseVisualStyleBackColor = true;
            this.Main_Screen_Record_Button.Click += new System.EventHandler(this.Main_Screen_Record_Button_Click);
            // 
            // Main_Screen_Exit_Button
            // 
            this.Main_Screen_Exit_Button.Location = new System.Drawing.Point(145, 150);
            this.Main_Screen_Exit_Button.Name = "Main_Screen_Exit_Button";
            this.Main_Screen_Exit_Button.Size = new System.Drawing.Size(75, 23);
            this.Main_Screen_Exit_Button.TabIndex = 4;
            this.Main_Screen_Exit_Button.Text = "Exit";
            this.Main_Screen_Exit_Button.UseVisualStyleBackColor = true;
            this.Main_Screen_Exit_Button.Click += new System.EventHandler(this.Main_Screen_Exit_Button_Click);
            // 
            // Main_Screen_Schedule_Label
            // 
            this.Main_Screen_Schedule_Label.AutoSize = true;
            this.Main_Screen_Schedule_Label.Location = new System.Drawing.Point(12, 47);
            this.Main_Screen_Schedule_Label.Name = "Main_Screen_Schedule_Label";
            this.Main_Screen_Schedule_Label.Size = new System.Drawing.Size(121, 13);
            this.Main_Screen_Schedule_Label.TabIndex = 5;
            this.Main_Screen_Schedule_Label.Text = "Schedule appointments:";
            // 
            // Main_Screen_Customer_Rec_Label
            // 
            this.Main_Screen_Customer_Rec_Label.AutoSize = true;
            this.Main_Screen_Customer_Rec_Label.Location = new System.Drawing.Point(12, 99);
            this.Main_Screen_Customer_Rec_Label.Name = "Main_Screen_Customer_Rec_Label";
            this.Main_Screen_Customer_Rec_Label.Size = new System.Drawing.Size(100, 13);
            this.Main_Screen_Customer_Rec_Label.TabIndex = 6;
            this.Main_Screen_Customer_Rec_Label.Text = "Customer Records: ";
            // 
            // Main_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 191);
            this.Controls.Add(this.Main_Screen_Customer_Rec_Label);
            this.Controls.Add(this.Main_Screen_Schedule_Label);
            this.Controls.Add(this.Main_Screen_Exit_Button);
            this.Controls.Add(this.Main_Screen_Record_Button);
            this.Controls.Add(this.Main_Screen_Schedule_Button);
            this.Controls.Add(this.Main_Screen_Sch_Button);
            this.Controls.Add(this.Main_Screen_CuRec_Button);
            this.Name = "Main_Screen";
            this.Text = "Main_Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Main_Screen_CuRec_Button;
        private System.Windows.Forms.Button Main_Screen_Sch_Button;
        private System.Windows.Forms.Button Main_Screen_Schedule_Button;
        private System.Windows.Forms.Button Main_Screen_Record_Button;
        private System.Windows.Forms.Button Main_Screen_Exit_Button;
        private System.Windows.Forms.Label Main_Screen_Schedule_Label;
        private System.Windows.Forms.Label Main_Screen_Customer_Rec_Label;
    }
}