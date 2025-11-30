using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Repositorios;

namespace source.Infrastructure.Seeding
{
    public class AppDataSeeder
    {
        private readonly IRepositorioEventoSismico eventoRepo;
        private readonly IRepositorioEstado estadoRepo;
        private readonly IRepositorioSismografo sismografoRepo;
        private static readonly Random random = new Random();

        private readonly string[] alcances = { "Regional", "Local", "Internacional" };
        private readonly string[] clasificaciones = { "Leve", "Moderado", "Fuerte", "Severo" };
        private readonly string[] origenes = { "Autodetección", "Manual", "Remoto", "Satélite" };
        private readonly string[] descripcionesMagnitud =
        {
            "Débil",
            "Ligero",
            "Fuerte",
            "Destructivo",
            "Legendario",
        };

        public AppDataSeeder(
            IRepositorioEventoSismico eventoRepo,
            IRepositorioEstado estadoRepo,
            IRepositorioSismografo sismografoRepo
        )
        {
            this.eventoRepo = eventoRepo;
            this.estadoRepo = estadoRepo;
            this.sismografoRepo = sismografoRepo;
        }

        public async Task SeedAsync()
        {
            if ((await eventoRepo.ObtenerTodosAsync()).Any())
                return;

            // Trae todos los estados
            // var estados = (await estadoRepo.ObtenerTodosAsync()).ToList();

            //Solo trae "AutoDetectado" y "PendienteRevision"
            var estados = (await estadoRepo.ObtenerEstadosInicialesAsync()).ToList();
            var sismografos = (await sismografoRepo.ObtenerTodosAsync()).ToList();

            var tipoDatos = new List<TipoDeDato>
            {
                new TipoDeDato("Velocidad de onda", "km/seg", 3.5),
                new TipoDeDato("Frecuencia de onda", "Hz", 0.1),
                new TipoDeDato("Longitud", "km/ciclo", 10),
            };

            for (int i = 0; i < 5; i++)
            {
                var series = GenerarSerieTemporal(tipoDatos);
                // EventosSismicos con el estado TOTALMENTE aleatorio
                // var estadoAleatorio = estados[random.Next(estados.Count)];

                // El azar a sido modificado, jugamos a ser dios, solo estados
                // Autodetectado o PendienteRevision
                int indice = random.Next(0, 2);
                var estadoAleatorio = estados[indice];
                var sismografo = sismografos[random.Next(sismografos.Count)];

                foreach (var serie in series)
                    sismografo.agregarSerieTemporal(serie);

                var evento = new EventoSismico(
                    DateTime.UtcNow.AddHours(-random.Next(1, 48)),
                    RandomCoord(-90, 90),
                    RandomCoord(-180, 180),
                    RandomCoord(-90, 90),
                    RandomCoord(-180, 180),
                    (float)Math.Round(random.NextDouble() * 10, 2),
                    series,
                    estadoAleatorio,
                    new ClasificacionSismo(
                        clasificaciones[random.Next(clasificaciones.Length)],
                        100,
                        500
                    ),
                    new AlcanceSismo(alcances[random.Next(alcances.Length)]),
                    new OrigenDeGeneracion(origenes[random.Next(origenes.Length)]),
                    new List<CambioEstado>(),
                    new MagnitudRichter(
                        Math.Round(random.NextDouble() * 9 + 1, 2),
                        descripcionesMagnitud[random.Next(descripcionesMagnitud.Length)]
                    )
                );

                await eventoRepo.AgregarAsync(evento);
            }

            await eventoRepo.GuardarCambiosAsync();
            await sismografoRepo.GuardarCambiosAsync();
        }

        private List<SerieTemporal> GenerarSerieTemporal(List<TipoDeDato> tipos)
        {
            var resultado = new List<SerieTemporal>();
            int cantidadSeries = random.Next(10, 15);

            for (int i = 0; i < cantidadSeries; i++)
            {
                var detalles = tipos
                    .Select(t => new DetalleMuestraSismica(random.Next(1, 10), t))
                    .ToList();
                var muestras = new List<MuestraSismica>
                {
                    new MuestraSismica(DateTime.UtcNow.AddMinutes(-i * 10), detalles),
                    new MuestraSismica(DateTime.UtcNow.AddMinutes(-i * 12), detalles),
                    new MuestraSismica(DateTime.UtcNow.AddMinutes(-i * 15), detalles),
                };

                resultado.Add(
                    new SerieTemporal(
                        false,
                        DateTime.UtcNow.AddMinutes(-i * 20),
                        DateTime.UtcNow.AddMinutes(-i * 10),
                        random.Next(30, 100),
                        muestras
                    )
                );
            }

            return resultado;
        }

        private float RandomCoord(double min, double max) =>
            (float)(min + random.NextDouble() * (max - min));
    }
}
