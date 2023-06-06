using BattleShipApp.model;
using BattleShip.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model.io
{
    public class VisualiserFactory
    {
        public static IVisualiser CreateVisualiser(string s, Game g)
        {
            string qualifier = "BattelShipApp.io.visualizer";
            try
            {
                Type v = Type.GetType(qualifier + s);
                Type[] types = new Type[1];
                types[0] = typeof(Game);

                ConstructorInfo constructor = v.GetConstructor(types);

                return (IVisualiser)v.InvokeMember(
                    "",
                    BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance,
                    null,
                    null,
                    new object[] { g }

                    );
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
