using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELwpf.Models
{
    public class DetailsModel : IDetailsModel
    {
        public EventLogEntry LogInfo { get; set; }
    }
}
