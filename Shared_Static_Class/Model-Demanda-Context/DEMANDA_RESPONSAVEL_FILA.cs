using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared_Static_Class.Data;

[Table("DEMANDA_ACESSO_RESPONSAVEL_UF", Schema = "Demandas")]
public partial class DEMANDA_ACESSO_RESPONSAVEL_UF
{
    [Key]
    public int ID { get; set; }

    public int MATRICULA_RESPONSAVEL { get; set; }

    public string UF { get; set; }
    public ACESSOS_MOBILE Responsavel { get; set; }

}