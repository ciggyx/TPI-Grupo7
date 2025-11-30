using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioEstacionSismologica : IRepositorioEstacionSismologica
    {
        private readonly AppDbContext _context;

        public RepositorioEstacionSismologica(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EstacionSismologica?> ObtenerPorIdAsync(int id)
        {
            return await _context.EstacionesSismologicas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<EstacionSismologica>> ObtenerTodosAsync()
        {
            return await _context.EstacionesSismologicas.ToListAsync();
        }

        public async Task AgregarAsync(EstacionSismologica entidad)
        {
            await _context.EstacionesSismologicas.AddAsync(entidad);
        }

        public void Actualizar(EstacionSismologica entidad)
        {
            _context.EstacionesSismologicas.Update(entidad);
        }

        public void Eliminar(EstacionSismologica entidad)
        {
            _context.EstacionesSismologicas.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
