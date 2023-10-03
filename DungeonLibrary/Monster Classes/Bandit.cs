using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Bandit : Monster
    {
        //Fields

        //Properties
        public bool IsTired { get; set; }
        //Constructors
        public Bandit()
        {
            MaxLife = 20;
            MaxDamage = 8;
            MinDamage = 1;
            Name = "Bandit";
            Life = MaxLife;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsTired = true;
            }
            else
            {
                IsTired = false;
            }
            if (IsTired)
            {
                HitChance = 65 + CalcBlock();
            }
            else
            {
                HitChance = 65;
            }
            Block = 5;
            Description = "Time to end this little game!";
        }
        public Bandit(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isTired) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            IsTired = isTired;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsTired = true;
            }
            else
            {
                IsTired = false;
            }
            if (IsTired)
            {
                HitChance = CalcBlock();
            }
            else
            {
                HitChance = 65;
            }
        }
        public override int CalcBlock()
        {
            int calculatedHitChance = HitChance;
            if (IsTired)
            {
                calculatedHitChance -= 5;
            }
            return calculatedHitChance;
        }
        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + $"";
        }
    }
}
