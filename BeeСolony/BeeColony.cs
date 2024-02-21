using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeСolony
{    
    internal class BeeColony
    {
        private static Entity function;
        private static List<Bee> bees;
        private static int beeCount;
        private static int dotCount;
        private static int eliteDotCount;
        private static int eliteDotBeeCount;
        private static int restDotBeeCount;
        private static int rangeX;
        private static int rangeY;
        private static int min;
        private static int max;
        public BeeColony(Entity _function, int _beeCount, int _dotCount, int _eliteDotCount, int _eliteDotBeeCount, int _restDotBeeCount, int _rangeX, int _rangeY, int _min, int _max)
        {
            Random rnd = new Random();            
            function = _function;
            bees = new List<Bee>();
            beeCount = _beeCount;
            dotCount = _dotCount;
            eliteDotCount = _eliteDotCount;
            eliteDotBeeCount = _eliteDotBeeCount;
            restDotBeeCount = _restDotBeeCount;
            rangeX = _rangeX;
            rangeY = _rangeY;
            min = _min;
            max = _max;
            double x, y;
            for (int i = 0; i < beeCount; i++)
            {
                x = rnd.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - Math.Abs(min);
                y = rnd.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - Math.Abs(min);
                bees.Add(new Bee(function, x, y));
            }
        }
        private void SortBees(List<Bee> beesNeedToSort)
        {
            List<Bee> sortBees = new List<Bee>();
            double minZ = double.MaxValue;
            while (beesNeedToSort.Count > 0)
            {
                foreach (var bee in beesNeedToSort)
                {
                    if (minZ > bee.Z) minZ = bee.Z;
                }
                foreach (var bee in beesNeedToSort)
                {
                    if (bee.Z == minZ)
                    {
                        sortBees.Add(bee);
                        beesNeedToSort.Remove(bee);
                        minZ = double.MaxValue;
                        break;
                    }
                }
            }
            sortBees.RemoveRange(dotCount, sortBees.Count - dotCount);
            for (int i = 0; i < sortBees.Count; i++)
            {
                beesNeedToSort.Add(sortBees[i]);
            }
        }
        private void Search()
        {
            Random rnd = new Random();
            List<Bee> newBees = new List<Bee>();
            int i = 0;
            SortBees(bees);
            foreach (var bee in bees)
            {
                i++;
                newBees.Add(bee);
                if (i < eliteDotCount + 1)
                {
                    for (int j = 0; j < eliteDotBeeCount; j++)
                    {
                        newBees.Add(new Bee(function, bee, rangeX, rangeY, min, max, rnd));
                    }
                }
                else
                {
                    for (int j = 0; j < restDotBeeCount; j++)
                    {
                        newBees.Add(new Bee(function, bee, rangeX, rangeY, min, max, rnd));
                    }
                }
            }
            SortBees(newBees);
            bees.Clear();
            for (int j = 0; j < newBees.Count; j++)
            {
                bees.Add(newBees[j]);
            }
            double x, y;
            for (int j = bees.Count; j < beeCount; j++)
            {
                x = rnd.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - Math.Abs(min);
                y = rnd.NextDouble() * (Math.Abs(max) + Math.Abs(min)) - Math.Abs(min);
                bees.Add(new Bee(function, x, y));
            }
        }
        public (double, double, double) StartBeeColony(int iterationCount)
        {
            double x, y, z;
            for (int i = 0; i < iterationCount; i++)
            {
                Search();
            }
            x = bees[0].X;
            y = bees[0].Y;
            z = bees[0].Z;
            return (x, y, z);
        }
    }
}
