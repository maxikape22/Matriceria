using Matriceria.BD;
using Matriceria.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Matriceria.Negocios
{
    public class OrdenNegocio
    {
        ListaOrden objDatosOrden = new ListaOrden();

        public int abmOrden(string accion, Orden objOrden)
        {
            return objDatosOrden.abmOrden(accion, objOrden);
        }
        public DataTable ListadoOrden()
        {
            return objDatosOrden.ListarOrdenes();
        }

        public List<Orden> ObtenerOrden()
        {
            return objDatosOrden.ObtenerOrdenes();
        }

        public DataTable FiltroOrden(string cual)
        {
            return objDatosOrden.FiltrarOrdenesPorCodigo(cual);
        }

        public DataSet ListarProductoEliminar(string codigo)
        {
            return objDatosOrden.OrdenEliminar(codigo);
        }

    }
}
