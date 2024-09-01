using System;

namespace Matriceria.Entidades
{
    public class Entrega
    {
        private int idEntrega;
        private string codigoEntrega;
        private DateTime fechaEntrega;
        private string horarioEntrega;
        private string estadoEntrega;
        private string medioDePago;
        private string entregado;
        public int IdEntrega
        {
            get { return idEntrega; }
            set { idEntrega = value; }
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

        public string Entregado
        {
            get { return entregado; }
            set { entregado = value; }
        }

        public Entrega(string codigoEntrega, DateTime fechaEntrega, string horarioEntrega,
                        string estadoEntrega, string medioDePago, string entregado)
        {
            this.idEntrega = IdEntrega; 
            this.codigoEntrega = codigoEntrega;
            this.fechaEntrega = fechaEntrega;
            this.horarioEntrega = horarioEntrega;
            this.estadoEntrega = estadoEntrega;
            this.medioDePago = medioDePago;
            this.entregado = entregado;
        }

        public Entrega() { }
    }
}
