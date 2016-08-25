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

namespace TvShowTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ILoginPresenter presenter = new LoginPresenter();
            LoginForm loginForm = new LoginForm();
            presenter.AttachView(loginForm);
            loginForm.ShowDialog();
        }
    }
}
