using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Repositorios;

namespace source.Infrastructure.Repositories
{
    public class RepositorioMagnitudRichter : IRepositorioMagnitudRichter
    {
        private readonly AppDbContext _context;

        public RepositorioMagnitudRichter(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MagnitudRichter?> ObtenerPorIdAsync(int id)
        {
            return await _context.MagnitudRichter.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MagnitudRichter>> ObtenerTodosAsync()
        {
            return await _context.MagnitudRichter.ToListAsync();
        }

        public async Task AgregarAsync(MagnitudRichter entidad)
        {
            await _context.MagnitudRichter.AddAsync(entidad);
        }

        public void Actualizar(MagnitudRichter entidad)
        {
            _context.MagnitudRichter.Update(entidad);
        }

        public void Eliminar(MagnitudRichter entidad)
        {
            _context.MagnitudRichter.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
