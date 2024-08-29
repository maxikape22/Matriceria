using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Matriceria.Negocios
{
    public class EntregaNegocio
    {
        ListaEntrega objDatosEntrega = new ListaEntrega();

        public int abmEntrega(string accion, Entrega objEntrega)
        {
            return objDatosEntrega.abmEntrega(accion, objEntrega);
        }
      
        public List<Entrega> ObtenerEntrega()
        {
            return objDatosEntrega.ObtenerEntregas();
        }

        public DataSet FiltroEntrega(string cual)
        {
            return objDatosEntrega.ListarEntregasBuscar(cual);
        }

        public DataSet ListarEntregaEliminar(string codigo)
        {
            return objDatosEntrega.ListarEntregasEliminar(codigo);
        }

        public DataSet Union()
        {
            return objDatosEntrega.Union();
        }
    }
}
