using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriStack.Data;
using TriStack.Models;

namespace TriStack.Services
{
    public interface IAlertService
    {
        Task VerificarEEnviarAsync(HistoricoEquipamento leitura);
    }

    public class AlertService : IAlertService
    {
        private readonly ApplicationDbContext _ctx;

        public AlertService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task VerificarEEnviarAsync(HistoricoEquipamento leitura)
        {
            var configs = await _ctx.ConfigAlertas.ToListAsync();

            foreach (var cfg in configs)
            {
                bool disparar = false;

                if (cfg.Temperatura.HasValue && leitura.Temperatura.HasValue && leitura.Temperatura >= cfg.Temperatura)
                    disparar = true;

                if (cfg.Agua.HasValue && leitura.Agua.HasValue && leitura.Agua >= cfg.Agua)
                    disparar = true;

                if (cfg.Ar.HasValue && leitura.Ar.HasValue && leitura.Ar <= cfg.Ar)
                    disparar = true;

                if (cfg.Vento.HasValue && leitura.Vento.HasValue && leitura.Vento >= cfg.Vento)
                    disparar = true;

                if (cfg.Solo.HasValue && leitura.Solo.HasValue && leitura.Solo >= cfg.Solo)
                    disparar = true;

                if (disparar)
                {
                    var tipo = await _ctx.TipoAlertas.FirstOrDefaultAsync(t => t.Descricao == cfg.Nome);

                    if (tipo != null)
                    {
                        _ctx.AlertasEquipamentos.Add(new AlertasEquipamento
                        {
                            Latitude = leitura.Latitude,
                            Longitude = leitura.Longitude,
                            TipoAlerta = tipo,
                            DataAlerta = DateTime.UtcNow
                        });

                        // Aqui é onde você pode chamar uma notificação real (e-mail, SignalR, etc.)
                        Console.WriteLine($"⚠️ Alerta disparado: {cfg.Nome} em ({leitura.Latitude}, {leitura.Longitude})");
                    }
                }
            }

            await _ctx.SaveChangesAsync();
        }
    }
}
