using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.Model;
using TvShowTracker.Presenter.Login;
using TvShowTracker.View;

namespace TvShowTracker.Presenter.Main
{
    public class MainPresenter : IMainPresenter
    {
        IMainView view;
        User loggedIn;

        public void AttachView(IMainView mainView)
        {
            this.view = mainView;
        }

        public void LoginSuccess(ILoginPresenter presenter)
        {
            loggedIn = presenter.LoggedInUser;
            view.SetUserInfo(loggedIn.FirstName, loggedIn.Nick);            
        }
    }
}
