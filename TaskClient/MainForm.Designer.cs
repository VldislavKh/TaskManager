namespace TaskClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginButton = new Button();
            registerButton = new Button();
            TasksButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(698, 12);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(90, 28);
            loginButton.TabIndex = 0;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(508, 12);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(184, 28);
            registerButton.TabIndex = 1;
            registerButton.Text = "Зарегистрироваться";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // TasksButton
            // 
            TasksButton.Location = new Point(12, 12);
            TasksButton.Name = "TasksButton";
            TasksButton.Size = new Size(266, 141);
            TasksButton.TabIndex = 2;
            TasksButton.Text = "Просмотреть задачи";
            TasksButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 159);
            button1.Name = "button1";
            button1.Size = new Size(266, 141);
            button1.TabIndex = 3;
            button1.Text = "Управление задачами";
            button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(TasksButton);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Name = "MainForm";
            Text = "Task Manager";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private Button registerButton;
        private Button TasksButton;
        private Button button1;
    }
}