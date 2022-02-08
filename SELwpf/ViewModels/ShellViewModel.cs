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
        ApplicationViewModel _aVM;
        SystemViewModel _sVM;
        SecurityViewModel _secVM;
        HomeViewModel _homeVM;

        public ShellViewModel(ApplicationViewModel applicationViewModel,SystemViewModel systemViewModel,SecurityViewModel securityViewModel,HomeViewModel homeViewModel)
        {
            _aVM = applicationViewModel;
            _sVM = systemViewModel;
            _secVM = securityViewModel;
            _homeVM = homeViewModel;
            _startTime = DateTime.Now;
            mHome();
        }
        public void mHome()
        {
            ActivateItemAsync(_homeVM);
        }
        private DateTime _startTime { get; set; }
        public string StartTime
        {
            get 
            {
                return _startTime.ToString("G");
            }
        }

        public void mSys()
        {
            ActivateItemAsync(_sVM);
        }
        public void mApp()
        {
            ActivateItemAsync(_aVM);
        }
        public void mSec()
        {
            ActivateItemAsync(_secVM);
        }
    }
}
