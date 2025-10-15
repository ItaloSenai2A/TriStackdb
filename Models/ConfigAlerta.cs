public class ConfigAlerta
{
    public long ConfigAlertaId { get; set; }

    public string? Nome { get; set; }

    // Valores de referência para disparo de alerta. Use nullable para permitir ausência.
    public float? Temperatura { get; set; }  // ex: >=35
    public float? Ar { get; set; }          // ex: < 15
    public float? Vento { get; set; }
    public float? Agua { get; set; }        // ex: >= 95
    public float? Solo { get; set; }
    public float? Luz { get; set; }
}
