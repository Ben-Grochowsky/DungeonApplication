using DungeonLibrary;
using Spectre.Console;
using System.Net;

namespace DungeonApp
{
    internal class DungeonMenu
    {
        static void Main(string[] args)
        {
            #region Title/Introduction
            Console.WriteLine("Hey, You, You're finally awake. You were trying to cross the border, right? \nWalked right into that Imperial ambush, same as us, and that thief over there.\n");
            #endregion

            #region Player Creation
            // - possible expansion - Display a list of pre-created weapons and let them pick one
            // - recommendation: GetWeapon() in the Weapon class that returns a weapon
            Weapon wep = null;
            Random rand = new Random();
            int random = rand.Next(0, 5);
            switch (random)
            {
                case 0:
                    wep = new Weapon("Miraak's Staff", 3, 16, 30, false, WeaponType.Sword);
                    break;
                case 1:
                    wep = new Weapon("Glass Sword", 4, 12, 20, false, WeaponType.Sword);
                    break;
                case 2:
                    wep = new Weapon("Bow of Shadows", 6, 15, 5, true, WeaponType.Bow);
                    break;
                case 3:
                    wep = new Weapon("Daedric Warhammer", 5, 15, 5, true, WeaponType.Sword);
                    break;
                case 4:
                    wep = new Weapon("Elven Greatsword", 5, 12, 15, true, WeaponType.Sword);
                    break;
            }

            Console.WriteLine("\n...And who are you?");
            AnsiConsole.MarkupLine("[italic]Enter your name here: [/]\n");
            string name = Console.ReadLine();

            bool chooseRace = false;
            int count = 0;
            Console.WriteLine("\nWhat race would you like to play as?");
            Player player = null;
            do
            {
                if (count >= 1)
                {
                    Console.WriteLine("\nPlease choose a proper race\n");
                }
                Console.WriteLine("A: Argonian     H: High Elf     B: Breton     N: Nord     D: Dark Elf");
                string race = Console.ReadKey(true).Key.ToString();
                switch (race)
                {
                    case "A":
                        player = new Player(name, 75, 40, 50, Race.Argonian, wep);
                        chooseRace = true;
                        break;
                    case "H":
                        player = new Player(name, 75, 40, 50, Race.High_Elf, wep);
                        chooseRace = true;
                        break;
                    case "B":
                        player = new Player(name, 75, 40, 50, Race.Breton, wep);
                        chooseRace = true;
                        break;
                    case "N":
                        player = new Player(name, 75, 40, 50, Race.Nord, wep);
                        chooseRace = true;
                        break;
                    case "D":
                        player = new Player(name, 75, 40, 50, Race.DarkElf, wep);
                        chooseRace = true;
                        break;
                    default:
                        count += 1;
                        break;
                }
            } while (!chooseRace);
            Console.WriteLine();
            #endregion





            //Game loop:
            bool exit = false;
            do
            {
                //generate a room
                string room = GetRoom();
                Console.WriteLine(room);
                //generate a monster in the room
                Monster monster = Monster.GetMonster();
                Console.Write("\nYou have encountered a ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(monster.Name);
                Console.ResetColor();
                //Encounter loop:
                bool reload = false;//reload = true to "reload" a room and a monster
                do
                {
                    #region Menu
                    //prompt the user:
                    Console.Write("\nPlease choose an action:\n" +
                                  "A) Attack\n" +
                                  "R) Run away\n" +
                                  "P) Player Info\n" +
                                  "M) Monster Info\n" +
                                  "X) Exit\n");
                    //Capture user's menu selection
                    string menuSelection = Console.ReadKey(true).Key.ToString();//Executes upon input without hitting enter
                    //Clear the console AFTER user input
                    Console.Clear();

                    //using branching logic to act upon the user's menu selection
                    switch (menuSelection)
                    {
                        case "A":
                            Console.WriteLine("Combat!");
                            //if the monster is dead, DoBattle returns true and reloads the room
                            reload = Combat.DoBattle(player, monster);
                            break;

                        case "R":
                            Console.WriteLine("Run Away!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case "P":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            break;

                        case "M":
                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;

                        case "X":
                        case "E":
                            Console.WriteLine("No one likes a quitter...");
                            //exit both loops
                            exit = true;
                            break;
                        default:
                            //invalid input.
                            Console.WriteLine("You have chosen poorly...");
                            break;
                    }
                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("You took one too many arrows to the knee...\a");

                        exit = true;//leave both loops
                    }
                } while (!reload && !exit);
                //if exit = true, both loops will terminate.
                //If reload = true, only the inner loop will terminate.

            } while (!exit); //exit == false
            Console.WriteLine($"You have defeated {player.Score} monster{(player.Score == 1 ? "." : "s.")}");
        }//end main
        //Custom Method called GetRoom() -> Reference Magic8Ball
        private static string GetRoom()
        {
            Random randRoom = new Random();
            //TODO Update room descriptions
            //Collection Initialization Syntax
            string[] rooms = { "\nYou arrive in the room and see a massive tree at the center of the room and you decide to walk towards it.\nWhile walking towards it you encounter a monster.",
                               "\nWhen you walk into the castle you sense all light fading from the room and realize that something or someone\nis the root of this phenomenon. You venture further and encounter the source.",
                               "\nYou finally escape those infernal dwarven tunnels and stumble upon a very open cavern. You decide to explore \nand realize from a book that this place is called Blackreach. As you marvel at the brilliant blue lights \nabove you you see a strange creature ahead of you.",
                               "\nAfter hours of training with the Graybeards you decide to go to the peak of the mountain to finally meet their master.\nAs you climb you see a silhouette through the snow. ", 
                               "\nWhile walking through a tunnel you see light. As you continue walking the tunnel opens up into a grove with with \ntrees and an open sky. As you explore this grotto you encounter a monster." };
            int randomRoom = randRoom.Next(rooms.Length);
            return rooms[randomRoom];
        }
    }//end class
}//end namespace