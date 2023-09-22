using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Monster : Hero
    {
        //Fields
        private int _minDamage;

        //Properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if ((value > 0 && value < MaxDamage))
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        //Constructors
        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, string description, int minDamage) : base(name, hitChance, block, maxLife)
        {
            MaxDamage = maxDamage;
            Description = description;
            MinDamage = minDamage;
        }

        //Methods
        public override string ToString()
        {
            return $"\n********** MONSTER **********\n" +
                   base.ToString() +
                   $"Damage: {MinDamage} to {MaxDamage}" +
                   $"Description: {Description}";
        }
    }
}
