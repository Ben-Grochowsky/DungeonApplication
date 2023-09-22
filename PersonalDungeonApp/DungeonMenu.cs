using DungeonLibrary;

namespace DungeonApp
{
    internal class DungeonMenu
    {
        static void Main(string[] args)
        {
            #region Title/Introduction
            Console.WriteLine("Hello, World!\n");
            #endregion

            //TODO Create a player
            Player h1 = new("Frodo Baggins", 6, 5, 40, Race.Hobbit, WeaponType.Sword);
            Console.WriteLine(h1);

            Weapon w1 = new Weapon("Sting", 1, 15, 5, false, WeaponType.Sword);
            Console.WriteLine(w1);

            //Game loop:
            bool exit = false;
            do
            {
                //TODO generate a room
                string room = GetRoom();
                Console.WriteLine(room);
                //TODO generate a monster in the room

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
                            //put combat functionality here
                            break;

                        case "R":
                            Console.WriteLine("Run Away!");
                            //put free monster attack here
                            //get a new monster and a new room:
                            reload = true;
                            break;

                        case "P":
                            Console.WriteLine("Player Info");
                            //print player info here
                            break;

                        case "M":
                            Console.WriteLine("Monster Info");
                            //print monster info here
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

                    //TODO Check Player Life
                } while (!reload && !exit);
                //if exit = true, both loops will terminate.
                //If reload = true, only the inner loop will terminate.

            } while (!exit); //exit == false
            //TODO handle exit messages and stuff
        }//end main
        //Custom Method called GetRoom() -> Reference Magic8Ball
        private static string GetRoom()
        {
            Random randRoom = new Random();
            //TODO Update room descriptions
            //Collection Initialization Syntax
            string[] rooms = { "Room1", "Room2", "Room3", "Room4", "Room5" };
            int randomRoom = randRoom.Next(rooms.Length);
            return rooms[randomRoom];
        }
    }//end class
}//end namespace