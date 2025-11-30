using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioMuestraSismica
    {
        Task<MuestraSismica?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<MuestraSismica>> ObtenerTodosAsync();
        Task AgregarAsync(MuestraSismica entidad);
        void Actualizar(MuestraSismica entidad);
        void Eliminar(MuestraSismica entidad);
        Task<int> GuardarCambiosAsync();
    }
}
