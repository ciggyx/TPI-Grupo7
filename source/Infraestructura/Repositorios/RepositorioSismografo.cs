using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioSismografo : IRepositorioSismografo
    {
        private readonly AppDbContext _context;

        public RepositorioSismografo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Sismografo?> ObtenerPorIdAsync(int id)
        {
            return await _context.Sismografos.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sismografo>> ObtenerTodosAsync()
        {
            return await _context.Sismografos.ToListAsync();
        }

        public async Task AgregarAsync(Sismografo entidad)
        {
            await _context.Sismografos.AddAsync(entidad);
        }

        public void Actualizar(Sismografo entidad)
        {
            _context.Sismografos.Update(entidad);
        }

        public void Eliminar(Sismografo entidad)
        {
            _context.Sismografos.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync()
        {
            return await _context.Sismografos.AnyAsync();
        }

        public async Task<IEnumerable<Sismografo>> ObtenerTodosAsyncConEstacion()
        {
            return await _context.Sismografos.Include(s => s.EstacionSismologica).ToListAsync();
        }
    }
}
