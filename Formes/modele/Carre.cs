using System;
using System.Collections.Generic;
using System.Text;

namespace Formes
{
    public class Carre : IForme2D
    {
        private const int NB_COTES = 4;
        private double cote;

        public Carre(double cote)
        {
            this.cote = cote;
        }

        public double Perimetre()
        {
            return cote * NB_COTES;
        }

        public double Aire()
        {
            return cote * cote;
        }
    }
}
