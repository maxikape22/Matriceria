using System;

namespace Matriceria.Entidades
{
    public class Area
    {
        private Guid id_area;
        private string nombrea_area;
        private int tiempo;

        public Guid Id_area
        {
            get { return id_area; }
            set { id_area = value; }
        }
        public string Nombrea_area 
        {
            get { return nombrea_area; }
            set { nombrea_area = value; }
        }
        public int Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
      
        public Area()
        {
            id_area = Guid.NewGuid(); 
        }

        public Area(string nombre_area, int tiempo)
        {
            this.id_area = Guid.NewGuid();  
            this.nombrea_area = nombre_area;
            this.tiempo = tiempo;
        }
    }
}