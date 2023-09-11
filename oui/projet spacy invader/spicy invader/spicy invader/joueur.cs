using System.Drawing;

namespace enemie
{



    public class Joueur
    {
        
        public int x = 0;
        public int y = 20; // Modifiez cette valeur si nécessaire
        public static string[] playerDesign = new string[] { "  /\\", " /__\\", "[i][i]" };
        int premierTirs = 0;
        private List<Tirs> tirsActifs = new List<Tirs>();
        public void jouer()
        {
            if (Console.KeyAvailable)
            {
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
                        // Créez un nouveau tir et ajoutez-le à la liste des tirs actifs
                        Tirs tirer = new Tirs { titre = true, Y = y, X = x };
                        tirsActifs.Add(tirer);
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
            x = Console.WindowWidth / 2;
            for (int i = 0; i < playerDesign.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(playerDesign[i]);
            }
        }
        public void afficherVaisseau()
        {
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
            if (x < Console.WindowWidth - playerDesign[0].Length)
            {
                effacerVaisseau();
                x++;
                afficherVaisseau();
            }
            
            
        }

        public void gauche()
        {
            if (x > 0)
            {
                effacerVaisseau();
                x--;
                afficherVaisseau();
            }
           
            
        }
    }

}


