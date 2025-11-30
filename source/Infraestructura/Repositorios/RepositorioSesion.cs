using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioSesion : IRepositorioSesion
    {
        private readonly AppDbContext _context;

        public RepositorioSesion(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Sesion?> ObtenerPorIdAsync(int id)
        {
            return await _context
                .Sesiones.Include(s => s.UsuarioLogueado)
                .ThenInclude(u => u.EmpleadoLogueado)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sesion>> ObtenerTodosAsync()
        {
            return await _context.Sesiones.ToListAsync();
        }

        public async Task AgregarAsync(Sesion entidad)
        {
            await _context.Sesiones.AddAsync(entidad);
        }

        public void Actualizar(Sesion entidad)
        {
            _context.Sesiones.Update(entidad);
        }

        public void Eliminar(Sesion entidad)
        {
            _context.Sesiones.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync()
        {
            return await _context.Sesiones.AnyAsync();
        }
    }
}
