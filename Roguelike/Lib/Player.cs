namespace Lib
{
    public class Player
    {
        public string name;
        public int hp;
        public int maxhp;
        public Aid aid;
        public Weapon weapon;
        public int points;
        public Player()
        {
            this.name = "Неизвестный путник";
            this.hp = 50;
            this.maxhp = 50;
            this.aid = new Aid("Маленькая аптчека", 10);
            this.points = 0;
        }
        public Player(string n)
        {
            this.name = n;
            this.hp = 50;
            this.maxhp = 50;
            this.aid = new Aid("Маленькая аптчека", 10);
            this.points = 0;
        }
    }
}

