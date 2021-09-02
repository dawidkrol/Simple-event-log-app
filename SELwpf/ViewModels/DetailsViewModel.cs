using Caliburn.Micro;
using SELwpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SELwpf.ViewModels
{
    public class DetailsViewModel
    {
        IDetailsModel _detailsModel;
        public DetailsViewModel(IDetailsModel detailsModel)
        {
            _detailsModel = detailsModel;
            mess = _detailsModel?.LogInfo?.TimeGenerated.ToString("G");
        }
        private string _mess;

        public string mess
        {
            get { return _mess; }
            set { _mess = value; }
        }
    }
}
