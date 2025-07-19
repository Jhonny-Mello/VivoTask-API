using Shared_Static_Class.Data;
using Shared_Static_Class.Model_DTO;

namespace Shared_Razor_Components.FundamentalModels
{
    public class FilterDemandasModel
    {
        public IEnumerable<DROPDOWN_FILA_MODEL> fila { get; set; }
        public IEnumerable<ACESSO> analistassuporte { get; set; }
        public IEnumerable<string> status { get; set; }
    }
}
