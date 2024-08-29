using Matriceria.BD;
using Matriceria.Entidades;

namespace Matriceria.Negocios
{
    public class PiezaNegocio
    {
        ListaPieza objDatosPieza = new ListaPieza();
        public int abmPieza(string accion, Pieza objPieza)
        {
            return objDatosPieza.abmPieza(accion, objPieza);
        }
    }
}