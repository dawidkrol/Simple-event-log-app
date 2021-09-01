using Caliburn.Micro;
using System.ComponentModel;
using System.Diagnostics;

namespace SELwpf.ViewModels
{
    public class ApplicationViewModel : Screen
    {
        EventLog _eventLog;
        public ApplicationViewModel()
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            _eventsList.RaiseListChangedEvents = true;
        }

        //TODO: Issue with no refreshing EventList in UI
        private BindingList<EventLogEntry> _eventsList = new BindingList<EventLogEntry>();

        public BindingList<EventLogEntry> EventsList
        {
            get { return _eventsList; }
            set
            {
                _eventsList = value;
                NotifyOfPropertyChange(() => EventsList);
            }
        }

        private void newEntry(object sender, EntryWrittenEventArgs e)
        {
            App.Current.Dispatcher.Invoke(() => EventsList?.Add(e.Entry));
        }
    }
}
