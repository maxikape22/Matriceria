using Matriceria.BD;
using Matriceria.Entidades;
using System.Data;

namespace Matriceria.Negocios
{
    public class EntregaNegocio
    {
        ListaEntrega objDatosEntrega = new ListaEntrega();

        public int InsertarEntrega(string accion, Entrega objDatos_Entrega)
        {
            return objDatosEntrega.InsertarEntrega(accion,objDatos_Entrega);
        }

        public int EliminarEntrega(string codigoEntrega)
        {
            return objDatosEntrega.EliminarEntrega(codigoEntrega);
        }

        public DataSet Union()
        {
            return objDatosEntrega.Union();
        }

    }
}
