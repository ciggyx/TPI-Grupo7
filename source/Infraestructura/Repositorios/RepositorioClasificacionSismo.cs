using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioClasificacionSismo : IRepositorioClasificacionSismo
    {
        private readonly AppDbContext _context;

        public RepositorioClasificacionSismo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClasificacionSismo?> ObtenerPorIdAsync(int id)
        {
            return await _context.ClasificacionesSismo.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<ClasificacionSismo>> ObtenerTodosAsync()
        {
            return await _context.ClasificacionesSismo.ToListAsync();
        }

        public async Task AgregarAsync(ClasificacionSismo entidad)
        {
            await _context.ClasificacionesSismo.AddAsync(entidad);
        }

        public void Actualizar(ClasificacionSismo entidad)
        {
            _context.ClasificacionesSismo.Update(entidad);
        }

        public void Eliminar(ClasificacionSismo entidad)
        {
            _context.ClasificacionesSismo.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
