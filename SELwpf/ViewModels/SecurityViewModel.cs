using Caliburn.Micro;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class SecurityViewModel : BaseLogViewModel
    {
        public SecurityViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel) : base(windowManager, detailsViewModel, detailsModel)
        {
            _eventLog = new EventLog("Security");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
        }
    }
}
