using SimpleMasterMind.Enums;

namespace SimpleMasterMind.Classes
{
    internal class Messages
    {
        public void GameRules()
        {
            Console.WriteLine("Bienvenue dans le MasterMind !");
            Console.WriteLine("Vous avez 12 tentatives pour trouver la combinaison gagnante.");
            Console.WriteLine("A chaque erreur, une tentative vous sera retirée.");
            Console.WriteLine("Pour participer, indiquez simplement la combinaison de couleurs que vous souhaitez utiliser.");
            Console.WriteLine("Les couleurs disponibles sont les suivantes : \r\n");

            foreach (Colors color in Enum.GetValues<Colors>())
            {
                Console.WriteLine(color);
            }

            Console.WriteLine("\r\nEst-ce que vous êtes prêt(e) à jouer ? Indiquez Y si c'est le cas, sinon indiquez N");
            
        }

        public void CPUThink()
        {
            Console.WriteLine("\r\nL'ordinateur prépare sa combinaison de couleurs...");
        }

        public void CPUFound()
        {
            Console.WriteLine("\r\nUne combinaison a été générée. C'est à vous de jouer !");
        }

        public void AskPlayerColor()
        {
            Console.WriteLine("\r\nVeuillez indiquer une couleur : ");
        }

        public void GameWin()
        {
            Console.WriteLine("\r\nFélicitations ! Vous avez gagné cette partie !");
        }

        public void GameLose()
        {
            Console.WriteLine("\r\nDommage ! Vous n'avez pas gagné cette partie.");
        }

        public void TryCount(int arg)
        {
            Console.WriteLine($"\r\nIl vous reste {arg} essais.");
        }

        public void CorrectColor(int arg)
        {
            Console.WriteLine($"\r\nCouleurs au bon endroit : {arg}");
        }

        public void MisplacedColor(int arg)
        {
            Console.WriteLine($"Couleurs au mauvais endroit : {arg}");
        }

        public void IncorrectColor(int arg)
        {
            Console.WriteLine($"Mauvaises couleurs : {arg}");
        }
    }
}
