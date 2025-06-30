using System;
using System.Collections.Generic;
using System.Text;

namespace Formes
{
    public class Sphere : IForme3D
    {
        private const int EXPOSANT_AIRE = 2;
        private const int EXPOSANT_VOLUME = 3;
        private const double COEFFICIENT = 4.0 / 3.0;
        private double rayon;

        public Sphere(double rayon)
        {
            this.rayon = rayon;
        }

        public double Aire()
        {
            return 4 * Math.PI * Math.Pow(rayon, EXPOSANT_AIRE);
        }

        public double Volume()
        {
            return COEFFICIENT * Math.PI * Math.Pow(rayon, EXPOSANT_VOLUME);
        }
    }
}
