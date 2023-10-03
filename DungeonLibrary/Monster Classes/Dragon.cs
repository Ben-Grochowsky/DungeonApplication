using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {
        //Fields

        //Properties
        public bool IsScaly { get; set; }
        //Constructors
        public Dragon()
        {
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 1)
            {
                IsScaly = true;
            }
            else
            {
                IsScaly = false;
            }
            MaxLife = 30;
            MaxDamage = 17;
            MinDamage = 5;
            Name = "Dragon";
            Life = CalcBlock();
            HitChance = 75;
            Block = 20;
            Description = "You see something dive out of the sky, and then the very source of your own Thu'um begins to rain fire down upon you.";
        }
        public Dragon(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isScaly) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            IsScaly = isScaly;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 1)
            {
                IsScaly = true;
            }
            else
            {
                IsScaly = false;
            }
            Life = CalcBlock();
        }
        public override int CalcBlock()
        {
            int calculatedHealth = MaxLife;

            if (IsScaly)
            {
                calculatedHealth += 15;
            }

            return calculatedHealth;
        }
        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }
    }
}
