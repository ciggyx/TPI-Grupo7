using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioEstacionSismologica
    {
        Task<EstacionSismologica?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<EstacionSismologica>> ObtenerTodosAsync();
        Task AgregarAsync(EstacionSismologica entidad);
        void Actualizar(EstacionSismologica entidad);
        void Eliminar(EstacionSismologica entidad);
        Task<int> GuardarCambiosAsync();
    }
}
