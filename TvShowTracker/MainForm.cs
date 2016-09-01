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
using TvShowTracker.Presenter.Main;
using TvShowTracker.View;

namespace TvShowTracker
{
    public partial class MainForm : Form, IMainView
    {
        IMainPresenter mainPresenter;

        public MainForm()
        {
            InitializeComponent();

            ILoginPresenter loginPresenter = new LoginPresenter();
            mainPresenter = new MainPresenter();
            LoginForm loginForm = new LoginForm();
            loginPresenter.AttachView(loginForm);
            mainPresenter.AttachView(this);
            DialogResult loginResult = loginForm.ShowDialog();

            switch (loginResult)
            {
                case DialogResult.OK:
                    mainPresenter.LoginSuccess(loginPresenter);
                    break;

                case DialogResult.Cancel:
                    MessageBox.Show("Ни хочиш нинада!!!111");
                    this.Close();
                    break;
                default:
                    MessageBox.Show("WAT?");
                    this.Close();
                    break;
            }            
        }

        public void SetUserInfo(string name, string nick)
        {
            nameLabel.Text = name;
            nickLabel.Text = nick;
        }
    }
}
