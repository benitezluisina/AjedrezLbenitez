using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezLbenitez
{
    public class Torre : Pieza
    {
        public override void Validar(Partida partida, Celda celdaOrigen, Celda celdaDestino)
        {
            ValidarBase(partida, celdaOrigen, celdaDestino);

            //se mueve para arriba, para abajo, hacia la derecha y hacia la izquiera
            //No puede saltar piezas

            //No se puede mover en diagonal
            if (partida.Turno.Jugador1 && partida.Jugador1PrimerJugada)
                throw new Exception("la primer jugada no puede ser la torre");

            Movimiento m = Movimiento.Calcular(celdaOrigen, celdaDestino);

            if (m.DistaciaX != 0 && m.DistanciaY != 0)
                throw new Exception("No me puedo mover en diagonal");
            
            if(m.DireccionX != EnumMovimientoX.Ninguno)
            {
                //Aca me movi a la izquiera o a la derecha


                if (m.DireccionX == EnumMovimientoX.Izquierda)
                {
                    if (partida.Tablero.MatrizCasilleros.Exists(p => p.Columna > celdaDestino.Columna && p.Columna < celdaOrigen.Columna && p.Fila == celdaOrigen.Fila && p.Pieza != null))
                        throw new Exception("no se puede saltar porque si!");
                }
                else
                {
                    if (partida.Tablero.MatrizCasilleros.Exists(p => p.Columna > celdaOrigen.Columna && p.Columna < celdaDestino.Columna && p.Fila == celdaOrigen.Fila && p.Pieza != null))
                        throw new Exception("no se puede saltar porque si!");

                }
            }
            else
            {
                //Aca me movi arriba o abajo
            }
        }

    }
}