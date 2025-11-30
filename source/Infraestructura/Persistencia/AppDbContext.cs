using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Dominio.Entidades.PatronState;

public class AppDbContext : DbContext
{
    public DbSet<MagnitudRichter> MagnitudRichter { get; set; } = null!;
    public DbSet<EventoSismico> EventosSismicos { get; set; } = null!;
    public DbSet<Estado> Estados { get; set; } = null!;
    public DbSet<CambioEstado> CambiosEstado { get; set; } = null!;
    public DbSet<ClasificacionSismo> ClasificacionesSismo { get; set; } = null!;
    public DbSet<AlcanceSismo> AlcancesSismo { get; set; } = null!;
    public DbSet<OrigenDeGeneracion> OrigenesDeGeneracion { get; set; } = null!;
    public DbSet<SerieTemporal> SeriesTemporales { get; set; } = null!;
    public DbSet<TipoDeDato> TiposDeDato { get; set; } = null!;
    public DbSet<MuestraSismica> MuestrasSismicas { get; set; } = null!;
    public DbSet<DetalleMuestraSismica> DetallesMuestrasSismicas { get; set; } = null!;
    public DbSet<Empleado> Empleados { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Sesion> Sesiones { get; set; } = null!;
    public DbSet<Sismografo> Sismografos { get; set; } = null!;
    public DbSet<EstacionSismologica> EstacionesSismologicas { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // Este método es necesario porque sino EF Core no sabe
    // como diferenciar entre los que implementar la clase Estado.
    // En este caso usamos un "Discriminador" para diferenciarse entre sí
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Estado>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<PendienteRevision>("PendienteRevision")
            .HasValue<AutoDetectado>("AutoDetectado")
            .HasValue<BloqueadoEnRevision>("BloqueadoEnRevision")
            .HasValue<Rechazado>("Rechazado")
            .HasValue<Confirmado>("Confirmado");
    }
}
