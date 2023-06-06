using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BattleShipApp.model.aircraft;
using BattleShipApp.model.ship;

namespace BattleShipApp.model
{
    public class CraftFactory
    {
        public static Craft CreateCraft(string type, Orientation orientation)
        {
            string qualifier;

            if ("Bomber".Equals(type) || "Fighter".Equals(type) || "Transport".Equals(type))
            {
                qualifier = "BattleShipApp.model.aircraft";
            }
            else if ("Destroyer".Equals(type) || "Cruiser".Equals(type) || "Carrier".Equals(type) || "Battelship".Equals(type))
            {
                qualifier = "BattleShipApp.model.ship";
            }
            else
            {
                qualifier = "";
            }

            try
            {
                Type craft = Type.GetType(qualifier + type);
                Type[] types = new Type[1];
                types[0] = typeof(Orientation);

                ConstructorInfo constructor = craft.GetConstructor(types);

                return (Craft)craft.InvokeMember(
                    "",
                    BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.NonPublic,
                    null,
                    null,
                    new object[] { orientation }

                    );
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            };
        }
    }
}

