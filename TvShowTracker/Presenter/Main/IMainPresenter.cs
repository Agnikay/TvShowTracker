using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.Presenter.Login;
using TvShowTracker.View;

namespace TvShowTracker.Presenter.Main
{
    public interface IMainPresenter
    {
        void AttachLogin(ILoginPresenter presenter);
        void AttachView(IMainView mainView);
    }
}
