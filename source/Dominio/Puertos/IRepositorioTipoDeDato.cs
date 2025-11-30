using System.Collections.Generic;
using System.Threading.Tasks;
using source.Domain.Entities;

namespace source.Repositorios
{
    public interface IRepositorioTipoDeDato
    {
        Task<TipoDeDato?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<TipoDeDato>> ObtenerTodosAsync();
        Task AgregarAsync(TipoDeDato entidad);
        void Actualizar(TipoDeDato entidad);
        void Eliminar(TipoDeDato entidad);
        Task<int> GuardarCambiosAsync();
    }
}
