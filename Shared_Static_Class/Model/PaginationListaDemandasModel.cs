using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;

namespace Shared_Razor_Components.FundamentalModels
{
    public class PaginationListaDemandasModel
    {
        public string matricula { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
