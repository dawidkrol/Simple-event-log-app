using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELwpf.ViewModels
{
    class ApplicationViewModel : Screen
    {
        EventLog _eventLog;
        public ApplicationViewModel()
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
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

        public string Last
        {
            get
            {
                return _eventLog.Entries[_eventLog.Entries.Count - 1].TimeGenerated.ToString("G");
            }
        }

        private void newEntry(object sender, EntryWrittenEventArgs e)
        {
            if (_eventsList.All(x => x.TimeGenerated != e.Entry.TimeGenerated))
            {
                NotifyOfPropertyChange(() => Last);
                EventsList.Add(e.Entry);
            }
        }
    }
}
