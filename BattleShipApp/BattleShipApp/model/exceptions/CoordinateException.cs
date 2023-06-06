using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BattleShipApp.model.exceptions
{
    public abstract class CoordinateException : BattleshipException
    {
        protected Coordinate coord;
        public CoordinateException(Coordinate c)
        {
            coord = c;    
        }

        public string GetMessage()
        {
            return $"CoordinateException: An exception occurred in coordinate {coord}";
        }


    }
}
