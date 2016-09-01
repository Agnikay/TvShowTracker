using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.Model;
using TvShowTracker.Model.DataAccess;
using TvShowTracker.View.Login;

namespace TvShowTracker.Presenter.Login
{
    public class LoginPresenter : ILoginPresenter
    {
        IUserRepository repository;

        public event LoginResultHandler OnLoginResult;

        public User LoggedInUser { set; get; }

        public void AttachView(ILoginView view)
        {
            view.LoginClicked += View_LoginClicked;
            view.CancelClicked += View_CancelClicked;
        }

        public LoginPresenter()
        {
            repository = new UserRepository();
        }

        private void View_CancelClicked(ILoginView sender)
        {
            sender.CloseView();
        }

        private void View_LoginClicked(ILoginView sender)
        {
            try
            {
                LoggedInUser = repository.FindUserByLoginAndPassword(sender.LoginName, sender.Password);
                sender.OnSuccessfullLogin();
            }
            catch (UserNotFoundException ex)
            {
                sender.ShowIncorretUserError();
            }

            catch (Exception ex)
            {
                sender.ShowConnectionError();
            }
        }

        private void NotifyLoginResult(LoginResult result)
        {
            OnLoginResult?.Invoke(result);
        }


        
    }
}
