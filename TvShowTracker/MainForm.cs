using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvShowTracker.Presenter.Login;
using TvShowTracker.View;

namespace TvShowTracker
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();

            ILoginPresenter presenter = new LoginPresenter();
            LoginForm loginForm = new LoginForm();
            presenter.AttachView(loginForm);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(String.Format("Hello, {0}", presenter.LoggedInUser.FirstName));
            }
            else
            {
                MessageBox.Show("Bye-Bye");
                this.Close();
            }
        }
    }
}
