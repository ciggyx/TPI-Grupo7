using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioAlcanceSismo : IRepositorioAlcanceSismo
    {
        private readonly AppDbContext _context;

        public RepositorioAlcanceSismo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AlcanceSismo?> ObtenerPorIdAsync(int id)
        {
            return await _context.AlcancesSismo.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AlcanceSismo>> ObtenerTodosAsync()
        {
            return await _context.AlcancesSismo.ToListAsync();
        }

        public async Task AgregarAsync(AlcanceSismo entidad)
        {
            await _context.AlcancesSismo.AddAsync(entidad);
        }

        public void Actualizar(AlcanceSismo entidad)
        {
            _context.AlcancesSismo.Update(entidad);
        }

        public void Eliminar(AlcanceSismo entidad)
        {
            _context.AlcancesSismo.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
