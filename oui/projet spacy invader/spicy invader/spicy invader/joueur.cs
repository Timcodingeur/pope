using System.Drawing;

namespace enemie
{



    public class Joueur
    {
        public static Joueur CurrentPlayer { get; set; }

       
        public int x = 0;
        public int y = 20; // Modifiez cette valeur si nécessaire
        public static string[] playerDesign = new string[] { "  /\\", " /__\\", "[i][i]" };
        int premierTirs = 0;
        private List<Tirs> tirsActifs = new List<Tirs>();
        public int temp = 0;
        
        public void jouer()
        {
            

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < tirsActifs.Count; i++)
            {

                Tirs t = tirsActifs[i];
                bool hit = false;
                for (int j = 0; j < Enemie.enemies.Count && !hit; j++)
                {
                    Enemie e = Enemie.enemies[j];
                    if (t.Y == e.y && (t.X == e.x || t.X == e.x + 1 || t.X == e.x - 1 || t.X == e.x - 2 || t.X == e.x - 3))
                    {
                        e.life--;
                        tirsActifs.RemoveAt(i);
                        i--;
                        hit = true; // Indique qu'il y a eu une collision
                        Console.SetCursorPosition(t.X, t.Y);
                        Console.Write(" ");
                       
                    }
                }
                if (hit) break; // Si un tir a touché un ennemi, sortez de la boucle externe
            }



            if (Console.KeyAvailable)
            {
                temp--;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        gauche();
                        break;
                    case ConsoleKey.RightArrow:
                        droite();
                        break;
                    case ConsoleKey.Spacebar:
                        tiron();
                        break;
                    default:
                        break;
                }
            }
            
            // Mettez à jour tous les tirs actifs
            for (int i = 0; i < tirsActifs.Count; i++)
            {
                tirsActifs[i].Tir();

                // Si le tir est hors de l'écran, supprimez-le de la liste
                if (tirsActifs[i].Y < 1)
                {
                    Console.SetCursorPosition(tirsActifs[i].X+2, tirsActifs[i].Y);
                    Console.Write(" ");
                    tirsActifs.RemoveAt(i);
                    i--; // Ajustez l'index après avoir supprimé un élément
                    
                }
            }
        }
        public void apparait()
        {
            Joueur.CurrentPlayer = this;  // Initialisez l'instance actuelle

            x = Console.WindowWidth / 2;
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(playerDesign[i]);
            }
        }
        public void afficherVaisseau()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(playerDesign[i]);
            }
        }

        public void effacerVaisseau()
        {
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(new string(' ', playerDesign[i].Length));
            }
        }

        public void droite()
        {
           
            Console.ForegroundColor = ConsoleColor.White;
            if (x < Console.WindowWidth - playerDesign[0].Length)
            {
                effacerVaisseau();
                x++;
                afficherVaisseau();
            }
            
            
        }
        public void tiron()
        {
            if (temp < 10)
            {
                // Créez un nouveau tir et ajoutez-le à la liste des tirs actifs
                Tirs tirer = new Tirs { titre = true, Y = y, X = x };
                tirsActifs.Add(tirer);
                temp += 10;
            }
        }
        public void gauche()
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            if (x > 0)
            {
                effacerVaisseau();
                x--;
                afficherVaisseau();
            }
           
            
        }
    }

}


