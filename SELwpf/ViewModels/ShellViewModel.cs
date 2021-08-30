using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELwpf.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            //ActivateItemAsync(IoC.Get<LoginViewModel>());
        }
        public void mHome()
        {

        }
        public void mSys()
        {
            ActivateItemAsync(IoC.Get<SystemViewModel>());
        }
        public void mApp()
        {

        }
    }
}
