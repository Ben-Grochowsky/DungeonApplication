using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Hero
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
        public Monster()
        {

        }

        //Methods
        public override string ToString()
        {
            return $"\n********** MONSTER **********\n" +
                   $"Name: {Name}\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Block: {Block}%\n" +
                   $"Damage: {MinDamage} to {MaxDamage}\n" +
                   $"Description: {Description}\n";
        }
        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            int result = 0;//create the return object

            Random rand = new Random();//setup necessary resources

            result = rand.Next(MinDamage, MaxDamage + 1);//modify the return object

            return result;//return the return object
        }

        public static Monster GetMonster()
        {
            //create the return object
            Monster m = new();
            //setup necessary resources
            Bandit banditChief = new("Bandit Chief",70,10,25,12,4,"Prepare to die!",true );
            Daugr daugrDeathlord = new("Daugr DeathLord", 75, 20, 25, 15, 7, "An undead that has obtained the very Thu'um you speak", false);
            Dragon legendaryDragon = new("Legendary Dragon", 80, 10, 100, 30, 5, "As you see this terrifying yet brilliant creature spew fire at you, you begin to hear the bells of Sovengarde, but\nyou will not hear them in their full glory today.", false);
            Falmer falmerShadowmaster = new("Falmer Shadowmaster", 70, 10, 20, 10, 4, "Powerful creatures that have mastered the caves and the ability see in them despite having no light.", false);
            FireMage fireMage = new("Fire Mage", 70, 10, 16, 10, 4, "Don't you see? I am master of the arcane!", true);
            IceMage iceMage = new("Ice Mage", 70, 10, 16, 10, 4, "Fire, frost, or lightning - you will suffer at my hands!", true);
            Wolf iceWolf = new("Ice Wolf", 80, 10, 22, 13, 5, "Beasts that hunt alone in search for any poor sole to tired from the cold.", true);
            Vampire vampire = new("Vampire", 80, 15, 25, 20, 8, "True masters of the night", true);

            var youngBandit = new Bandit();
            var regDaugr = new Daugr();
            var regDragon = new Dragon();
            var noviceFireMage = new FireMage();
            var noviceIceMage = new IceMage();
            var falmer = new Falmer();
            var wolf = new Wolf();
            var vampireFledgling = new Vampire();
            List<Monster> monsters = new()
            {
                youngBandit, youngBandit, youngBandit, youngBandit,
                regDaugr, regDaugr, regDaugr, regDaugr,
                regDragon, regDragon,
                falmer, falmer, falmer,
                noviceFireMage, noviceFireMage,
                noviceIceMage, noviceIceMage,
                wolf, wolf, wolf, wolf,
                vampireFledgling, vampireFledgling,
                banditChief,banditChief,
                daugrDeathlord,
                legendaryDragon,
                fireMage, 
                iceMage, 
                vampire,
                iceWolf, iceWolf,
                falmerShadowmaster
            };
            Random rand = new Random();
            int randomIndex = rand.Next(monsters.Count);
            //modify the return object
            m = monsters[randomIndex];
            //return the return object
            return m;

            //refactor
            //return monsters[new Random().Next(monsters.Count)];
        }
    }
}
