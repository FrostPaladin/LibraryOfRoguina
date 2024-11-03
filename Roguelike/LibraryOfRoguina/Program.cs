using Lib;
using System;
using System.Runtime.InteropServices.JavaScript;

List <Weapon> weapons = new List <Weapon> (13);
weapons.Add(new Weapon("Железная труба", 5, 999));
weapons.Add(new Weapon("Боевой нож", 10, 20));
weapons.Add(new Weapon("Бита с шипами", 18, 10));
weapons.Add(new Weapon("Заржавевший меч", 15, 10));
weapons.Add(new Weapon("Заряженный виброклинок", 35, 5));
weapons.Add(new Weapon("Излучающий энергию фотоэлектрический клинок", 50, 6));
weapons.Add(new Weapon("Заточенный гарпун", 25, 20));
weapons.Add(new Weapon("Эфемерный черный клинок Роланда", 999, 1));
weapons.Add(new Weapon("Огромная дубина", 20, 7));
weapons.Add(new Weapon("Цвайхандер", 30, 20));
weapons.Add(new Weapon("Сияющий клинок света", 40, 20));
weapons.Add(new Weapon("Дюрандал", 60, 30));
weapons.Add(new Weapon("Катана", 45, 10));

List<Enemy> enemies = new List <Enemy> (10);
enemies.Add(new Enemy("Бандит с большой дороги", 20, 20, 20));
enemies.Add(new Enemy("Рыцарь в черных доспехах", 50, 50, 50));
enemies.Add(new Enemy("Орк-варвар", 40, 40, 40));
enemies.Add(new Enemy("Наемник", 30, 30, 30));
enemies.Add(new Enemy("Крылатая гарпия", 25, 25, 20));
enemies.Add(new Enemy("Злобный огр", 80, 80, 100));
enemies.Add(new Enemy("Молчаливый самурай", 60, 60, 60));
enemies.Add(new Enemy("Опасный человек в черном костюме", 100, 100, 200));
enemies.Add(new Enemy("Закованный в латы гигант", 200, 200, 500));
enemies.Add(new Enemy("Подлый разбойник", 15, 15, 10));

List <Aid> healing = new List <Aid> (5);
healing.Add(new Aid("Маленькая аптечка", 10));
healing.Add(new Aid("Средняя аптечка", 20));
healing.Add(new Aid("Большая аптечка", 30));
healing.Add(new Aid("Военная аптечка", 50));

Random rnd = new Random();

Console.WriteLine("Добро пожаловать в Библиотеку!\n" +
    "Здесь вы сможете исполнить любые ваши желания...\n" +
    "Но для этого вам придется сразиться с различными личностями и существами из книг!\n" +
    "Как вас зовут, уважаемый гость?");
Player gamer = new Player();
string playername = Console.ReadLine();
if (playername != "")
{
    gamer.name = playername;
    Console.WriteLine(gamer.name);
}
Console.WriteLine();
Console.WriteLine("Приветствуем, " + gamer.name + "!\n" +
    "Вам предстоит скоро сразиться с бесчисленными противниками ради своей цели.\n" +
    "Готовы ли вы начать?\n" +
    "(Да/Нет)");
    string start = Console.ReadLine();
    if (start == "Да" || start == "ДА" || start == "да")
    {
    int w = rnd.Next(0, weapons.Count - 1);
    gamer.weapon = weapons[w];
    Console.WriteLine();
    Console.WriteLine("Вы подобрали " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability);
    while (gamer.hp > 0)
    {
        Console.WriteLine("У вас сейчас " + gamer.hp + "хп");
        int e = rnd.Next(0, enemies.Count - 1);
        Enemy foe = enemies[e];
        foe.hp = foe.maxhp;
        int w2 = rnd.Next(0, weapons.Count - 1);
        foe.weapon = weapons[w2];
        Console.WriteLine();
        Console.WriteLine("Перед вами появляется " + foe.name + "!");
        Console.WriteLine("У него " + foe.hp + "хп и в руках он держит " + foe.weapon.name + "! (урон оружия: " + foe.weapon.damage + ")");
        while (gamer.hp > 0 & foe.hp > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Ваши действия?\n" +
            "1 - атаковать\n" +
            "2 - полечиться\n" +
            "3 - починить оружие");
            int action = Convert.ToInt32(Console.ReadLine());
            switch(action)
            {
                case 1:

                    if (gamer.weapon.durability > 0)
                    {
                    Console.WriteLine();
                    foe.hp -= gamer.weapon.damage;
                    Console.WriteLine("Вы ударили " + foe.name + "!\n" +
                        "");
                    Console.WriteLine("Он получил " + gamer.weapon.damage + " урона!\n" +
                        "");
                    Console.WriteLine("У него осталось " + foe.hp + "хп!\n" +
                        "");
                    gamer.weapon.durability = gamer.weapon.durability - 1;
                    Console.WriteLine("Ваш " + gamer.weapon.name + " потерял 1 единицу прочности, осталось :" + gamer.weapon.durability + ".");
                    }
                    else
                    {
                        gamer.weapon = weapons[0];
                        Console.WriteLine("Ваше оружие сломалось, вам придется драться тем, что попалось под рукой!");
                        Console.WriteLine("Вы подобрали " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability);
                    }
                    break;
                    

                case 2:
                    Console.WriteLine();
                    int hp = gamer.hp + gamer.aid.heals;
                    if (hp > gamer.maxhp)
                    {
                        gamer.hp = gamer.maxhp;
                        Console.WriteLine("Вы использовали " + gamer.aid.name + " и вылечили себе " + gamer.aid.heals + " здоровья!");
                        Console.WriteLine("У вас сейчас " + gamer.hp + "хп");
                    }
                    else
                    {
                        gamer.hp += gamer.aid.heals;
                        Console.WriteLine("Вы использовали " + gamer.aid.name + " и вылечили себе " + gamer.aid.heals + " здоровья!");
                        Console.WriteLine("У вас сейчас " + gamer.hp + "хп");
                    }
                    break;
                case 3:
                    Console.WriteLine();
                    gamer.weapon.durability += 1;
                    Console.WriteLine("Вы восстановили вашему оружию 1 единицу прочности");
                    Console.WriteLine("Ваш " + gamer.weapon.name + " имеет :" + gamer.weapon.durability + " прочности.");
                    break;
            }
            if (foe.hp > 0)
            {
                Console.WriteLine();
                Console.WriteLine(foe.name + " атакует вас, используя " + foe.weapon.name + "!\n" +
                "");
                gamer.hp -= foe.weapon.damage;
                Console.WriteLine("Вы получили " + foe.weapon.damage + " урона!\n" +
                "\n" +
                "У вас осталось " + gamer.hp + "хп!");
            }
            else
            {
                gamer.points += foe.pointsaward;
                Console.WriteLine();
                Console.WriteLine(foe.name + " побежден!\n" +
                "Вы получаете " + foe.pointsaward + " очков, у вас сейчас " + gamer.points + " очков!\n");
                Console.WriteLine("У вашего " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability);
                Console.WriteLine("Враг обронил " + foe.weapon.name + "!");
                if (gamer.weapon.durability > 0)
                {
                    Console.WriteLine("Хотите ли подобрать его оружие ?\n" +
                    "(Да/Нет)");
                    string choice = Console.ReadLine();
                    if (choice == "Да" || choice == "ДА" || choice == "да")
                    {
                        gamer.weapon = foe.weapon;
                        Console.WriteLine();
                        Console.WriteLine("Вы подобрали " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability);
                    }
                }
                else if (gamer.weapon.durability == 0)
                {
                    gamer.weapon = foe.weapon;
                    Console.WriteLine("Вы подобрали " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability);
                }
                Console.WriteLine();
                Console.WriteLine("Поздравляем с победой над врагом, " + gamer.name + "!");
                Console.WriteLine("У вас сейчас " + gamer.hp + "хп.");
                Console.WriteLine("Вы держите " + gamer.weapon.name + ", урон: " + gamer.weapon.damage + ", прочность: " + gamer.weapon.durability + ".");
                Console.WriteLine("Ваш предмет для лечения это - " + gamer.aid.name + ", лечит " + gamer.aid.heals + " здоровья.");
                Console.WriteLine("У вас сейчас " + gamer.points + " очков!");
                Console.WriteLine();
                Console.WriteLine("У вас есть небольшой перерыв перед следующим боем.\n" +
                    "Ваши действия?\n" +
                    "1 - улучшить аптечку\n" +
                    "2 - починить оружие(+1 единица прочности)\n" +
                    "3 - полечиться \n" +
                    "4 - начать следующий бой");
                int decision = Convert.ToInt32(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        if (gamer.points >= 100)
                        {
                            Console.WriteLine("Выбор аптечки: \n" +
                                "1 - " + healing[1].name + ", лечит " + healing[1].heals + " здоровья\n" + ", стоимость - 100\n" +
                                "2 - " + healing[2].name + ", лечит " + healing[2].heals + " здоровья\n" + ", стоимость - 200\n" +
                                "3 - " + healing[3].name + ", лечит " + healing[3].heals + " здоровья\n" + ", стоимость - 500\n");
                            int buy = Convert.ToInt32(Console.ReadLine());
                            switch (buy)
                            {
                                case 1:
                                    if (gamer.points >= 100)
                                    {
                                        gamer.points -= 100;
                                        gamer.aid = healing[1];
                                        Console.WriteLine("Вы купили " + gamer.aid.name + ".");
                                    }
                                    break;
                                case 2:
                                    if (gamer.points >= 200)
                                    {
                                        gamer.points -= 200;
                                        gamer.aid = healing[2];
                                        Console.WriteLine("Вы купили " + gamer.aid.name + ".");
                                    }
                                    break;
                                case 3:
                                    if (gamer.points >= 500)
                                    {
                                        gamer.points -= 500;
                                        gamer.aid = healing[3];
                                        Console.WriteLine("Вы купили " + gamer.aid.name + ".");
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("У вас недостаточно очков.");
                        }
                        break;
                    case 2:
                        gamer.weapon.durability += 1;
                        Console.WriteLine("Вы восстановили вашему оружию 1 единицу прочности");
                        Console.WriteLine("Ваш " + gamer.weapon.name + " имеет :" + gamer.weapon.durability + " прочности.");
                        break;
                    case 3:
                        Console.WriteLine();
                        int hp = gamer.hp + gamer.aid.heals;
                        if (hp > gamer.maxhp)
                        {
                            gamer.hp = gamer.maxhp;
                            Console.WriteLine("Вы использовали " + gamer.aid.name + " и вылечили себе " + gamer.aid.heals + " здоровья!");                        }
                        else
                        {
                            gamer.hp += gamer.aid.heals;
                            Console.WriteLine("Вы использовали " + gamer.aid.name + " и вылечили себе " + gamer.aid.heals + " здоровья!");
                        }
                        break;
                }
            }
        }
    }
    Console.WriteLine();
    Console.WriteLine("Игра окончена, " + gamer.name + ".");
    Console.WriteLine("Вы набрали " + gamer.points + " очков.");
    if (gamer.points >= 500)
    {
        Console.WriteLine("Вы смогли победить великое множество противников!\n" +
            "Можете гордиться собой, ведь вы действительно исключительный воин. \n" +
            "Да сбудутся ваши мечты...");
        Console.ReadLine();
    }
    else if (gamer.points >= 250) 
    {
        Console.WriteLine("А вы хороши в бою, но, к сожалению, вам не хватило совсем чуть-чуть сил, чтобы достигнуть желаемого...\n" +
            "Возможно, вам повезет в следующий раз..");
        Console.ReadLine();
    }
    else if (gamer.points >= 50)
    {
        Console.WriteLine("Хорошая попытка, уважаемый гость, но у вас не хватило сил преодолеть испытания библиотеки.\n" +
            "Возможно, вам повезет в следующий раз..");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Это было пустой тратой времени...Надеюсь, следующий гость не разочарует меня так же, как вы...");
        Console.ReadLine();
    }
}
else
{
    Console.WriteLine("Тогда, увидимся позже, когда вы будете готовы...");
    Console.ReadLine();
}
