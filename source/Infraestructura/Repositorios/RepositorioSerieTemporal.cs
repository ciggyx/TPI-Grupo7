using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioSerieTemporal : IRepositorioSerieTemporal
    {
        private readonly AppDbContext _context;

        public RepositorioSerieTemporal(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SerieTemporal?> ObtenerPorIdAsync(int id)
        {
            return await _context.SeriesTemporales.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SerieTemporal>> ObtenerTodosAsync()
        {
            return await _context.SeriesTemporales.ToListAsync();
        }

        public async Task AgregarAsync(SerieTemporal entidad)
        {
            await _context.SeriesTemporales.AddAsync(entidad);
        }

        public void Actualizar(SerieTemporal entidad)
        {
            _context.SeriesTemporales.Update(entidad);
        }

        public void Eliminar(SerieTemporal entidad)
        {
            _context.SeriesTemporales.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
