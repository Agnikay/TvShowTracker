using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.Presenter.Login;
using TvShowTracker.View;

namespace TvShowTracker.Presenter.Main
{
    public class MainPresenter : IMainPresenter
    {
        IMainView view;
        public void AttachLogin(ILoginPresenter presenter)
        {
            presenter.OnLoginResult += Presenter_OnLoginResult;
        }

        public void AttachView(IMainView mainView)
        {
            this.view = mainView;
        }

        private void Presenter_OnLoginResult(LoginResult result)
        {
            
        }
    }
}
