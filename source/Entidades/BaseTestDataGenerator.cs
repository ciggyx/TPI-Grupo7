using source.Entidades;
using source.Entidades.EventoSismo;

public class BaseTestDataGenerator
{
    private static Random random = new Random();

    public List<Estado> GenerarEstados()
    {
        return new List<Estado>
        {
            new Estado(Ambito.EventoSismico, Nombre.pendienteRevision),
            new Estado(Ambito.EventoSismico, Nombre.rechazado),
            new Estado(Ambito.EventoSismico, Nombre.autoDetectado)
        };

    }

    public List<EventoSismico> GenerarEventosSismicos(int cantidad = 10)
    {
        var tipoDatos = new List<TipoDeDato>
        {
            new TipoDeDato("Velocidad de onda", "km/seg", 7),
            new TipoDeDato("Frecuencia de onda", "Hz", 10),
            new TipoDeDato("Longitud", "km/ciclo", 0.7)
        };

        var empleado = new Empleado("Juan", "Pérez", "juan.perez@email.com", "3511234567");
        var usuario = new Usuario("juanperez", "juanperez123", empleado);
        var sesion = new Sesion(DateTime.Now, DateTime.Now.AddHours(2), usuario);

        var listaEstado = new List<Estado>
        {
            new Estado(Ambito.EventoSismico, Nombre.pendienteRevision),
            new Estado(Ambito.EventoSismico, Nombre.rechazado),
            new Estado(Ambito.EventoSismico, Nombre.autoDetectado)
        };

        var alcances = new[] { "Regional", "Local", "Internacional" };
        var clasificaciones = new[] { "Leve", "Moderado", "Fuerte", "Severo" };
        var origenes = new[] { "Autodetección", "Manual", "Remoto", "Satélite" };
        var descripcionesMagnitud = new[] { "Débil", "Ligero", "Fuerte", "Destructivo", "Legendario" };

        var eventos = new List<EventoSismico>();

        for (int i = 0; i < cantidad; i++)
        {
            var detalles = new List<DetalleMuestraSismica>();
            for (int j = 0; j < tipoDatos.Count; j++)
            {
                detalles.Add(new DetalleMuestraSismica(j + 1, tipoDatos[j]));
            }

            var muestra = new MuestraSismica(DateTime.Now.AddMinutes(-i * 10), detalles);

            var serie = new SerieTemporal(
                false,
                DateTime.Now.AddHours(-i),
                DateTime.Now.AddHours(-i + 1),
                random.Next(30, 100),
                new List<MuestraSismica> { muestra }
            );

            var estado = listaEstado[random.Next(listaEstado.Count)];
            var cambioEstado = new CambioEstado(DateTime.Now.AddMinutes(-i * 5), estado, empleado);

            var alcance = new AlcanceSismo(alcances[random.Next(alcances.Length)]);
            var clasificacion = new ClasificacionSismo(clasificaciones[random.Next(clasificaciones.Length)], random.Next(100, 1000), random.Next(100, 1000));
            var origen = new OrigenDeGeneracion(origenes[random.Next(origenes.Length)]);
            var magnitud = new MagnitudRichter(Math.Round(random.NextDouble() * 9 + 1, 2), descripcionesMagnitud[random.Next(descripcionesMagnitud.Length)]);

            var evento = new EventoSismico(
                DateTime.Now.AddHours(-random.Next(1, 48)),
                RandomCoord(-90, 90),    // lat epicentro
                RandomCoord(-180, 180),  // lng epicentro
                RandomCoord(-90, 90),    // lat hipocentro
                RandomCoord(-180, 180),  // lng hipocentro
                (float)Math.Round(random.NextDouble() * 30, 1), // profundidad
                new List<SerieTemporal> { serie },
                estado,
                clasificacion,
                alcance,
                origen,
                new List<CambioEstado> { cambioEstado },
                magnitud
            );

            eventos.Add(evento);
        }

        return eventos;
    }

    private float RandomCoord(double min, double max)
    {
        return (float)(min + random.NextDouble() * (max - min));
    }
}

