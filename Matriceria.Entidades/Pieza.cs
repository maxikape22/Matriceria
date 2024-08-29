using System;

namespace Matriceria.Entidades
{
    public class Pieza
    {
        private Guid id_pieza;
        private Guid id_area;
        private string codigo;
        private string nombre;
        private string descripcion;
        private decimal precio;

        public Guid Id_pieza
        {
            get { return id_pieza; }
            set { id_pieza = value; }
        }

        public Guid Id_area
        {
            get { return id_area; }
            set { id_area = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Pieza()
        {
            id_pieza = Guid.NewGuid();
        }

        public Pieza(Guid id_area, string codigo, string nombre, string descripcion, decimal precio)
        {
            this.id_pieza = Guid.NewGuid();
            this.id_area = id_area;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }
}
