using Caliburn.Micro;
using Microsoft.Extensions.Logging;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class ApplicationViewModel : BaseLogViewModel
    {
        private readonly ILog _logger;

        public ApplicationViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel,
            ILog logger) : base(windowManager, detailsViewModel, detailsModel, logger)
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            _logger = logger;
        }
    }
}
