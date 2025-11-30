using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioDetalleMuestraSismica : IRepositorioDetalleMuestraSismica
    {
        private readonly AppDbContext _context;

        public RepositorioDetalleMuestraSismica(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DetalleMuestraSismica?> ObtenerPorIdAsync(int id)
        {
            return await _context.DetallesMuestrasSismicas.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DetalleMuestraSismica>> ObtenerTodosAsync()
        {
            return await _context.DetallesMuestrasSismicas.ToListAsync();
        }

        public async Task AgregarAsync(DetalleMuestraSismica entidad)
        {
            await _context.DetallesMuestrasSismicas.AddAsync(entidad);
        }

        public void Actualizar(DetalleMuestraSismica entidad)
        {
            _context.DetallesMuestrasSismicas.Update(entidad);
        }

        public void Eliminar(DetalleMuestraSismica entidad)
        {
            _context.DetallesMuestrasSismicas.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
