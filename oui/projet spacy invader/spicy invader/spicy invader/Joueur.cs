using System.Drawing;

namespace enemie
{



    public class Joueur
    {
        public static Joueur? CurrentPlayer { get; set; }
        public static byte jouLife = 5;
        DateTime startTime = DateTime.Now;
        public byte enemieTuer = 0;
        public int x = 0;
        public int y = 20; // Modifiez cette valeur si nécessaire
        public static string[] playerDesign = new string[] { "  /\\", " /__\\", "[i][i]" };
        private List<Tirs> tirsActifs = new();
        public int temp = 0;
        
        public void Jouer()
        {

           
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < tirsActifs.Count; i++)
            {

                Tirs t = tirsActifs[i];
                bool hit = false;
                for (int j = 0; j < Enemie.enemies.Count && !hit; j++)
                {
                    Enemie e = Enemie.enemies[j];
                    if (t.Y == e.y && (t.X == e.x || t.X == e.x + 1 || t.X == e.x - 1 || t.X == e.x - 2 || t.X == e.x - 3|| t.X == e.x + 2))
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
                        Gauche();
                        break;
                    case ConsoleKey.RightArrow:
                        Droite();
                        break;
                    case ConsoleKey.Spacebar:
                        Tirer();
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
        public void Apparait()
        {
            Joueur.CurrentPlayer = this;  // Initialisez l'instance actuelle

            x = Console.WindowWidth / 2;
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(playerDesign[i]);
            }

            jouLife = 5;
        }
        public void AfficherVaisseau()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(playerDesign[i]);
            }
        }

        public void EffacerVaisseau()
        {
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(new string(' ', playerDesign[i].Length));
            }
        }

        public void Droite()
        {
           
            Console.ForegroundColor = ConsoleColor.White;
            if (x < Console.WindowWidth - playerDesign[0].Length)
            {
                EffacerVaisseau();
                x++;
                AfficherVaisseau();
            }
            
            
        }
        public void Tirer()
        {
            if (temp < 10)
            {
                // Créez un nouveau tir et ajoutez-le à la liste des tirs actifs
                Tirs tirer = new() { titre = true, Y = y, X = x };
                tirsActifs.Add(tirer);
                temp += 10;
            }
        }
        public void Gauche()
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            if (x > 0)
            {
                EffacerVaisseau();
                x--;
                AfficherVaisseau();
            }
           
            
        }
    }

}


