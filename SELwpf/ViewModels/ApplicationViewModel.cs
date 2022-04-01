using Caliburn.Micro;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class ApplicationViewModel : BaseLogViewModel
    {
        public ApplicationViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel) : base(windowManager, detailsViewModel, detailsModel)
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
        }
    }
}
