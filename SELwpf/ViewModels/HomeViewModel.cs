using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELwpf.ViewModels
{
    public class HomeViewModel : Screen
    {
        public string WelcomeText
        {
            get => $"Welcome {Environment.UserName} in a Simple-event-log-app";
        }
        public string Description
        {
            get => "Here you can observe information about your system and applications.";
        }

    }
}
