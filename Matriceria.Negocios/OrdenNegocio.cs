using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Matriceria.Negocios
{
    public class OrdenNegocio
    {
        ListaOrden objDatosOrden = new ListaOrden();

        public int InsertarOrden(string accion, Orden objOrden)
        {
            return objDatosOrden.InsertarOrden(accion, objOrden);
        }
        public int EliminarOrden(string idOrden)
        {
            return objDatosOrden.EliminarOrden(idOrden);
        }

        public int ModificarOrden(Orden objOrden)
        {
            return objDatosOrden.ModificarOrden(objOrden);
        }

        public DataTable FiltrarOrdenes(int idOrden)
        {
            return objDatosOrden.FiltrarOrdenes(idOrden);
        }

        public DataSet FiltrarOrdenesPorCodigo(string codigo)
        {
            return objDatosOrden.FiltrarOrdenesPorCodigo(codigo);
        }

        public List<Orden> ObtenerOrdenes()
        {
            return objDatosOrden.ObtenerOrdenes();
        }

        public byte[] GenerarPDFDeListaDeOrdenes(List<Orden> ordenes)
        {
            return objDatosOrden.GenerarPDFDeListaDeOrdenes(ordenes);
        }
    }
}
