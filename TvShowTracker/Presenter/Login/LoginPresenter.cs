using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowTracker.View.Login;

namespace TvShowTracker.Presenter.Login
{
    public class LoginPresenter : ILoginPresenter
    {
        public void AttachView(ILoginView view)
        {
            view.LoginClicked += View_LoginClicked;
            view.CancelClicked += View_CancelClicked;
        }

        private void View_CancelClicked(ILoginView sender)
        {
            sender.ShowIncorretUserError(); 
        }

        private void View_LoginClicked(ILoginView sender)
        {
            sender.ShowIncorretUserError();
        }
    }
}
