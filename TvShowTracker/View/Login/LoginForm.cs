using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvShowTracker.View.Login;

namespace TvShowTracker
{
    public partial class LoginForm : Form, ILoginView
    {
        #region Constructors

        public LoginForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events
        public event LoginViewEventHandler CancelClicked;
        public event LoginViewEventHandler LoginClicked;
        #endregion

        #region Properties
        public string LoginName
        {
            get
            {
                return userNameTextBox.Text;
            }

            set
            {
                userNameTextBox.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return passwordTextBox.Text;
            }

            set
            {
                passwordTextBox.Text = value;
            }
        }
        #endregion
        
        public void ShowIncorretUserError()
        {
            MessageBox.Show("User name or password incorrect!");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            OnLogin();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnCancel();
        }

        private void OnLogin()
        {
            LoginClicked?.Invoke(this);
        }

        private void OnCancel()
        {
            CancelClicked?.Invoke(this);
        }

        public void OnSuccessfullLogin()
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
