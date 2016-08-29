using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvShowTracker.View.Login
{
    public delegate void LoginViewEventHandler(ILoginView sender);

    public interface ILoginView
    {
        string LoginName { set; get; }

        string Password { set; get; }

        void ShowIncorretUserError();

        void OnSuccessfullLogin();

        event LoginViewEventHandler LoginClicked;

        event LoginViewEventHandler CancelClicked;
    }
}
