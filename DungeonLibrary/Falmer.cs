using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Falmer : Monster
    {
        //Fields

        //Properties
        public bool IsSneaky { get; set; }
        //Constructors
        public Falmer()
        {
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsSneaky = true;
            }
            else
            {
                IsSneaky = false;
            }
            if (IsSneaky)
            {
                MaxDamage = 7 + CalcBlock();
            }
            else
            {
                MaxDamage = 7;
            }
            MinDamage = 2;
            MaxLife = 15;
            Name = "Falmer";
            Life = MaxLife;
            HitChance = 65;
            Block = 5;
            Description = "A creature that turned away it's daedra's light and fled to their underground brothers.";
        }
        public Falmer(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isSneaky) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            IsSneaky = isSneaky;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsSneaky = true;
            }
            else
            {
                IsSneaky = false;
            }
            MaxDamage = CalcBlock();
        }
        public override int CalcBlock()
        {
            int maxDamage = MaxDamage;
            if (IsSneaky)
            {
                maxDamage += 6;
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
