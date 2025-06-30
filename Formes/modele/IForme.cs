using System;
using System.Collections.Generic;
using System.Text;

namespace Formes
{
    public interface IForme
    {
        double Aire();
    }
    public interface IForme2D : IForme
    {
        double Perimetre();
    }
    public interface IForme3D : IForme
    {
        double Volume();
    }
}
