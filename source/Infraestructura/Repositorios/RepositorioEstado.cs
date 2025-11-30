using Microsoft.EntityFrameworkCore;
using source.Dominio.Entidades.PatronState;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioEstado : IRepositorioEstado
    {
        private readonly AppDbContext _context;

        public RepositorioEstado(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Estado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Estados.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Estado>> ObtenerTodosAsync()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task AgregarAsync(Estado entidad)
        {
            await _context.Estados.AddAsync(entidad);
        }

        public void Actualizar(Estado entidad)
        {
            _context.Estados.Update(entidad);
        }

        public void Eliminar(Estado entidad)
        {
            _context.Estados.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync()
        {
            return await _context.Estados.AnyAsync();
        }

        public async Task<IEnumerable<Estado>> ObtenerEstadosInicialesAsync()
        {
            var iniciales = new[] { "PendienteRevision", "AutoDetectado" };

            return await _context.Estados.Where(e => iniciales.Contains(e.Nombre)).ToListAsync();
        }

        public async Task<Estado?> ObtenerPorNombreAsync(string nombre)
        {
            return await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == nombre);
        }
    }
}
