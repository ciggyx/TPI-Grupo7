using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioMagnitudRichter
    {
        Task<MagnitudRichter?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<MagnitudRichter>> ObtenerTodosAsync();
        Task AgregarAsync(MagnitudRichter entidad);
        void Actualizar(MagnitudRichter entidad);
        void Eliminar(MagnitudRichter entidad);
        Task<int> GuardarCambiosAsync();
    }
}
