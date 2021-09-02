using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SELwpf.ViewModels
{
    public interface ILogViewModel
    {
        EventLogEntry activeLogEntry { get; set; }
        string activeLogEntryText { get; }
        bool CanShowDetails { get; }
        BindingList<EventLogEntry> EventsList { get; set; }

        Task ShowDetails();
    }
}