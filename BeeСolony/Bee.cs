using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeСolony
{
    internal class Bee
    {
        private double x;
        private double y;
        private double z;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
        }
        private double CalcZ(Entity function, double x, double y)
        {
            Entity newFunction = function.Substitute("x", x);
            newFunction = newFunction.Substitute("y", y);
            return (double)(newFunction.EvalNumerical());
        }
        public Bee(Entity _function, double _x, double _y)
        {
            x = _x;
            y = _y;
            z = CalcZ(_function, x, y);
        }
        public Bee(Entity _function, Bee _bee, int rangeX, int rangeY, int min, int max, Random rnd)
        {
            double rndValue;
            rndValue = rnd.NextDouble() * (2 * rangeX) - rangeX;
            x = _bee.X + rndValue;
            rndValue = rnd.NextDouble() * (2 * rangeY) - rangeY;
            y = _bee.Y + rndValue;
            if (x < min) x = min;
            if (x > max) x = max;
            if (y < min) y = min;
            if (y > max) y = max;
            z = CalcZ(_function, x, y);
        }
    }
}
