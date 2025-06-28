using RantBuddyDesktop;

namespace formLogin
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblPin_Click(object sender, EventArgs e)
        {

        }

        private void tbxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            formHomepage homepage = new formHomepage();
            homepage.Show();
            this.Hide();

        }
    }
}
