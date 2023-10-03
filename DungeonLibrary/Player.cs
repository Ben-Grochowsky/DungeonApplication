using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Hero
    {
        //Fields
        //no fields
        //Properties
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }//CONTAINMENT
        public int Score { get; set; }

        //Constructors
        public Player(string name, int hitChance, int block, int maxLife, Race characterRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            #region Potential expansion: Racial bonuses
            switch (CharacterRace)
            {
                case Race.Argonian:
                    Block += 5;
                    HitChance += 4;
                    break;
                case Race.High_Elf:
                    HitChance += 8;
                    break;
                case Race.Breton:
                    MaxLife += 10;
                    Life = MaxLife;
                    break;
                case Race.Nord:
                    HitChance += 5;
                    break;
                case Race.DarkElf:
                    MaxLife += 15;
                    Life = MaxLife;
                    break;
            }
            #endregion
        }
        public Player()
        {

        }

        //Methods
        public override string ToString()
        {
            return $"{base.ToString()}" +
                   $"Race: {CharacterRace}\n" +
                   $"Weapon: {EquippedWeapon}\n";
        }
        public override int CalcDamage()
        {

            //create the return object
            int result;
            //setup necessary resources
            Random rand = new Random();
            //modify the return object
            result = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage);
            //return the return object
            return result;

            //return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }
        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }
    }
}
