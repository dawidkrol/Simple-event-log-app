using Caliburn.Micro;
using Microsoft.Extensions.Logging;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class SecurityViewModel : BaseLogViewModel
    {
        private readonly ILog _logger;

        public SecurityViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel,
            ILog logger) : base(windowManager, detailsViewModel, detailsModel, logger)
        {
            _eventLog = new EventLog("Security");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            _logger = logger;
        }
    }
}
