using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;

namespace Matriceria.Negocios
{
    public class AreaNegocio
    {
        ListaArea objDatosArea = new ListaArea();

        public int abmArea(string accion, Area objArea)
        {
            return objDatosArea.abmArea(accion, objArea);
        }
        public List<Area> ObtenerListadoArea()
        {
            return objDatosArea.ObtenerListarAreas();
        }
       
    }
}
