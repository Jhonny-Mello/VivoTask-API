using System;
using System.Collections.Generic;
using System.Text;

namespace Shared_Razor_Components.FundamentalModels
{
    public class DynamicDataTableViewModel
    {
        public List<string> Headers { get; set; }
        public List<List<string>> Rows { get; set; }
    }
}
