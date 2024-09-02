using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;

namespace Matriceria.Negocios
{
    public class AreaNegocio
    {
        ListaArea objDatosArea = new ListaArea();

        public int InsertarArea(Area objArea)
        {
            return objDatosArea.InsertarArea(objArea);
        }
    }
}
