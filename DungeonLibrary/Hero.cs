namespace DungeonLibrary
{
    public class Hero
    {
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;
        private int _life;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }
    }
}