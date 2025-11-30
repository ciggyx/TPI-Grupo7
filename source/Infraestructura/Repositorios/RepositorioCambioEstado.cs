using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioCambioEstado : IRepositorioCambioEstado
    {
        private readonly AppDbContext _context;

        public RepositorioCambioEstado(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CambioEstado?> ObtenerPorIdAsync(int id)
        {
            return await _context.CambiosEstado.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CambioEstado>> ObtenerTodosAsync()
        {
            return await _context.CambiosEstado.ToListAsync();
        }

        public async Task AgregarAsync(CambioEstado entidad)
        {
            await _context.CambiosEstado.AddAsync(entidad);
        }

        public void Actualizar(CambioEstado entidad)
        {
            _context.CambiosEstado.Update(entidad);
        }

        public void Eliminar(CambioEstado entidad)
        {
            _context.CambiosEstado.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
