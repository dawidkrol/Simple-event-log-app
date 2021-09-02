﻿using Caliburn.Micro;
using SELwpf.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows;

namespace SELwpf.ViewModels
{
    public class ApplicationViewModel : Screen, ILogViewModel
    {
        private readonly EventLog _eventLog;
        private readonly IDetailsModel _detailsModel;
        private readonly IWindowManager _windowManager;
        private readonly DetailsViewModel _detailsViewModel;
        public ApplicationViewModel(IWindowManager windowManager, DetailsViewModel detailsViewModel, IDetailsModel detailsModel)
        {
            _eventLog = new EventLog("Application");
            _eventLog.EnableRaisingEvents = true;
            _eventLog.EntryWritten += newEntry;
            //_eventsList.RaiseListChangedEvents = true;
            _windowManager = windowManager;
            _detailsViewModel = detailsViewModel;
            _detailsModel = detailsModel;
        }
        private EventLogEntry _activeLogEntry;

        public EventLogEntry activeLogEntry
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

        public string activeLogEntryText
        {
            get
            {
                return activeLogEntry?.Message;
            }
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

        public bool CanShowDetails
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

        public async Task ShowDetails()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.Title = "Details";

            _detailsModel.LogInfo = activeLogEntry;

            await _windowManager.ShowDialogAsync(IoC.Get<DetailsViewModel>(), null, settings);
        }

    }
}
