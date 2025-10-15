using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class EquipamentoCliente
{
    public long EquipamentoClienteId { get; set; }

    public long? EquipamentoId { get; set; }
    public Equipamento? Equipamento { get; set; }

    // Link com Identity user
    public string? UserId { get; set; }
    public IdentityUser? User { get; set; }

    public DateTime? DataCompra { get; set; }
}
