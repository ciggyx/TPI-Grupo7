using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioTipoDeDato : IRepositorioTipoDeDato
    {
        private readonly AppDbContext _context;

        public RepositorioTipoDeDato(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoDeDato?> ObtenerPorIdAsync(int id)
        {
            return await _context.TiposDeDato.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TipoDeDato>> ObtenerTodosAsync()
        {
            return await _context.TiposDeDato.ToListAsync();
        }

        public async Task AgregarAsync(TipoDeDato entidad)
        {
            await _context.TiposDeDato.AddAsync(entidad);
        }

        public void Actualizar(TipoDeDato entidad)
        {
            _context.TiposDeDato.Update(entidad);
        }

        public void Eliminar(TipoDeDato entidad)
        {
            _context.TiposDeDato.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
