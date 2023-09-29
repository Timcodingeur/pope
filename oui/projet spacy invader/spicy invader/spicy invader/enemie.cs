﻿namespace enemie
{



    public class Enemie
    {
        private List<Tirs> tirsEnemi = new List<Tirs>();
        public bool titre = false;
        ConsoleColor color = ConsoleColor.Gray;
        public static List<Enemie> enemies = new List<Enemie>();
        public static List<Enemie> enemiesToRemove = new List<Enemie>();
        public int jouLife = 5;
        public int x = 0;
        public int y;
        public int NumberEnemy = 20;
        public string skin = "-0_0-";
        public byte life = 3;
        public void MoveRight()
        {

            // Vérifier si x et y sont dans les limites
            if (x >= 0 && x < Console.WindowWidth - skin.Length && y >= 0 && y < Console.WindowHeight)
            {
                Console.ForegroundColor = color;
                // Vérifiez si x-1 est à l'intérieur des limites avant de définir la position du curseur

                if (x > 0)  // Ajout de cette vérification
                {
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(' ');
                }
                Console.CursorLeft = x;
                Console.Write(skin);
                x++;
                Mouvement();
                
            }

        }
        public void MoveLeft()
        {
            if (x > 0 && y >= 0 && y < Console.WindowHeight)
            {
                Console.ForegroundColor = color;

                // Efface l'ancienne position
                Console.SetCursorPosition(x + skin.Length, y);
                Console.Write(' ');

                Console.SetCursorPosition(x, y);
                Console.Write(skin);
                x--;
                Mouvement();
             
            }

        }
        public void Mouvement()
        { 
            switch (skin)
            {
                case "-0_0-":
                    skin = "^0^0^";
                    break;
                case "^0^0^":
                    skin = "-0_0-";
                    break;
                case ">-_-<":
                    skin = ">^-^<";
                    break;
                case ">^-^<":
                    skin = ">-_-<";
                    break;
                default:
                    skin = "^0^0^";
                    break;
            }
            
            switch(life)
            {
                case 3:
                    color = ConsoleColor.White;
                    break;
                case 2:
                    color = ConsoleColor.Green;
                    break;
                case 1:
                    color = ConsoleColor.Red;
                    break;
                case 0:
                    enemiesToRemove.Add(this);
                    Console.SetCursorPosition(x-1, y);
                    Console.Write("     ");
                    NumberEnemy--;
                    break;


            }

        }
        public void ClearPositionRight()
        {
            Console.SetCursorPosition(x-1, y);
            Console.Write("     ");
        }
        public void ClearPositionLeft()
        {
            Console.SetCursorPosition(x+1, y);
            Console.Write("     ");
        }
        public static int direction = 1; // 1 pour droite, -1 pour gauche
        public static int movesBeforeDrop = Console.WindowWidth - 40;
        public static int currentMoves = 0;
        public static int tick = 0;
        public static void LancerEn()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    Enemie en = new Enemie();
                    if (j % 2 == 0)
                    {
                        en.skin = "-0_0-";
                    }
                    else
                    {
                        en.skin = ">-_-<";
                    }

                    en.y = j * 2;
                    en.x = i * 8;
                    en.MoveRight();

                    enemies.Add(en);
                }
            }
            direction = 1; // 1 pour droite, -1 pour gauche
            movesBeforeDrop = Console.WindowWidth - 40;
            currentMoves = 0;
            tick = 0;
        }


       

        public List<Tirs> TirsEnemi { get => tirsEnemi; set => tirsEnemi = value; }
      
        
        public void moove()
        {
            
            Random Tir_enemie = new Random();
            int tirus = Tir_enemie.Next(20);

            // Sélectionne un ennemi au hasard pour tirer
            Enemie randomEnemy = null;
            if (enemies.Count > 0)
            {
                randomEnemy = enemies[Tir_enemie.Next(enemies.Count)];
            }

            tick++;

            if (tick >= 20)
            {
                if (direction == 1)
                {
                    foreach (var en in enemies)
                    {
                        en.MoveRight();
                    }
                }
                else if (direction == -1)
                {
                    foreach (var en in enemies)
                    {
                        en.MoveLeft();
                    }
                }
               


                tick = 0;
                currentMoves++;
            }
            foreach (var enemyToRemove in Enemie.enemiesToRemove)
            {
              
                
                Enemie.enemies.Remove(enemyToRemove);
            }
            Enemie.enemiesToRemove.Clear();  // Videz la liste temporaire

            if (tirus == 19 && randomEnemy != null)
            {
                try
                {
                    Tirs tirer = new Tirs { titre = false, Y = randomEnemy.y, X = randomEnemy.x };
                    TirsEnemi.Add(tirer);
                }
                catch
                {
                    // Gérer l'exception si nécessaire
                }
            }
            

            for (int i = 0; i < TirsEnemi.Count; i++)
            {
                TirsEnemi[i].Tir();

                // Si le tir est hors de l'écran, supprimez-le de la liste
                if (TirsEnemi[i].Y >= Console.WindowHeight)
                {
                    Console.SetCursorPosition(TirsEnemi[i].X - 1, TirsEnemi[i].Y);
                    Console.Write("    ");
                    TirsEnemi.RemoveAt(i);
                    i--; // Ajustez l'index après avoir supprimé un élément
                }
            }
            

            for (int i = 0; i < TirsEnemi.Count; i++)
            {
                Tirs t = TirsEnemi[i];
                Joueur currentPlayer = Joueur.CurrentPlayer;

                
                bool hit = false;

                // Vérifiez chaque ligne du design du joueur
                for (int j = 0; j < Joueur.playerDesign.Length && !hit; j++)
                {
                    // Vérifiez chaque caractère de la ligne
                    for (int k = 0; k < Joueur.playerDesign[j].Length; k++)
                    {
                        if (t.Y == currentPlayer.y + j && t.X == currentPlayer.x + k && Joueur.playerDesign[j][k] != ' ')
                        {
                            hit = true;
                            break;
                        }
                    }
                }

                if (hit)
                {
                    jouLife--;  // Diminuez la vie du joueur. Notez que nous utilisons 'currentPlayer.jouLife' ici.

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(jouLife);  // Affichez la vie du joueur en utilisant 'currentPlayer.jouLife'.

                    TirsEnemi.RemoveAt(i);
                    i--;
                    Console.SetCursorPosition(t.X, t.Y);
                    Console.Write(" ");
                }
            }

            if (currentMoves >= movesBeforeDrop)
            {
                foreach (var en in enemies)
                {
                    if (direction == 1)
                    {
                        en.ClearPositionRight();
                    }
                    else
                    {
                        en.ClearPositionLeft();
                    }
                    en.y++;
                }

                direction = -direction;
                currentMoves = 0;
            }
        }

    }
}



