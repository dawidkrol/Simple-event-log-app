using Caliburn.Micro;
using System;

namespace SELwpf.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        ApplicationViewModel _aVM;
        SystemViewModel _sVM;
        SecurityViewModel _secVM;
        HomeViewModel _homeVM;
        private readonly ILog _logger;

        public ShellViewModel(ApplicationViewModel applicationViewModel,
            SystemViewModel systemViewModel, SecurityViewModel securityViewModel,
            HomeViewModel homeViewModel,
            ILog logger)
        {
            _aVM = applicationViewModel;
            _sVM = systemViewModel;
            _secVM = securityViewModel;
            _homeVM = homeViewModel;
            _logger = logger;
            _startTime = DateTime.Now;
            mHome();
        }
        public void mHome()
        {
            ActivateItemAsync(_homeVM);
            _logger.Info("Activating HomeViewModel");
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
            _logger.Info("Activating SystemViewModel");
        }
        public void mApp()
        {
            ActivateItemAsync(_aVM);
            _logger.Info("Activating ApplicationViewModel");
        }
        public void mSec()
        {
            ActivateItemAsync(_secVM);
            _logger.Info("Activating SecurityViewModel");
        }
    }
}
