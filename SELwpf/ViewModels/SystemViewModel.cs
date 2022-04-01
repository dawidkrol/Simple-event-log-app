using Caliburn.Micro;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class SystemViewModel : BaseLogViewModel
    {
        public SystemViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel) : base(windowManager, detailsViewModel, detailsModel)
        {
            _eventLog = new EventLog("System");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
        }

    }
}
