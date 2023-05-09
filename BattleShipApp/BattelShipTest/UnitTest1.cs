using BattleShipApp.model;

namespace BattelShipTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Coordinate_ConstructorWithTwoValidParams()
        {
            Coordinate c = new Coordinate(2, 1);

            Assert.AreEqual(c.ToString(), "(2,1)");
        }
    }
}