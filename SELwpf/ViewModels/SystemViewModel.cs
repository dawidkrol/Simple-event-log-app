using Caliburn.Micro;
using Microsoft.Extensions.Logging;
using SELwpf.Models;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class SystemViewModel : BaseLogViewModel
    {
        private readonly ILog _logger;

        public SystemViewModel(IWindowManager windowManager,
            DetailsViewModel detailsViewModel,
            IDetailsModel detailsModel,
            ILog logger) : base(windowManager, detailsViewModel, detailsModel, logger)
        {
            _eventLog = new EventLog("System");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            _logger = logger;
        }

    }
}
