using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLbenitez
{
    class Movimiento
    {
        private int distanciaX;

        public int DistaciaX
        {
            get { return distanciaX; }
            set { distanciaX = value; }
        }

        private int distanciaY;

        public int DistanciaY
        {
            get { return distanciaY; }
            set { distanciaY = value; }
        }

        private EnumMovimientoX direccionX;

        public EnumMovimientoX DireccionX
        {
            get { return direccionX; }
            set { direccionX = value; }
        }

        private EnumMovimientoY direccionY;

        public EnumMovimientoY DireccionY
        {
            get { return direccionY; }
            set { direccionY = value; }
        }

        public static Movimiento Calcular(Celda celdaOrigen, Celda celdaDestino)
        {
            Movimiento m = new Movimiento();
            //Calcula la cantida de celdas y el sentido, por defecto toma que no hay movimiento en X
            if (celdaOrigen.Columna > celdaDestino.Columna)
            {
                m.DistaciaX = celdaOrigen.Columna - celdaDestino.Columna;
                m.direccionX = EnumMovimientoX.Izquierda;
            }
            else if(celdaOrigen.Columna < celdaDestino.Columna)
            {
                m.distanciaX = celdaDestino.Columna - celdaOrigen.Columna;
                m.direccionX = EnumMovimientoX.Derecha;
            }

            if(celdaOrigen.Fila > celdaDestino.Fila)
            {
                m.DistanciaY = celdaOrigen.Fila - celdaDestino.Fila;
                m.direccionY = EnumMovimientoY.Arriba;
            }
            else if (celdaDestino.Fila > celdaOrigen.Fila)
            {
                m.DistanciaY = celdaDestino.Fila - celdaOrigen.Fila;
                m.direccionY = EnumMovimientoY.Abajo;
            }

            return m;
        }



    }
}
