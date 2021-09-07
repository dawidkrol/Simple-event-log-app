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
            message = _detailsModel?.LogInfo?.Message;
            userName = _detailsModel?.LogInfo?.UserName;
            time = _detailsModel?.LogInfo?.TimeGenerated;
            sourceName = _detailsModel?.LogInfo?.Source;
            categoryName = _detailsModel?.LogInfo?.Category;
        }
        public string message { get; }
        public string userName { get; }
        public DateTime? time { get; }
        public string sourceName { get; }
        public string categoryName { get; }
    }
}
