using System;

namespace Matriceria.Entidades
{
    public class Area
    {
        private int id_area;
        private string nombre_area;
        private int tiempo;

        public int Id_area
        {
            get { return id_area; }
            set { id_area = value; }
        }
        public string Nombre_area 
        {
            get { return nombre_area; }
            set { nombre_area = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
      
        public Area(string nombre_area, int tiempo)
        {
            this.id_area = Id_area;  
            this.nombre_area = nombre_area;
            this.tiempo = tiempo;
        }

        public Area() { }
    }
}