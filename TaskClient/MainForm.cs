using TaskClient.RestClients;

namespace TaskClient
{
    public partial class MainForm : Form
    {
        private readonly IServakRestClient _servak;
        public MainForm(IServakRestClient servak)
        {
            InitializeComponent();
            _servak = servak;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var registration = new RegistrationForm(_servak);
            registration.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var login = new LoginForm(_servak);
            login.Show();
        }
    }
}