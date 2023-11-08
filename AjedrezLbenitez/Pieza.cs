using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezLbenitez
{
    public abstract class Pieza
    {
        private EnumJugadorColor color;

        public EnumJugadorColor Color
        {
            get { return color; }
            set { color = value; }
        }


        /// <summary>
        /// El método validarbase realiza control de: 
        /// 1) celda vacía en origen
        /// 2) pieza del mismo color jugadorturno
        /// 3) que se haya movido hacia algún lado
        /// </summary>
        /// <param name="partida">recibe una partida</param>
        /// <param name="celdaOrigen">recibe la celda origen</param>
        /// <param name="celdaDestino">recibe la celda destino</param>
        public void ValidarBase(Partida partida, Celda celdaOrigen, Celda celdaDestino)
        {
            if (celdaOrigen.Pieza == null)
                throw new Exception("La celda está vacia");

            if (partida.Turno.Jugador1)
            {
                if (partida.Jugador1Color == EnumJugadorColor.Blanco && celdaOrigen.Pieza.Color == EnumJugadorColor.Negro)
                    throw new Exception("No se puede mover la pieza del oponente");
                else if (partida.Jugador1Color == EnumJugadorColor.Negro && celdaOrigen.Pieza.Color == EnumJugadorColor.Blanco)
                    throw new Exception("No se puede mover la pieza del oponente");
            }
            else
            {
                if (partida.Jugador2Color == EnumJugadorColor.Blanco && celdaOrigen.Pieza.Color == EnumJugadorColor.Negro)
                    throw new Exception("No se puede mover la pieza del oponente");
                else if (partida.Jugador2Color == EnumJugadorColor.Negro && celdaOrigen.Pieza.Color == EnumJugadorColor.Blanco)
                    throw new Exception("No se puede mover la pieza del oponente");
            }

            if (celdaDestino.Pieza != null)
            {
                if (partida.Turno.Jugador1)
                {
                    if (partida.Jugador1Color == EnumJugadorColor.Blanco && celdaDestino.Pieza.Color == EnumJugadorColor.Blanco)
                        throw new Exception("Hay una pieza del mismo color");

                   else  if (partida.Jugador1Color == EnumJugadorColor.Negro && celdaDestino.Pieza.Color == EnumJugadorColor.Negro)
                        throw new Exception("Hay una pieza del mismo color");
                }
                else
                {
                    if (partida.Jugador2Color == EnumJugadorColor.Blanco && celdaDestino.Pieza.Color == EnumJugadorColor.Blanco)
                    throw new Exception("Hay una pieza del mismo color");

                   else if (partida.Jugador2Color == EnumJugadorColor.Negro && celdaDestino.Pieza.Color == EnumJugadorColor.Negro)
                    throw new Exception("Hay una pieza del mismo color");
                }

               
            }

            Movimiento m = Movimiento.Calcular(celdaOrigen, celdaDestino);
            //Valida que se haya movido hacia alguna celda
            if (m.DireccionY == EnumMovimientoY.Ninguno && m.DireccionX == EnumMovimientoX.Ninguno)
                throw new Exception("No se movio");

        }

        public abstract void Validar(Partida partida, Celda celdaOrigen, Celda celdaDestino);

        public void Mover(Partida partida, Celda celdaOrigen, Celda celdaDestino)
        {
            celdaDestino.Pieza = celdaOrigen.Pieza;
            celdaOrigen.Pieza = null;
        }
    }
}