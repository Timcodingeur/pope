namespace enemie
{
  


    public class Tirs
    {

        public bool top=true;
        public bool titre = false;
        string skin = "|";
        public int X; 
        public int Y; 

        public void Tir()
        {
            Joueur oui = new Joueur();
            if (titre == false)
            {
                if (Y < Console.WindowHeight - 1)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(" ");

                    Y++;  // Déplace le tirs vers le bas

                    Console.SetCursorPosition(X, Y);
                    Console.Write(skin);
                    if(oui.x==X&&oui.y==Y)
                    {
                        Console.WriteLine("bob");
                    }
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(" ");
                }
            }else if (titre == true)
            {
                
                    Console.SetCursorPosition(X+2, Y);
                    Console.Write(" ");

                    Y--;  // Déplace le tirs vers le haut

                    Console.SetCursorPosition(X+2, Y);
                    Console.Write(skin);
                
                
            }
        }
        

    }
}


