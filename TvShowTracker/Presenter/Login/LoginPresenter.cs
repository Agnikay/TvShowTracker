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
            sender.ShowIncorretUserError(); 
        }

        private void View_LoginClicked(ILoginView sender)
        {
            LoginResult result = new LoginResult();
            try
            {
                result.User = repository.FindUserByLoginAndPassword(sender.LoginName, sender.Password);
                OnLoginResult(result);  
            }
            catch (UserNotFoundException ex)
            {
                sender.ShowIncorretUserError();
            }
        }

        private void NotifyLoginResult(LoginResult result)
        {
            OnLoginResult?.Invoke(result);
        }


        
    }
}
