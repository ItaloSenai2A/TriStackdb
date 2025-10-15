public class AlertasEquipamento
{
    public long AlertasEquipamentoId { get; set; }

    public float? Latitude { get; set; }
    public float? Longitude { get; set; }

    public long? TipoAlertaId { get; set; }
    public TipoAlerta? TipoAlerta { get; set; }

    public DateTime? DataAlerta { get; set; }
}
