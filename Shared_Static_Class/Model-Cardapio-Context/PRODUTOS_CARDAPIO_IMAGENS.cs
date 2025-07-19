using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;
using Shared_Static_Class.Model_Demanda_Context;
using Shared_Static_Class.Model_DTO;

namespace Shared_Static_Class.Data;

[Table("PRODUTOS_CARDAPIO_IMAGENS", Schema = "Cardapio")]
public partial class PRODUTO_IMAGEM
{
    public PRODUTO_IMAGEM()
    {
    }

    public PRODUTO_IMAGEM(byte[] imagem, Guid? id_produto = null)
    {
        ID_PRODUTO = id_produto ?? Guid.Empty;
        Imagem = imagem;
    }

    [Key]
    public Guid ID_IMAGEM { get; set; }
    public Guid ID_PRODUTO { get; set; }
    [Required]
    [NotNull]
    public byte[] Imagem { get; set; } = null;
    public PRODUTOS_CARDAPIO Produto { get; set; }   

}
