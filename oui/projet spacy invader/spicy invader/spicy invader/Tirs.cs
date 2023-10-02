namespace enemie
{
  


    public class Tirs
    {

        public bool top=true;
        public bool titre = false;
        string Skin = "|";
        public int X; 
        public int Y; 

        public void Tir()
        {


            if (titre == false)
            {
                //supp le tirs quand il est en haut de la console
                if (Y < Console.WindowHeight-1)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(" ");

                    Y++;  // Déplace le tirs vers le bas

                    Console.SetCursorPosition(X, Y);
                    Console.Write(Skin);
                    
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
                    Console.Write(Skin);
                
                
            }
        }
        

    }
}


