using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AppDbContext _context;

        public RepositorioUsuario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AgregarAsync(Usuario entidad)
        {
            await _context.Usuarios.AddAsync(entidad);
        }

        public void Actualizar(Usuario entidad)
        {
            _context.Usuarios.Update(entidad);
        }

        public void Eliminar(Usuario entidad)
        {
            _context.Usuarios.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
