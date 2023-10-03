using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire : Monster
    {
        //Fields

        //Properties
        public bool IsNight { get; set; }
        //Constructors
        public Vampire()
        {
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsNight = true;
            }
            else
            {
                IsNight = false;
            }
            if (IsNight)
            {
                MaxDamage = 15 + CalcBlock();
            }
            else
            {
                MaxDamage = 15;
            }
            MinDamage = 5;
            MaxLife = 20;
            Name = "Vampire Fledgling";
            Life = MaxLife;
            HitChance = 75;
            Block = 10;
            Description = "A poor soul bitten by another vapire cursed to live a life of solidarity";
        }
        public Vampire(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isNight) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            IsNight = isNight;
            MaxDamage = CalcBlock();
        }
        public override int CalcBlock()
        {
            int maxDamage = MaxDamage;
            if (IsNight)
            {
                maxDamage += 7;
            }
            return maxDamage;
        }
        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }
    }
}