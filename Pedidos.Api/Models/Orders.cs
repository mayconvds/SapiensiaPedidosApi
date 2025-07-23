using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pedidos.Api.Models;

[Table("Orders", Schema = "Orders")]
public class Orders
{
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    // [Column("Produto")]
    // public string? Produto { get; set; }
    //
    // [Column("Quantidade")] 
    // public int Quantidade { get; set; } = 1;
    //
    // [Column("Valor")]
    // public decimal Valor { get; set; }
}