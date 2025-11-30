using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioCambioEstado
    {
        Task<CambioEstado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<CambioEstado>> ObtenerTodosAsync();
        Task AgregarAsync(CambioEstado entidad);
        void Actualizar(CambioEstado entidad);
        void Eliminar(CambioEstado entidad);
        Task<int> GuardarCambiosAsync();
    }
}
