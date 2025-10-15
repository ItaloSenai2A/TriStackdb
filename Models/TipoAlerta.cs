using TriStackdb.Models;

public class TipoAlerta
{
    public long TipoAlertaId { get; set; }
    public string? Descricao { get; set; }

    public ICollection<AlertasEquipamento>? Alertas { get; set; }
}
