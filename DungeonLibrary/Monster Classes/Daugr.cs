using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Daugr : Monster
    {
        //Fields

        //Properties
        public bool IsSleeping { get; set; }
        //Constructors
        public Daugr()
        {
            MaxLife = 15;
            MaxDamage = 8;
            MinDamage = 3;
            Name = "Daugr";
            Life = MaxLife;
            HitChance = 65;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsSleeping = true;
            }
            else
            {
                IsSleeping = false;
            }
            if (IsSleeping)
            {
                Block = 15 + CalcBlock();
            }
            else
            {
                Block = 15;
            }
            Description = "A foul monster lurking in the very tombs you are raiding";
        }
        public Daugr(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isSleeping) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            IsSleeping = isSleeping;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                IsSleeping = true;
            }
            else
            {
                IsSleeping = false;
            }
            if (IsSleeping)
            {
                Block = 15 + CalcBlock();
            }
            else
            {
                Block = 15;
            }
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsSleeping)
            {
                calculatedBlock -= 15;
            }
            return calculatedBlock;
        }
        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }
    }
}
