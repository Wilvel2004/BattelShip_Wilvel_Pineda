using BattleShip.model.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model.io
{
    public class PlayerFactory
    {
        public static IPlayer CreatePlayer(string name, string s)
        {
            if (s.Contains('.') || s.Contains('\\') || s.Contains('/'))
            {
                return new PlayerFile(name, s);
            }
            else if (IsInt(s))
            {
                return new PlayerRandom(name,int.Parse(s));
            }
            else
            {
                return null;
            }
        }
        public static bool IsInt(string s)
        {
            try
            {
                int.Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
