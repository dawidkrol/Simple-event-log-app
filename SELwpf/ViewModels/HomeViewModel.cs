using Caliburn.Micro;
using System;

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
