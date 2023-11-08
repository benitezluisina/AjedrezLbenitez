using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezLbenitez
{
    public class Partida
    {

        public EnumEstadoJuego Estado
        {
            get => default;
            set
            {
            }
        }

        private Tablero tablero;

        public Tablero Tablero
        {
            get { return tablero; }
            set { tablero = value; }
        }

        public Jugador Jugador
        {
            get => default;
            set
            {
            }
        }


        public void ejemplo()
        {
            //Tablero.MatrizCasilleros[0, 0] = 
        }

        private EnumJugadorColor jugador1Color;

        public EnumJugadorColor Jugador1Color
        {
            get { return jugador1Color; }
            set { jugador1Color = value; }
        }

        private EnumJugadorColor jugador2Color;

        public EnumJugadorColor Jugador2Color
        {
            get { return jugador2Color; }
            set { jugador2Color = value; }
        }



        public void Crear()
        {
            jugador1PrimerJugada = true;
            jugador2PrimerJugada = true;

            jugador1Color = EnumJugadorColor.Blanco;
            jugador2Color = EnumJugadorColor.Negro;

            Celda celda;

            for (int x = 1; x <= 8; x++)
            {
                Peon peon = new Peon();
                peon.Color = EnumJugadorColor.Negro;
                celda = tablero.MatrizCasilleros.Single(p => p.Fila == 2 && p.Columna == x);
                celda.Pieza = peon;

                peon = new Peon();
                peon.Color = EnumJugadorColor.Blanco;
                celda = tablero.MatrizCasilleros.Single(p => p.Fila == 7 && p.Columna == x);
                celda.Pieza = peon;
            }

            Torre torre = new Torre();
            torre.Color = EnumJugadorColor.Blanco;
            celda = tablero.MatrizCasilleros.Single(p => p.Fila == 8 && p.Columna == 1);
            celda.Pieza = torre;

            torre.Color = EnumJugadorColor.Blanco;
            celda = tablero.MatrizCasilleros.Single(p => p.Fila == 8 && p.Columna == 8);
            celda.Pieza = torre;

            /*torre.Color = EnumJugadorColor.Negro;
            celda = tablero.MatrizCasilleros.Single(p => p.Fila == 1 && p.Columna == 1);
            celda.Pieza = torre;

            torre.Color = EnumJugadorColor.Negro;
            celda = tablero.MatrizCasilleros.Single(p => p.Fila == 1 && p.Columna == 8);
            celda.Pieza = torre;*/


            //torres blancas
            /* tablero.MatrizCasilleros[0, 0].Pieza = new Torre() { Color = EnumJugadorColor.Negro };
             tablero.MatrizCasilleros[0, 7].Pieza = new Torre() { Color = EnumJugadorColor.Negro };

             //torres negras
             tablero.MatrizCasilleros[7, 0].Pieza = new Torre() { Color = EnumJugadorColor.Blanco };
             tablero.MatrizCasilleros[7, 7].Pieza = new Torre() { Color = EnumJugadorColor.Blanco };

             //caballos blancas
             tablero.MatrizCasilleros[0, 1].Pieza = new Caballo() { Color = EnumJugadorColor.Negro };
             tablero.MatrizCasilleros[0, 6].Pieza = new Caballo() { Color = EnumJugadorColor.Negro };

             //caballos negros
             tablero.MatrizCasilleros[7, 1].Pieza = new Caballo() { Color = EnumJugadorColor.Blanco };
             tablero.MatrizCasilleros[7, 6].Pieza = new Caballo() { Color = EnumJugadorColor.Blanco };


             //alfines blancas
             tablero.MatrizCasilleros[0, 2].Pieza = new Alfil() { Color = EnumJugadorColor.Negro };
             tablero.MatrizCasilleros[0, 5].Pieza = new Alfil() { Color = EnumJugadorColor.Negro };

             //alfines negros
             tablero.MatrizCasilleros[7, 2].Pieza = new Alfil() { Color = EnumJugadorColor.Blanco };
             tablero.MatrizCasilleros[7, 5].Pieza = new Alfil() { Color = EnumJugadorColor.Blanco };


             //rey negro
             tablero.MatrizCasilleros[0, 3].Pieza = new Rey() { Color = EnumJugadorColor.Negro };

             //reina negro
             tablero.MatrizCasilleros[0, 4].Pieza = new Reina() { Color = EnumJugadorColor.Negro };


             //rey blanco
             tablero.MatrizCasilleros[7, 3].Pieza = new Rey() { Color = EnumJugadorColor.Blanco };

             //reina blanco
             tablero.MatrizCasilleros[7, 4].Pieza = new Reina() { Color = EnumJugadorColor.Blanco };*/

        }

        public Partida()
        {
            tablero = new Tablero();
        }

        private bool jugador1PrimerJugada;

        public bool Jugador1PrimerJugada
        {
            get { return jugador1PrimerJugada; }
        }

        private bool jugador2PrimerJugada;

        public bool Jugador2PrimerJugada
        {
            get { return jugador2PrimerJugada; }
        }

        /*
        private EnumTurno turno = EnumTurno.Jugador1;

        public EnumTurno  Turno
        {
            get { return turno; }
        }
        */

        private Turno turno = new Turno();

        public Turno Turno
        {
            get { return turno; }
        }

        private int jugador1Movimientos;

        private int jugador2Movimientos;


        public void Mover(Celda celdaOrigen, Celda celdaDestino)
        {
            if (turno.Jugador1) //turno == EnumTurno.Jugador1)
            {

            }

            celdaOrigen.Pieza.Mover(this, celdaOrigen, celdaDestino);


            if (turno.Jugador1) //turno == EnumTurno.Jugador1)
            {
                jugador1Movimientos++;
                jugador1PrimerJugada = false;
            }
            else
            {
                jugador2Movimientos++;
                jugador2PrimerJugada = false;
            }

            turno.Proximo();
        }

        public void Validar(Celda celdaOrigen, Celda celdaDestino)
        {
            /*
            if (celdaOrigen.Pieza == null)
                throw new Exception("Error! no hay pieza");

            int cantidadMovimientos;

            if (turno.Jugador1) // == EnumTurno.Jugador1)
            {
                cantidadMovimientos = jugador1Movimientos;

                if (jugador1Color != celdaOrigen.Pieza.Color)
                    throw new Exception("Este jugador no puede mover la pieza del jugador contrincante");
            }
            else
            {
                cantidadMovimientos = jugador2Movimientos;

                if (jugador2Color != celdaOrigen.Pieza.Color)
                    throw new Exception("Este jugador no puede mover la pieza del jugador contrincante");
            }
            */

            celdaOrigen.Pieza.Validar(this, celdaOrigen, celdaDestino);
        }

    }
}