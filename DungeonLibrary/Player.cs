using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Player : Hero
    {
        //Fields
        //no fields
        //Properties
        public Race CharacterRace { get; set; }
        public WeaponType EquippedWeapon { get; set; }//CONTAINMENT

        //Constructors
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, WeaponType equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }
        public Player()
        {

        }

        //Methods
        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                   $"Weapon: {EquippedWeapon}\n" +
                   $"Race: {CharacterRace}\n";
        }
    }
}
