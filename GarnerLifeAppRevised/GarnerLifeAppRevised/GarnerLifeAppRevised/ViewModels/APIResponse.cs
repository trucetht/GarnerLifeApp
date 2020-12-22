using System;
using System.Collections.Generic;
using System.Text;

namespace GarnerLifeAppRevised.ViewModels
{
    class APIResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
