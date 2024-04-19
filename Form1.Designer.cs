namespace Kelson_Orton_Application_Dev
{
    partial class Form1
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
            this.Login_Username_Label = new System.Windows.Forms.Label();
            this.Login_Password_Label = new System.Windows.Forms.Label();
            this.Login_Username_TxtBx = new System.Windows.Forms.TextBox();
            this.Login_Password_TxtBx = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login_Username_Label
            // 
            this.Login_Username_Label.AutoSize = true;
            this.Login_Username_Label.Location = new System.Drawing.Point(14, 37);
            this.Login_Username_Label.Name = "Login_Username_Label";
            this.Login_Username_Label.Size = new System.Drawing.Size(58, 13);
            this.Login_Username_Label.TabIndex = 0;
            this.Login_Username_Label.Text = "Username:";
            this.Login_Username_Label.Click += new System.EventHandler(this.Login_Username_Label_Click);
            // 
            // Login_Password_Label
            // 
            this.Login_Password_Label.AutoSize = true;
            this.Login_Password_Label.Location = new System.Drawing.Point(14, 86);
            this.Login_Password_Label.Name = "Login_Password_Label";
            this.Login_Password_Label.Size = new System.Drawing.Size(56, 13);
            this.Login_Password_Label.TabIndex = 1;
            this.Login_Password_Label.Text = "Password:";
            this.Login_Password_Label.Click += new System.EventHandler(this.Login_Password_Label_Click);
            // 
            // Login_Username_TxtBx
            // 
            this.Login_Username_TxtBx.Location = new System.Drawing.Point(75, 34);
            this.Login_Username_TxtBx.Name = "Login_Username_TxtBx";
            this.Login_Username_TxtBx.Size = new System.Drawing.Size(167, 20);
            this.Login_Username_TxtBx.TabIndex = 2;
            this.Login_Username_TxtBx.TextChanged += new System.EventHandler(this.Login_Username_TxtBx_TextChanged);
            // 
            // Login_Password_TxtBx
            // 
            this.Login_Password_TxtBx.Location = new System.Drawing.Point(75, 83);
            this.Login_Password_TxtBx.Name = "Login_Password_TxtBx";
            this.Login_Password_TxtBx.Size = new System.Drawing.Size(167, 20);
            this.Login_Password_TxtBx.TabIndex = 3;
            this.Login_Password_TxtBx.TextChanged += new System.EventHandler(this.Login_Password_TxtBx_TextChanged);
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(167, 122);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 5;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 167);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Login_Password_TxtBx);
            this.Controls.Add(this.Login_Username_TxtBx);
            this.Controls.Add(this.Login_Password_Label);
            this.Controls.Add(this.Login_Username_Label);
            this.Name = "Form1";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login_Username_Label;
        private System.Windows.Forms.Label Login_Password_Label;
        private System.Windows.Forms.TextBox Login_Username_TxtBx;
        private System.Windows.Forms.TextBox Login_Password_TxtBx;
        private System.Windows.Forms.Button Login_Button;
    }
}

