using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using source.Domain.Entities;
using source.Repositorios;

namespace source.Dominio.Entidades.PatronState
{
    public enum Ambito //Clase simple de C# que permite manejar estados segun numero.
    {
        EventoSismico, // 0
        Sismografo, // 1
    }

    public enum Nombre
    {
        PendienteRevision, // 0
        AutoDetectado, // 1
        BloqueadoRevision, //2
        Rechazado, //3
        Confirmado, //4
    }

    [Table("estados")]
    public abstract class Estado
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Ambito { get; set; }

        protected Estado() { }

        public Estado(string ambito, string nombre)
        {
            Ambito = ambito;
            Nombre = nombre;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public virtual bool EsFinal => false;
        public virtual Task<Estado> Cancelar(
            DateTime fechaHoraActual,
            Empleado actor,
            IList<CambioEstado> cambios,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            throw new InvalidOperationException($"El estado {Nombre} no permite cancelar.");
        }

        public virtual Task<Estado> Bloquear(
            DateTime fechaHoraActual,
            Empleado actor,
            IList<CambioEstado> cambios,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            throw new InvalidOperationException($"El estado {Nombre} no permite bloquear.");
        }

        public virtual Task<Estado> Rechazar(
            DateTime fechaHoraActual,
            Empleado actor,
            IList<CambioEstado> cambios,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            throw new InvalidOperationException($"El estado {Nombre} no permite rechazar.");
        }

        public virtual Task<Estado> Confirmar(
            DateTime fechaHoraActual,
            Empleado actor,
            IList<CambioEstado> cambios,
            EventoSismico evento,
            IRepositorioEstado repoEstado
        )
        {
            throw new InvalidOperationException($"El estado {Nombre} no permite confirmar.");
        }

        public bool sosPendienteRevision()
        {
            return Nombre == "PendienteRevision";
        }

        public bool sosAutoDetectado()
        {
            return Nombre == "AutoDetectado";
        }
    }
}
