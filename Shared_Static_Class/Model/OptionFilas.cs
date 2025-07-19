namespace Shared_Razor_Components.FundamentalModels
{
    public class OptionFilas(int iD, string name, string dESCRICAO)
    {
        public int ID { get; set; } = iD;
        public string Name { get; set; } = name;
        public string DESCRICAO { get; set; } = dESCRICAO;
    }
}