using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model.exceptions
{
    public abstract class BattleShipException : Exception
    {
        protected Coordinate coord;

        public BattleShipException(Coordinate c)
        {
            coord = c;
        }

        public string GetMessage()
        {
            return $"BattleShipException: An exception occurred in coordinate {coord}";
        }
    }
}
