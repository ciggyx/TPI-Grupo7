using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioEmpleado
    {
        Task<Empleado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Empleado>> ObtenerTodosAsync();
        Task AgregarAsync(Empleado entidad);
        void Actualizar(Empleado entidad);
        void Eliminar(Empleado entidad);
        Task<int> GuardarCambiosAsync();
    }
}
