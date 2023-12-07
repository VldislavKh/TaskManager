namespace TaskClient
{
    partial class LoginForm
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
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginButton = new Button();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(248, 127);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(270, 26);
            loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(248, 180);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(270, 26);
            passwordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 130);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 2;
            label1.Text = "Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 183);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(248, 261);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(270, 66);
            loginButton.TabIndex = 4;
            loginButton.Text = "Sign up";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Label label1;
        private Label label2;
        private Button loginButton;
    }
}