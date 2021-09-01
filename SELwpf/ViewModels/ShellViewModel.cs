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
        public ShellViewModel(ApplicationViewModel applicationViewModel,SystemViewModel systemViewModel)
        {
            _aVM = applicationViewModel;
            _sVM = systemViewModel;
            _startTime = DateTime.Now;
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
    }
}
