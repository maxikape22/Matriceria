using Matriceria.BD;
using Matriceria.Entidades;

namespace Matriceria.Negocios
{
    public class PiezaNegocio
    {
        ListaPieza objDatosPieza = new ListaPieza();

        public int InsertarPieza(string accion, Pieza ObjPieza)
        {
            return objDatosPieza.InsertarPieza(accion,ObjPieza);
        }
    }
}