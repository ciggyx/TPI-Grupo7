using Microsoft.EntityFrameworkCore;
using source.Domain.Entities;
using source.Infrastructure;

namespace source.Repositorios
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly AppDbContext _context;

        public RepositorioEmpleado(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Empleado>> ObtenerTodosAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task AgregarAsync(Empleado entidad)
        {
            await _context.Empleados.AddAsync(entidad);
        }

        public void Actualizar(Empleado entidad)
        {
            _context.Empleados.Update(entidad);
        }

        public void Eliminar(Empleado entidad)
        {
            _context.Empleados.Remove(entidad);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
