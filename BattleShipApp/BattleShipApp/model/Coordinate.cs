using BattleShipApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model
{
    /// <summary>
    /// Class <c>Coordinate</c>
    /// </summary>
    public class Coordinate
    {
        private int[] components;
        /// <summary>
        /// Coordinate constructor with params <c>x</c> and <c>y</c>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <example>
        ///     <code>
        ///     Coordinate c = new COordinate(1,2);
        ///     </code>
        /// </example>
        public Coordinate(int x, int y)
        {
            components = new int[] { x, y };
        }
        /// <summary>
        /// Coordinate constructor with params and the constructor go throught the array components.
        /// </summary>
        /// <param name="c"></param>
        public Coordinate(Coordinate c)
        {
            components = new int[c.components.Length];
            for (int i = 0; i < c.components.Length; i++)
            {
                components[i] = c.components[i];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <param name="value"></param>
        protected void Set(int component, int value)
        {
            if (component >= 0 && component < components.Length)
            {
                components[component] = value;
            }
            else
            {
                Form1.console.WriteLine($"Component {component} is out of bounds");
            }
        }

        public int Get(int component)
        {
            if (component >= 0 && component < components.Length)
            {
                return components[component];
            }
            else
            {
                Form1.console.WriteLine($"Component {component} is out of bounds");
                return -1;
            }
        }

        public Coordinate Add(Coordinate c)
        {
            Coordinate caux = new Coordinate(this);

            int tamany = (components.Length > c.components.Length) ? c.components.Length : components.Length;

            for (int i = 0; i < tamany; i++)
            {
                caux.Set(i, Get(i) + c.Get(i));
            }

            return caux;
        }

        public Coordinate Substract(Coordinate c)
        {
            Coordinate caux = new Coordinate(this);

            int tamany = (components.Length > c.components.Length) ? c.components.Length : components.Length;

            for (int i = 0; i < tamany; i++)
            {
                caux.Set(i, Get(i) - c.Get(i));
            }

            return caux;
        }

        public override bool Equals(object? obj)
        {
            //return base.Equals(obj);
            if (this == obj) return true;
            if (obj == null) return false;
            Type refClass = this.GetType();
            Type testClass = obj.GetType();
            if(!refClass.Equals(testClass)) return false;
            Coordinate other = (Coordinate)obj;
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != other.components[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            int hc0 = components[0].GetHashCode();
            int hc1 = components[1].GetHashCode();
            result = prime * result + hc0 * hc1;
            return result;
        }

        public override string? ToString()
        {
            String coord = "(";
            for (int i = 0; i < components.Length; i++)
            {
                coord += components[i].ToString();
                if (i < components.Length - 1) coord += ",";
            }
            coord += ")";
            return coord;
        }

        public Coordinate Copy()
        {
            return new Coordinate(this);
        }

        public HashSet<Coordinate> AdjacentCoordinates()
        {
            HashSet<Coordinate> adjacents = new HashSet<Coordinate>();
            for(int x = -1;x<2;x++)
            {
                for(int y = -1; y < 2; y++)
                {
                    if (x == 0 || y == 0) continue;
                    else adjacents.Add(new Coordinate(Get(0) + x, Get(1) + y));
                }
            }
            return adjacents;
        }


    }
}
