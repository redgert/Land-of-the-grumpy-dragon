using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        const int GameRows = 10;
        const int GameColumns = 20;

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            TextUtils.AnimateText("Welcome to the land of the grumpy Dragon...", 70);
            Thread.Sleep(1000);

            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                AskForMovement();
            } while (player.Health > 0);

            GameOver();
        }

        private void PlayerBackpack()
        {
            Console.WriteLine("\nBackpack : ");
            for (int i = 0; i < player.Backpack.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Backpack[i].ItemName}");
            }
            AskForItemAction();
        }

        private void AskForItemAction()
        {
            Console.Write("Which item do you wish to use? ");
            try
            {
                int itemIndex = int.Parse(Console.ReadLine());

                player.Backpack[itemIndex - 1].GetItemPower(player);
                player.Backpack.Remove(player.Backpack[itemIndex - 1]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Name: {player.Name} Health: {player.Health} Strength: {player.Strength} Backpack weight: {player.Backpack.Sum(x => x.Weight)}/{player.MaxWeight}");
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.B: PlayerBackpack(); break;
                default: isValidMove = false; break;
            }

            if (isValidMove && newX >= 0 && newX < world.GetLength(0) && newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
            }

            if (world[player.X, player.Y].Monster != null)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                //COMBAT
                do
                {
                    //Orc is afraid, runs
                    if (world[player.X, player.Y].Monster.Attack(player) == -1)
                    {
                        world[player.X, player.Y].Monster.Health = 0;
                        Console.WriteLine("Orc got scared, got a heartattack and died!");
                        break;
                    }

                    //Player strikes
                    if (RandomUtils.GetRandom(0, 2) == 0)
                    {
                        int playerAttackDamage = player.Attack(world[player.X, player.Y].Monster);
                        world[player.X, player.Y].Monster.Health -= playerAttackDamage;
                        Console.WriteLine($"Player attack: {playerAttackDamage} {world[player.X, player.Y].Monster.Name} health: {world[player.X, player.Y].Monster.Health}");

                    }
                    //Monster strikes
                    else
                    {
                        int monsterAttackDamage = world[player.X, player.Y].Monster.Attack(player);
                        player.Health -= monsterAttackDamage;
                        //player losing strength every time monster hits
                        --player.Strength;
                        Console.WriteLine($"{world[player.X, player.Y].Monster.Name} attack: {monsterAttackDamage} Player health: {player.Health}");

                    }
                } while (player.Health > 0 && world[player.X, player.Y].Monster.Health > 0);

                //Remove monster
                //Add monsterskeleton?
                if (world[player.X, player.Y].Monster.Health < 1)
                {
                    Console.WriteLine("You killed the monster");

                    int totalWeight = 0;
                    for (int i = 0; i < player.Backpack.Count; i++)
                    {
                        totalWeight += player.Backpack[i].Weight;
                    }
                    totalWeight += world[player.X, player.Y].Monster.Weight;

                    if (totalWeight <= player.MaxWeight)
                    {
                        player.Backpack.Add(world[player.X, player.Y].Monster);
                        Console.WriteLine($"Monster item is picked up");
                        Thread.Sleep(700);
                    }
                    else
                    {
                        Console.WriteLine("Backpack can't fit the item");
                        Console.ReadKey();
                    }


                    world[player.X, player.Y].Monster = null;

                }

                Console.ReadKey();


            }
            else if (world[player.X, player.Y].Item != null)
            {
                int totalWeight = 0;
                for (int i = 0; i < player.Backpack.Count; i++)
                {
                    totalWeight += player.Backpack[i].Weight;
                }
                totalWeight += world[player.X, player.Y].Item.Weight;

                if (totalWeight <= player.MaxWeight)
                {
                    player.Backpack.Add(world[player.X, player.Y].Item);
                    world[player.X, player.Y].Item = null;
                    Console.WriteLine($"Ooh! A thing");
                    Thread.Sleep(700);
                }
                else
                {
                    Console.WriteLine("Backpack can't fit the item");
                    Console.ReadKey();
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else if (room.Monster != null)
                    {
                        Console.Write(room.Monster.Icon);
                    }
                    else if (room.Item != null)
                    {
                        Console.Write(room.Item.Icon);
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.WriteLine("You dead!");
            Console.ReadKey();
            Play();
        }

        private void CreateWorld()
        {
            world = new Room[GameColumns, GameRows];

            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if ((player.X != x || player.Y != y))
                    {
                        if (RandomUtils.GetRandom(0, 100) < 10)
                        {
                            Monster monster;
                            int monsterType = RandomUtils.GetRandom(0, 3);
                            if (monsterType == 0)
                            {
                                monster = new Ogre(2, "Ogre arms");
                            }
                            else if (monsterType == 1)
                            {
                                monster = new Orc(2,"Orc legs");
                            }
                            else
                            {
                                monster = new Troll(5, "Troll face");
                            }

                            world[x, y].Monster = monster;
                        }

                        if (RandomUtils.GetRandom(0, 100) < 10)
                        {
                            Item itemType;
                            if (RandomUtils.GetRandom(0, 2) == 0)
                            {
                                itemType = new Weapon("Sword", 5, 10, "Sword");
                            }
                            else
                            {
                                itemType = new Potion("Health Potion", 2, 10, "Potion");
                            }
                            world[x, y].Item = itemType;
                        }
                    }
                }
            }

            //TODO maybe in own method
            world[world.GetLength(0) - 1, world.GetLength(1) - 1].Monster = new Dragon(10, "Dragon skin");
        }

        private void CreatePlayer()
        {
            player = new Player(100, 0, 0, "Knight Night");
        }
    }
}
