using Caliburn.Micro;
using SELwpf.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;

namespace SELwpf.ViewModels
{
    public class BaseLogViewModel : Screen, ILogViewModel
    {
        internal readonly IWindowManager _windowManager;
        internal readonly DetailsViewModel _detailsViewModel;
        internal readonly IDetailsModel _detailsModel;
        internal EventLog _eventLog;

        public BaseLogViewModel(IWindowManager windowManager, DetailsViewModel detailsViewModel, IDetailsModel detailsModel)
        {
            _windowManager = windowManager;
            _detailsViewModel = detailsViewModel;
            _detailsModel = detailsModel;
        }

        private EventLogEntry _activeLogEntry;

        public virtual EventLogEntry activeLogEntry
        {
            get
            {
                return _activeLogEntry;
            }
            set
            {
                _activeLogEntry = value;
                NotifyOfPropertyChange(() => activeLogEntryText);
                NotifyOfPropertyChange(() => CanShowDetails);
            }
        }

        public virtual string activeLogEntryText
        {
            get
            {
                return activeLogEntry?.Source + " " + activeLogEntry?.TimeGenerated;
            }
        }

        public virtual bool CanShowDetails
        {
            get
            {
                bool output = false;

                if (activeLogEntry != null)
                {
                    output = true;
                }

                return output;
            }
        }

        private BindingList<EventLogEntry> _eventsList = new BindingList<EventLogEntry>();

        public virtual BindingList<EventLogEntry> EventsList
        {
            get { return _eventsList; }
            set
            {
                _eventsList = value;
                NotifyOfPropertyChange(() => EventsList);
            }
        }

        public virtual async Task ShowDetails()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.Title = "Details";

            _detailsModel.LogInfo = activeLogEntry;

            await _windowManager.ShowDialogAsync(IoC.Get<DetailsViewModel>(), null, settings);
        }

        internal virtual async void newEntry(object sender, EntryWrittenEventArgs e)
        {
            await App.Current.Dispatcher.InvokeAsync(() => EventsList?.Add(e.Entry));
        }
    }
}
