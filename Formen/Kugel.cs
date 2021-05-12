using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Formen
{

    public class Kugel
    {
        private static double NthRoot(double A, int N)
        {
            return Math.Pow(A, 1.0d / N);
        }

        double _radius;
        double _durchmesser;
        double _umfang;
        double _volumen;
        double _oberfläche;

        public static Kugel vonRadius(double radius) => new Kugel() { _radius = radius };
        public static Kugel vonDurchmesser(double durchmesser) => new Kugel() { _radius = durchmesser / 2d };
        public static Kugel vonUmfang(double umfang) => new Kugel() { _radius = umfang / ( 2d * Math.PI) };
        public static Kugel vonVolumen(double volumen) => new Kugel() { _radius = NthRoot((3 * volumen) / (4d * Math.PI), 3) };
        public static Kugel vonOberfläche(double oberfläche) => new Kugel() { _radius = Math.Sqrt(oberfläche / (4d * Math.PI)) };

        public double Radius => _radius;
        public double Durchmesser => _radius * 2d;
        public double Umfang => 2d * _radius * Math.PI;
        public double Volumen => (4d / 3d) * Math.PI * Math.Pow(_radius, 3);
        public double Oberfläche => 4d * Math.PI * Math.Pow(_radius, 2);
    }
}
