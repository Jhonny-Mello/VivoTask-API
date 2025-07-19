using Shared_Static_Class.Converters;

namespace Shared_Static_Class.Model_DTO.FilterModels;

public class PainelChamadosModel
{
    public PainelChamadosModel()
    {
    }

    public PainelChamadosModel(int matricula, string regional, Controle_Demanda_role role, FilterDemandaPage filter)
    {
        this.matricula = matricula;
        this.regional = regional;
        this.role = role;
        this.filter = filter;
    }

    public int matricula { get; set; }
    public string regional { get; set; } = string.Empty;
    public Controle_Demanda_role role {  get; set; }
    public FilterDemandaPage filter { get; set; }
}