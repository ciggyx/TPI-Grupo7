using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioOrigenDeGeneracion
    {
        Task<OrigenDeGeneracion?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<OrigenDeGeneracion>> ObtenerTodosAsync();
        Task AgregarAsync(OrigenDeGeneracion entidad);
        void Actualizar(OrigenDeGeneracion entidad);
        void Eliminar(OrigenDeGeneracion entidad);
        Task<int> GuardarCambiosAsync();
    }
}
