using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioEventoSismico : IRepositorioEventoSismico
    {
        private readonly AppDbContext _context;

        public RepositorioEventoSismico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EventoSismico?> ObtenerPorIdAsync(int id)
        {
            return await _context.EventosSismicos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<EventoSismico>> ObtenerTodosAsync()
        {
            return await _context.EventosSismicos.ToListAsync();
        }

        public async Task AgregarAsync(EventoSismico entidad)
        {
            await _context.EventosSismicos.AddAsync(entidad);
        }

        public void Actualizar(EventoSismico entidad)
        {
            _context.EventosSismicos.Update(entidad);
        }

        public void Eliminar(EventoSismico entidad)
        {
            _context.EventosSismicos.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventoSismico>> ObtenerTodosConSeriesAsync()
        {
            return await _context
                .EventosSismicos.Include(e => e.SerieTemporal)
                .ThenInclude(s => s.MuestraSismica)
                .ThenInclude(m => m.DetalleMuestraSismica)
                .ThenInclude(d => d.TipoDeDato)
                .Include(e => e.Magnitud)
                .Include(e => e.ClasificacionSismo)
                .Include(e => e.AlcanceSismo)
                .Include(e => e.OrigenDeGeneracion)
                .Include(e => e.Estado)
                .Include(e => e.ListaCambioEstado)
                .ThenInclude(c => c.Estado)
                .ToListAsync();
        }
    }
}
