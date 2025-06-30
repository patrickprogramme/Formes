using System;
using System.Collections.Generic;
using System.Text;

namespace Formes
{
    public class Cercle : IForme2D
    {
        private const int EXPOSANT_AIRE = 2;
        private double rayon;

        public Cercle(double rayon)
        {
            this.rayon = rayon;
        }

        public double Perimetre()
        {
            return 2 * Math.PI * rayon;
        }

        public double Aire()
        {
            return Math.PI * Math.Pow(rayon, EXPOSANT_AIRE);
        }
    }
}
