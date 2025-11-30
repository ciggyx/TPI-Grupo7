using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioSerieTemporal
    {
        Task<SerieTemporal?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<SerieTemporal>> ObtenerTodosAsync();
        Task AgregarAsync(SerieTemporal entidad);
        void Actualizar(SerieTemporal entidad);
        void Eliminar(SerieTemporal entidad);
        Task<int> GuardarCambiosAsync();
    }
}
