using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjedrezLbenitez
{
    public class Tablero
    {
        public Tablero()
        {
            matrizCasilleros = new List<Celda>();

            EnumJugadorColor color;

            //Armo los casilleros del tablero
            for (int y = 1; y <= 8; y++)
            {
                if (y % 2 == 1)
                    color = EnumJugadorColor.Blanco;
                else
                    color = EnumJugadorColor.Negro;

                for (int x = 1; x <= 8; x++)
                {
                    Celda celda = new Celda();
                    celda.Color = color;
                    celda.Fila = y;
                    celda.Columna = x;
                    matrizCasilleros.Add(celda);

                    if (color == EnumJugadorColor.Blanco)
                        color = EnumJugadorColor.Negro;
                    else
                        color = EnumJugadorColor.Blanco;

                }
            }
        }

        private List<Celda> matrizCasilleros;

        public List<Celda> MatrizCasilleros
        {
            get { return matrizCasilleros; }
            set { matrizCasilleros = value; }
        }

        public int JugadorOnTop
        {
            get => default;
            set
            {
            }
        }

        public void GetCelda()
        {
            throw new System.NotImplementedException();
        }
    }
}