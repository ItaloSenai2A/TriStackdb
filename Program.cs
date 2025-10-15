using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TriStack.Services;
using TriStackdb.Data;
using TriStackdb.Models; // ?? Certifique-se que este namespace corresponde ao local das suas Models

var builder = WebApplication.CreateBuilder(args);

// CONFIGURAÇÃO DO BANCO DE DADOS
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CONFIGURAÇÃO DO IDENTITY
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAlertService, AlertService>();
var app = builder.Build();

// ?? SEED DE DADOS INICIAIS (TipoAlerta e ConfigAlerta)
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Garantir que o banco existe
    ctx.Database.EnsureCreated();

    if (!ctx.TipoAlertas.Any())
    {
        ctx.TipoAlertas.AddRange(
            new TipoAlerta { Descricao = "Incêndio" },
            new TipoAlerta { Descricao = "Enchente" },
            new TipoAlerta { Descricao = "Tempestade" },
            new TipoAlerta { Descricao = "Praga" }
        );
    }

    if (!ctx.ConfigAlertas.Any())
    {
        ctx.ConfigAlertas.AddRange(
            new ConfigAlerta { Nome = "Incêndio", Temperatura = 38, Ar = 15 },
            new ConfigAlerta { Nome = "Enchente", Agua = 95 },
            new ConfigAlerta { Nome = "Tempestade", Vento = 70, Ar = 70 },
            new ConfigAlerta { Nome = "Praga", Solo = 55 }
        );
    }

    ctx.SaveChanges();
}

// PIPELINE PADRÃO MVC + IDENTITY
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// ROTAS MVC E RAZOR PAGES
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
