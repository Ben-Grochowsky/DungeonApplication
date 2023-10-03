using DungeonLibrary;
using System.Numerics;
using System.Xml.Linq;

namespace UnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void BlessingOfArkayTest()
        {
            //ARRANGE
            FireMage fireMage = new("Fire Mage", 70, 10, 16, 10, 4, "Don't you see? I am master of the arcane!", true);
            int expected = 16;
            //ACT
            int actual = fireMage.MaxLife;
            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RaceBonus()
        {
            //ARRANGE
            Weapon wep = new Weapon("Elven Greatsword", 5, 12, 15, true, WeaponType.Sword);
            Player player = new Player("name", 75, 40, 50, Race.High_Elf, wep);
            int expected2 = 83;
            //ACT
            int actual2 = player.HitChance;
            //ASSERT
            Assert.Equal(expected2, actual2);
        }
    }
}