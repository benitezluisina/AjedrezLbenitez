using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLbenitez
{
    public enum EnumJugadorColor
    {
        Blanco, Negro
    }

    public enum EnumEstadoJuego
    {
        PendienteMovimientoBlanco,
        PendienteMovimientoNegro,
        BlancoMovimento,
        NegroMovimiento,
        BlancoGanador,
        NegroGanador
    }

    public enum EnumMovimientoX
    {
        Ninguno,
        Izquierda,
        Derecha
    }

    public enum EnumMovimientoY
    {
        Ninguno,
        Arriba,
        Abajo
    }

    public enum EnumTurno
    {
        Jugador1,
        Jugador2
    }

}
