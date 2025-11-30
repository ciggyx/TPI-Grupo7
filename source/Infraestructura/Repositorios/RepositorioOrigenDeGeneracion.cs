using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioOrigenDeGeneracion : IRepositorioOrigenDeGeneracion
    {
        private readonly AppDbContext _context;

        public RepositorioOrigenDeGeneracion(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OrigenDeGeneracion?> ObtenerPorIdAsync(int id)
        {
            return await _context.OrigenesDeGeneracion.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<OrigenDeGeneracion>> ObtenerTodosAsync()
        {
            return await _context.OrigenesDeGeneracion.ToListAsync();
        }

        public async Task AgregarAsync(OrigenDeGeneracion entidad)
        {
            await _context.OrigenesDeGeneracion.AddAsync(entidad);
        }

        public void Actualizar(OrigenDeGeneracion entidad)
        {
            _context.OrigenesDeGeneracion.Update(entidad);
        }

        public void Eliminar(OrigenDeGeneracion entidad)
        {
            _context.OrigenesDeGeneracion.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
