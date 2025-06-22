using source.Entidades;
using source.Entidades.EventoSismo;

public class BaseTestDataGenerator
{
    private static Random random = new Random();

    public Sesion GenerarSesion()
    {
        var empleado = new Empleado("Juan", "Pérez", "juan.perez@email.com", "3511234567");
        var usuario = new Usuario("juanperez", "juanperez123", empleado);
        var sesion = new Sesion(DateTime.Now, DateTime.Now.AddHours(2), usuario);
        return sesion;
    }

    public List<Estado> GenerarEstados()
    {
        return new List<Estado>
        {
            new Estado(Ambito.EventoSismico, Nombre.PendienteRevision),
            new Estado(Ambito.EventoSismico, Nombre.Rechazado),
            new Estado(Ambito.EventoSismico, Nombre.AutoDetectado),
            new Estado(Ambito.EventoSismico, Nombre.BloqueadoRevision),
            new Estado(Ambito.EventoSismico, Nombre.Confirmado)
        };

    }

    public List<Sismografo> GenerarSismografos(List<SerieTemporal> listaSerieTemporal)
    {
        var listaEstacionSismologica = new List<EstacionSismologica>
        {
            new EstacionSismologica("Estacion 001", "E001"),
            new EstacionSismologica("Estacion 002", "E002"),
            new EstacionSismologica("Estacion 003", "E003")
        };

        var listaSismografos = new List<Sismografo>
        {
            new Sismografo(listaEstacionSismologica[0]),
            new Sismografo(listaEstacionSismologica[1]),
            new Sismografo(listaEstacionSismologica[2]),
        };

        foreach (SerieTemporal serieTemporal in listaSerieTemporal)
        {
            int indice = random.Next(0, listaSismografos.Count);
            var sismografoSeleccionado = listaSismografos[indice];
            sismografoSeleccionado.agregarSerieTemporal(serieTemporal);
        }

        return listaSismografos;
    }

    public List<EventoSismico> GenerarEventosSismicos(int cantidad)
    {
        var tipoDatos = new List<TipoDeDato>
    {
        new TipoDeDato("Velocidad de onda", "km/seg", 3.5),
        new TipoDeDato("Frecuencia de onda", "Hz", 0.1),
        new TipoDeDato("Longitud", "km/ciclo", 10)
    };

        var empleado = new Empleado("Juan", "Pérez", "juan.perez@email.com", "3511234567");
        var usuario = new Usuario("juanperez", "juanperez123", empleado);
        var sesion = new Sesion(DateTime.Now, DateTime.Now.AddHours(2), usuario);

        var listaEstado = new List<Estado>
    {
        new Estado(Ambito.EventoSismico, Nombre.PendienteRevision),
        new Estado(Ambito.EventoSismico, Nombre.AutoDetectado)
    };

        var alcances = new[] { "Regional", "Local", "Internacional" };
        var clasificaciones = new[] { "Leve", "Moderado", "Fuerte", "Severo" };
        var origenes = new[] { "Autodetección", "Manual", "Remoto", "Satélite" };
        var descripcionesMagnitud = new[] { "Débil", "Ligero", "Fuerte", "Destructivo", "Legendario" };

        var eventos = new List<EventoSismico>();

        for (int i = 0; i < cantidad; i++)
        {
            int cantidadSeries = 2;// random.Next(10, 15);

            var seriesTemporales = new List<SerieTemporal>();

            for (int k = 0; k < cantidadSeries; k++)
            {
                var detalles = new List<DetalleMuestraSismica>();
                for (int j = 0; j < 3; j++)
                {
                    detalles.Add(new DetalleMuestraSismica(random.Next(1, 10), tipoDatos[j]));
                }

                var muestra = new MuestraSismica(DateTime.Now.AddMinutes(-i * 10), detalles);
                var muestra2 = new MuestraSismica(DateTime.Now.AddMinutes(-i * 10), detalles);

                var serie = new SerieTemporal(
                    false,
                    DateTime.Now.AddHours(-i - k), // Puedes ajustar la hora para diferenciar las series
                    DateTime.Now.AddHours(-i - k + 1),
                    random.Next(30, 100),
                    new List<MuestraSismica> { muestra, muestra2 }
                );

                seriesTemporales.Add(serie);
            }

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
                (float)Math.Round(random.NextDouble() * 10, 2), // profundidad
                seriesTemporales, // Aquí asignamos la lista con múltiples series temporales
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

