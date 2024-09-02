using Matriceria.BD;
using Matriceria.Entidades;

namespace Matriceria.Negocios
{
    public class ClienteNegocio
    {
        ListaCliente objDatosCliente = new ListaCliente();

        public int InsertarCliente(Cliente objCliente)
        {
            return objDatosCliente.InsertarCliente(objCliente);
        }
    }
}