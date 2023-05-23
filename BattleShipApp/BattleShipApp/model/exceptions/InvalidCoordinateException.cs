using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model.exceptions
{
    public class InvalidCoordinateException : BattleShipException
    {
        public InvalidCoordinateException(Coordinate c) : base(c)
        {
        }
        
        public new string GetMessage()
        {
            return $"InvalidCoordinateException: coordinate {coord} is out of bounds";
        }
    }
}
