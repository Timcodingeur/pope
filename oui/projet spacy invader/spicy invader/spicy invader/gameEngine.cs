namespace enemie
{
    internal class gameEngine
    {
        Joueur jeux = new Joueur();
        Enemie enemie = new Enemie();
        int fpscal = 16;
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
                
            }
        }
    }
}
