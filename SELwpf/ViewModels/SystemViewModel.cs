using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using Caliburn.Micro;

namespace SELwpf.ViewModels
{
    class SystemViewModel : Screen
    {
        EventLog _eventLog;
        public SystemViewModel()
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            //EventsList = new BindingList<string>(EventLog.GetEventLogs("System").Select(x => x.LogDisplayName).ToList());
            //var a = EventLog.GetEventLogs("System");//.Select(x => x.LogDisplayName);
            //Console.WriteLine(a);

            //var a = EventLog.GetEventLogs();
            //var b = a[0].Entries;
            //foreach (EventLogEntry item in b)
            //{
            //    EventsList.Add(item.TimeGenerated);
            //}
        }
        //private BindingList<DateTime> _eventsList = new BindingList<DateTime>();

        //public BindingList<DateTime> EventsList
        //{
        //    get { return _eventsList; }
        //    set
        //    {
        //        _eventsList = value;
        //        //NotifyOfPropertyChange(() => EventsList);
        //    }
        //}

        public string Last
        {
            get
            {
                return _eventLog.Entries[_eventLog.Entries.Count - 1].TimeGenerated.ToString("G");
            }
        }


        private void newEntry(object sender, EntryWrittenEventArgs e)
        {
            NotifyOfPropertyChange(() => Last);
            //DateTime dateTime = new DateTime(e.Entry.TimeGenerated.Ticks);
            //EventsList.Add(dateTime);
            //NotifyOfPropertyChange(() => EventsList);
        }
    }
}
