using System.ComponentModel.DataAnnotations;
using TriStackdb.Models;

public class Equipamento
{
    public long EquipamentoId { get; set; }

    public string? Descricao { get; set; }

    public float? Temperatura { get; set; }
    public float? Ar { get; set; }
    public float? Agua { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public float? Vento { get; set; }
    public float? Luz { get; set; }
    public float? Solo { get; set; }

    // Navegação
    public ICollection<EquipamentoCliente>? EquipamentosClientes { get; set; }
    public ICollection<HistoricoEquipamento>? Historicos { get; set; }
    public ICollection<AlertasEquipamento>? Alertas { get; set; }
}
