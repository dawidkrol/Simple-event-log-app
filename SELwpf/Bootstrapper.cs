using Caliburn.Micro;
using SELwpf.Models;
using SELwpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SELwpf
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _simpleContainer;

        public Bootstrapper()
        {
            _simpleContainer = new SimpleContainer();
            Initialize();
        }

        protected override void Configure()
        {
            _simpleContainer.Instance(_simpleContainer);

            _simpleContainer
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IDetailsModel, DetailsModel>();

            GetType().Assembly.GetTypes()
                .Where(x => x.IsClass)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewmodel => _simpleContainer.RegisterPerRequest(viewmodel,viewmodel.ToString(),viewmodel));
                
        }

        protected override object GetInstance(Type service, string key)
        {
            return _simpleContainer.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _simpleContainer.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _simpleContainer.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
