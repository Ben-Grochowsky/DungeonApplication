using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class FireMage : Monster
    {
        //Fields

        //Properties
        public bool BlessingOfArkay { get; set; }
        //Constructors
        public FireMage()
        {
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                BlessingOfArkay = true;
            }
            else
            {
                BlessingOfArkay = false;
            }
            MaxLife = 12;
            MaxDamage = 7;
            MinDamage = 2;
            Name = "Novice Fire Mage";
            Life = CalcBlock();
            HitChance = 65;
            Block = 5;
            Description = "You cannot even conceive of the power I wield";
        }
        public FireMage(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool blessingOfArkay) : base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
        {
            BlessingOfArkay = blessingOfArkay;
            Random rand = new Random();
            int random = rand.Next(0, 10);
            if (random <= 2)
            {
                BlessingOfArkay = true;
            }
            else
            {
                BlessingOfArkay = false;
            }
            Life = CalcBlock();
        }
        public override int CalcBlock()
        {
            int maxLife = MaxLife;
            if (BlessingOfArkay)
            {
                maxLife += 4;
            }
            MaxLife = maxLife;
            return MaxLife;
        }
        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }
    }
}
