using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezLbenitez
{
    public class Peon : Pieza
    {
        public override void Validar(Partida partida, Celda celdaOrigen, Celda celdaDestino)
        {
            ValidarBase(partida, celdaOrigen, celdaDestino);

            bool primerJugada = false;
            EnumMovimientoY movimientoY;

            if (partida.Turno.Jugador1)
            {
                primerJugada = partida.Jugador1PrimerJugada;
            }
            else
            {
                primerJugada = partida.Jugador2PrimerJugada;
            }

            if (partida.Turno.Jugador1)
            {
                if (partida.Jugador1Color == EnumJugadorColor.Blanco)
                    movimientoY = EnumMovimientoY.Arriba;
                else
                    movimientoY = EnumMovimientoY.Abajo;
            }
            else
            {
                if (partida.Jugador2Color == EnumJugadorColor.Blanco)
                    movimientoY = EnumMovimientoY.Arriba;
                else
                    movimientoY = EnumMovimientoY.Abajo;
            }

            Movimiento m = Movimiento.Calcular(celdaOrigen, celdaDestino);

            if (m.DireccionX != EnumMovimientoX.Ninguno && m.DireccionY == EnumMovimientoY.Ninguno)
                throw new Exception("no se puede mover hacia los lados");

            

            if (m.DireccionY != movimientoY)
                throw new Exception("no podemos ir hacia atras!");


            if (primerJugada)
            {
                if (m.DistanciaY > 2)
                    throw new Exception("me movi mas de 2");
            }
            else
            {
                if (m.DistanciaY > 1)
                    throw new Exception("me movi mas de 1");

                if (celdaDestino.Pieza == null && m.DistaciaX > 0)
                    throw new Exception("No hay piezas para comer");

                if (celdaDestino.Pieza != null && m.DistaciaX == 0)
                    throw new Exception("No se puede comer de frente");

                if (celdaDestino.Pieza != null && (m.DistaciaX > 1 || m.DistanciaY > 1))
                    throw new Exception("No se puede mover más de un casillero en diagonal");

            }
        }

        public void NOUSAR(Tablero tablero, Celda celdaOrigen, Celda celdaDestino, int cantidadMovimientos)
        {
            //tablero.MatrizCasilleros.
            
            if (cantidadMovimientos == 0)
            {
                //puede mover hasta 2
                //Primero valido si es blanco o negro, si es blando origen es mayor destino, si es negro el destino
                //va ser menor
                //if() hago la resta de celdadestino (y) menos celdaorigen (y) y si es mayor a dos error
            }
            else
            {

            }
        }

    }
}