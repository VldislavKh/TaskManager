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

namespace TaskClient
{
    public partial class RegistrationForm : Form
    {
        private readonly IServakRestClient _servak;
        public RegistrationForm(IServakRestClient servak)
        {
            InitializeComponent();
            _servak = servak;
        }

        private async void registerButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;

            var isLoginUnique = await _servak.CheckLogin(login);
            loginTextBox.Text = isLoginUnique.ToString();
        }
    }
}
