using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioMuestraSismica : IRepositorioMuestraSismica
    {
        private readonly AppDbContext _context;

        public RepositorioMuestraSismica(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MuestraSismica?> ObtenerPorIdAsync(int id)
        {
            return await _context.MuestrasSismicas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MuestraSismica>> ObtenerTodosAsync()
        {
            return await _context.MuestrasSismicas.ToListAsync();
        }

        public async Task AgregarAsync(MuestraSismica entidad)
        {
            await _context.MuestrasSismicas.AddAsync(entidad);
        }

        public void Actualizar(MuestraSismica entidad)
        {
            _context.MuestrasSismicas.Update(entidad);
        }

        public void Eliminar(MuestraSismica entidad)
        {
            _context.MuestrasSismicas.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
