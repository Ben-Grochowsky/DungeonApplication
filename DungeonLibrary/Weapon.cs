using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _type;

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //business rule:
                //0 < MinDamage <= MaxDamage
                if (value > 0 && value <= MaxDamage)
                {
                    //good to go
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        //WeaponType Type {get{}set{}}
        //CTORS
        //Add WeaponType type to param list
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        //What's a property doing? 
        //public void SetName(string value)
        //{
        //    _name = value;
        //}
        //public string GetName()
        //
        //    return _name;
        //}
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded, WeaponType type)
        {
            //ANY props that have business rules that depend on OTHER properties
            //must be assigned AFTER the independent properties are set.
            //MinDamage depends on MaxDamage, so MaxDamage must be set first.
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }//Fully-Qualified Constructor

        //Method:
        public override string ToString()
        {
            //return base.ToString();//namespace.classname
            return $"----- Weapon Name -----\n" +
                   $"Name: {Name}\n" +
                   $"Damage: {MinDamage} to {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"{(IsTwoHanded ? "Two-" : "One")}Handed {Type}";
        }
    }
}
