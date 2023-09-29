using MySql;
using System;
using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;
namespace enemie
{
    internal class GameEngine
    {
        Joueur jeux = new Joueur();
        Enemie enemie = new Enemie();
        int fpscal = 16;


        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("####################################");
            Console.WriteLine("###       SPACE INVADERS         ###");
            Console.WriteLine("####################################");
            Console.WriteLine();
            Console.WriteLine("1. Jouer");
            Console.WriteLine("2. High Score");
            Console.WriteLine("3. Quitter");
            Console.WriteLine();
            Console.Write("Choisissez une option (1/2/3) : ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    new GameEngine().Start();
                    break;
                case "2":
                    Connection.Connect();
                    break;
                case "3":
                    QuitGame();
                    break;
                default:
                    Console.WriteLine("Option non valide. Appuyez sur une touche pour revenir au menu principal.");
                    Console.ReadKey();
                    ShowMainMenu();
                    break;
            }

        }
        private static void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Merci d'avoir joué !");
            Environment.Exit(0);
        }
        public void Start()
        {
           
            Enemie.LancerEn();
            jeux.apparait();
            while (true)
            {

                Console.CursorVisible = false;
                enemie.moove();
                jeux.jouer();
                
                Thread.Sleep(fpscal);
                if (enemie.NumberEnemy == 0)
                {
                    Enemie.enemies.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Barvo vous avez gagner");
                    Console.WriteLine("cliquer sur une touche pour continuer");
                    Console.ReadLine();
                    break;
                }
                if(enemie.jouLife==0)
                {
                    Enemie.enemies.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("tu a perdu (RIP)");
                    Console.WriteLine("cliquer sur une touche pour continuer");
                    Console.ReadLine();
                    break;
                }
                
                
            }
            
        }
    }
}
