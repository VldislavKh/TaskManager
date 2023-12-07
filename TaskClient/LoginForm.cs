using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskClient.RestClients;
using TaskManager_API.CQ.Requests;

namespace TaskClient
{
    public partial class LoginForm : Form
    {
        private readonly IServakRestClient _servak;
        public LoginForm(IServakRestClient servak)
        {
            InitializeComponent();
            _servak = servak;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var token = _servak.Login(new LoginRequest { Login = loginTextBox.Text, Password = passwordTextBox.Text });
            loginTextBox.Text = token.ToString();
        }
    }
}
