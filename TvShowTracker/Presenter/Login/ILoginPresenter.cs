using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.Model;
using TvShowTracker.View.Login;

namespace TvShowTracker.Presenter.Login
{
    public delegate void LoginResultHandler(LoginResult result);

    public class LoginResult
    {
        public User User { set; get; }
        public bool IsSuccessfull { set; get; }
        public string Reason { set; get; }
    }



    public interface ILoginPresenter : IBasePresenter<ILoginView>
    {
        User LoggedInUser { set; get; }

        event LoginResultHandler OnLoginResult;
    }
}
