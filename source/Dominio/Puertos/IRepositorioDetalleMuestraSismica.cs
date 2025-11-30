using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioDetalleMuestraSismica
    {
        Task<DetalleMuestraSismica?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<DetalleMuestraSismica>> ObtenerTodosAsync();
        Task AgregarAsync(DetalleMuestraSismica entidad);
        void Actualizar(DetalleMuestraSismica entidad);
        void Eliminar(DetalleMuestraSismica entidad);
        Task<int> GuardarCambiosAsync();
    }
}
