using source.Domain.Entities;
using source.Dominio.Entidades.PatronState;
using source.Repositorios;

namespace source.Infrastructure.Seeding
{
    public class StaticDataSeeder
    {
        private readonly IRepositorioEstado estadoRepo;
        private readonly IRepositorioSismografo sismografoRepo;
        private readonly IRepositorioSesion sesionRepo;

        public StaticDataSeeder(
            IRepositorioEstado estadoRepo,
            IRepositorioSismografo sismografoRepo,
            IRepositorioSesion sesionRepo
        )
        {
            this.estadoRepo = estadoRepo;
            this.sismografoRepo = sismografoRepo;
            this.sesionRepo = sesionRepo;
        }

        public async Task SeedAsync()
        {
            if (!await estadoRepo.AnyAsync())
            {
                var estados = new List<Estado>
                {
                    PendienteRevision.Revisar(),
                    AutoDetectado.Crear(),
                    BloqueadoEnRevision.Bloquear(),
                    Rechazado.Rechazar(),
                    Confirmado.ConfirmarDirecto(),
                };
                foreach (var e in estados)
                    await estadoRepo.AgregarAsync(e);
                await estadoRepo.GuardarCambiosAsync();
            }

            if (!await sismografoRepo.AnyAsync())
            {
                var estaciones = new[]
                {
                    new EstacionSismologica("Estacion 001", "E001"),
                    new EstacionSismologica("Estacion 002", "E002"),
                    new EstacionSismologica("Estacion 003", "E003"),
                };

                var sismografos = estaciones.Select(e => new Sismografo(e)).ToList();

                foreach (var s in sismografos)
                    await sismografoRepo.AgregarAsync(s);
                await sismografoRepo.GuardarCambiosAsync();
            }

            if (!await sesionRepo.AnyAsync())
            {
                var empleado = new Empleado("Juan", "Pérez", "juan.perez@email.com", "3511234567");
                var usuario = new Usuario("juanperez", "juanperez123", empleado);
                var sesion = new Sesion(DateTime.UtcNow, DateTime.UtcNow.AddHours(2), usuario);

                await sesionRepo.AgregarAsync(sesion);
                await sesionRepo.GuardarCambiosAsync();
            }
        }
    }
}
