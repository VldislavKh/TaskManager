namespace TaskClient
{
    partial class RegistrationForm
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
            loginTextBox = new TextBox();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            repeatPasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            registerButton = new Button();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(306, 99);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(303, 26);
            loginTextBox.TabIndex = 0;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(306, 167);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(303, 26);
            emailTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(306, 232);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(303, 26);
            passwordTextBox.TabIndex = 2;
            // 
            // repeatPasswordTextBox
            // 
            repeatPasswordTextBox.Location = new Point(306, 307);
            repeatPasswordTextBox.Name = "repeatPasswordTextBox";
            repeatPasswordTextBox.Size = new Size(303, 26);
            repeatPasswordTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(254, 102);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 4;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 170);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(230, 235);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(178, 310);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 7;
            label4.Text = "Repeat Password";
            // 
            // registerButton
            // 
            registerButton.Location = new Point(178, 387);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(431, 28);
            registerButton.TabIndex = 8;
            registerButton.Text = "Зарегистрироваться";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(repeatPasswordTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(loginTextBox);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox emailTextBox;
        private TextBox passwordTextBox;
        private TextBox repeatPasswordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button registerButton;
    }
}