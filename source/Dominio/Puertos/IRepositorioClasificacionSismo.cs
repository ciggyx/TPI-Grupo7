using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioClasificacionSismo
    {
        Task<ClasificacionSismo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<ClasificacionSismo>> ObtenerTodosAsync();
        Task AgregarAsync(ClasificacionSismo entidad);
        void Actualizar(ClasificacionSismo entidad);
        void Eliminar(ClasificacionSismo entidad);
        Task<int> GuardarCambiosAsync();
    }
}
