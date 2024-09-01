using System;

namespace Matriceria.Entidades
{
    public class Pieza
    {
        private int id_pieza;
        private string codigo;
        private string nombre;
        private string descripcion;
        private decimal precio;

        public int Id_pieza
        {
            get { return id_pieza; }
            set { id_pieza = value; }
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

        public Pieza(string codigo, string nombre, string descripcion, decimal precio)
        {
            this.id_pieza = Id_pieza;
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public Pieza() { }
    }
}
