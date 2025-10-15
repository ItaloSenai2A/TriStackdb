using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Equipamento> Equipamentos { get; set; } = default!;
    public DbSet<EquipamentoCliente> EquipamentosClientes { get; set; } = default!;
    public DbSet<HistoricoEquipamento> HistoricoEquipamentos { get; set; } = default!;
    public DbSet<VisaoGeral> VisaoGeral { get; set; } = default!;
    public DbSet<TipoAlerta> TipoAlertas { get; set; } = default!;
    public DbSet<ConfigAlerta> ConfigAlertas { get; set; } = default!;
    public DbSet<AlertasEquipamento> AlertasEquipamentos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Exemplo: configurar chaves/relacionamentos se quiser forçar nomes
        builder.Entity<Equipamento>().HasKey(e => e.EquipamentoId);
        builder.Entity<EquipamentoCliente>().HasKey(ec => ec.EquipamentoClienteId);
        // demais configurações são opcionais; EF deduz a maior parte automaticamente.
    }
}
