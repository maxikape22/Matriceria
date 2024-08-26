using Matriceria.BD;
using Matriceria.Entidades;

namespace Matriceria.Negocios
{
    public class ClienteNegocio
    {
        ListaCliente objDatosCliente = new ListaCliente();
        public int abmCliente(string accion, Cliente objCliente)
        {
            return objDatosCliente.abmCliente(accion, objCliente);
        }
    }
}