using System;
using System.Collections.Generic;
using System.Text;

namespace Formes
{
    public class Cube : IForme3D
    {
        private const int EXPOSANT_AIRE = 2;
        private const int EXPOSANT_VOLUME = 3;
        private const int NOMBRE_DE_FACES = 6;
        private double cote;

        public Cube(double cote)
        {
            this.cote = cote;
        }
        public double Aire()
        {
            return Math.Pow(cote, EXPOSANT_AIRE) * NOMBRE_DE_FACES;
        }

        public double Volume()
        {
            return Math.Pow(cote, EXPOSANT_VOLUME);
        }
    }
}
