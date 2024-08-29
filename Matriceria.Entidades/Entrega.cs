using System;

namespace Matriceria.Entidades
{
    public class Entrega
    {
        private Guid idEntrega;
        private Guid idOrden;
        private string codigoEntrega;
        private DateTime fechaEntrega;
        private string horarioEntrega;
        private string estadoEntrega;
        private string medioDePago;
        private bool entregado;

        public string EntregadoTexto
        {
            get { return Entregado ? "Sí" : "No"; }
        }
        public Guid IdEntrega
        {
            get { return idEntrega; }
            set { idEntrega = value; }
        }

        public Guid IdOrden
        {
            get { return idOrden; }
            set { idOrden = value; }
        }

        public string CodigoEntrega
        {
            get { return codigoEntrega; }
            set { codigoEntrega = value; }
        }

        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        public string HorarioEntrega
        {
            get { return horarioEntrega; }
            set { horarioEntrega = value; }
        }

        public string EstadoEntrega
        {
            get { return estadoEntrega; }
            set { estadoEntrega = value; }
        }

        public string MedioDePago
        {
            get { return medioDePago; }
            set { medioDePago = value; }
        }

        public bool Entregado
        {
            get { return entregado; }
            set { entregado = value; }
        }

        public Entrega()
        {
            idEntrega = Guid.NewGuid(); // Asignar un nuevo GUID por defecto
        }

        public Entrega(Guid idOrden, string codigoEntrega, DateTime fechaEntrega, string horarioEntrega,
                        string estadoEntrega, string medioDePago, bool entregado)
        {
            this.idEntrega = Guid.NewGuid(); // Asignar un nuevo GUID por defecto
            this.idOrden = idOrden;
            this.codigoEntrega = codigoEntrega;
            this.fechaEntrega = fechaEntrega;
            this.horarioEntrega = horarioEntrega;
            this.estadoEntrega = estadoEntrega;
            this.medioDePago = medioDePago;
            this.entregado = entregado;
        }
    }
}
