using System;

namespace Matriceria.Entidades
{
    public class Orden
    {
        private Guid idOrden;
        private Guid idCliente;
        private Guid idArea;
        private string codigo;
        private string prioridad;
        private string descripcion;
        private string estado;
        private DateTime fecha_inicio;
        private DateTime fecha_prometido;

        public Guid IdOrden
        {
            get { return idOrden; }
            set { idOrden = value; }
        }

        public Guid IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public Guid IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime Fecha_inicio
        {
            get { return fecha_inicio; }
            set { fecha_inicio = value; }
        }

        public DateTime Fecha_prometido
        {
            get { return fecha_prometido; }
            set { fecha_prometido = value; }
        }

        public Orden()
        {
            idOrden = Guid.NewGuid();
            idCliente = Guid.NewGuid();
            idArea = Guid.NewGuid();
        }

        public Orden(string codigo, string prioridad,string descripcion,string estado,
            DateTime fecha_inicio,DateTime fecha_prometido)
        {
            this.idOrden = Guid.NewGuid();
            this.idCliente = Guid.NewGuid();
            this.idArea = Guid.NewGuid();
            this.codigo = codigo;
            this.prioridad = prioridad;
            this.descripcion = descripcion;
            this.estado = estado;
            this.fecha_inicio = fecha_inicio;
            this.fecha_prometido = fecha_prometido;
        }
    }
}