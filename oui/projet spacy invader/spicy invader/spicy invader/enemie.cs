namespace enemie
{



    public class Enemie
    {
        private List<Tirs> tirsEnemi = new List<Tirs>();
        public bool titre = false;
        ConsoleColor color = ConsoleColor.Gray;

        public int x = 0;
        public int y;

        public string skin = "-0_0-";

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
            if (skin == "-0_0-")
            {
                skin = "^0^0^";

            }
            else
                                   if (skin == "^0^0^")
            {
                skin = "-0_0-";

            }
            else if (skin == ">-_-<")
            {

                skin = ">^-^<";
            }
            else if (skin == ">^-^<")
            {
                skin = ">-_-<";
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
        public static Enemie[,] enemy = new Enemie[5, 4];
        public static void LancerEn()
        {
            

            
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    enemy[i, j] = new Enemie();
                    if (j % 2 == 0)
                    {
                        enemy[i, j].skin = "-0_0-";
                    }
                    else
                    {
                        enemy[i, j].skin = ">-_-<";
                    }

                    // Ajustez ces valeurs pour positionner vos ennemis
                    enemy[i, j].y = j * 2;
                    enemy[i, j].x = i * 8;
                    enemy[i, j].MoveRight();
                }
            }
           

        }
       
        public static int direction = 1; // 1 pour droite, -1 pour gauche
        public static int movesBeforeDrop = Console.WindowWidth-40;
        public static int currentMoves = 0;
        public static int tick = 0;
        
        public  void moove()
        {
            Random Tir_enemie = new Random();
            int tirus = Tir_enemie.Next(20);
            int ix = Tir_enemie.Next(0, 5);
            int iy = Tir_enemie.Next(0, 4);
            tick++;
            if (tick == 20)
            {
                if (direction == 1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (enemy[i, j] != null)
                            {
                                enemy[i, j].MoveRight();
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
                else if (direction == -1)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (enemy[i, j] != null)
                            {
                                enemy[i, j].MoveLeft();
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
                currentMoves++;
                tick = 0;
            }
           if(tirus==19)
            {
                try
                {
                    Tirs tirer = new Tirs { titre = false, Y = enemy[ix, iy].y, X = enemy[ix, iy].x };
                    tirsEnemi.Add(tirer);
                    
                }
                catch
                {

                }
            }
            for (int i = 0; i < tirsEnemi.Count; i++)
            {
                tirsEnemi[i].Tir();

                // Si le tir est hors de l'écran, supprimez-le de la liste
                if (tirsEnemi[i].Y >= Console.WindowHeight)
                {
                    Console.SetCursorPosition(tirsEnemi[i].X-1, tirsEnemi[i].Y);
                    Console.Write("    ");
                    tirsEnemi.RemoveAt(i);
                    i--; // Ajustez l'index après avoir supprimé un élément

                }
            }
            
            if (currentMoves >= movesBeforeDrop)
            {
                if (direction == 1)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            enemy[i, x].ClearPositionRight();



                            enemy[i, x].y++;
                        }
                    }
                }

                else if (direction == -1)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int i = 0; i < 5; i++)
                        {



                            enemy[i, x].ClearPositionLeft();
                            enemy[i, x].y++;
                        }
                    }
                }
                direction = -direction;
                currentMoves = 0;

            }
            
        }
    }
}



