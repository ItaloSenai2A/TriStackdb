public class HistoricoEquipamento
{
    public long HistoricoEquipamentoId { get; set; }

    public long? EquipamentoId { get; set; }
    public Equipamento? Equipamento { get; set; }

    public string? Descricao { get; set; }
    public float? Temperatura { get; set; }
    public float? Ar { get; set; }
    public float? Agua { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public float? Vento { get; set; }
    public float? Luz { get; set; }
    public float? Solo { get; set; }

    public DateTime? DataLeitura { get; set; }
}
