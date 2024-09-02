using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;
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

        public List<Entrega> ObtenerEntregas()
        {
            return objDatosEntrega.ObtenerEntregas();
        }

        public DataSet FiltrarEntregasPorCodigo(string codigoEntrega)
        {
            return objDatosEntrega.FiltrarEntregasPorCodigo(codigoEntrega);
        }
    }
}
