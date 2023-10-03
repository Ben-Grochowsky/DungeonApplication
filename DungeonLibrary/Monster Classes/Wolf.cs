namespace DungeonLibrary
{
    public class Wolf : Monster
    {
        //Fields
        private bool _isSneaky;

        //Properties
        public bool IsSneaky {
            get
            {
                return _isSneaky;
            } 
            set
            {
                _isSneaky = value;
            } 
        }

        //Constructors
        public Wolf()
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
            MaxDamage = 10;
            MinDamage = 3;
            MaxLife = 18;
            Name = "Wolf";
            Life = MaxLife;
            if (IsSneaky)
            {
                HitChance = 70 + CalcBlock();
            }
            else
            {
                HitChance = 70;
            }
            Block = 8;
            Description = "Careful! They hunt in packs!";
        }

        public Wolf(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description, bool isSneaky) : 
            base(name, hitChance, block, maxLife, maxDamage, description, minDamage)
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
            HitChance = CalcBlock();
        }

        // Methods
        public override int CalcHitChance()
        {
            int hitChance = HitChance;
            if (IsSneaky)
            {
                hitChance += 5;
            }
            return hitChance;
        }

        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }
    }
}
