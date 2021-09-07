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
        public ShellViewModel(ApplicationViewModel applicationViewModel,SystemViewModel systemViewModel,SecurityViewModel securityViewModel)
        {
            _aVM = applicationViewModel;
            _sVM = systemViewModel;
            _secVM = securityViewModel;
            _startTime = DateTime.Now;
        }
        public bool CanmHome
        {
            get
            {
                return false;
            }
        }
        public void mHome()
        {

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
