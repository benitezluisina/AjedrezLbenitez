using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezLbenitez
{
    public class Turno
    {
        private bool jugador1 = true;

        public bool Jugador1
        {
            get { return jugador1; }
        }


        public void Proximo()
        {
            jugador1 = !jugador1;
        }
    }
}
