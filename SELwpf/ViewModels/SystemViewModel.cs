using System.Diagnostics;
using System.ComponentModel;
using Caliburn.Micro;

namespace SELwpf.ViewModels
{
    public class SystemViewModel : Screen
    {
        EventLog _eventLog;
        public SystemViewModel()
        {
            _eventLog = new EventLog("System");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
        }

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
