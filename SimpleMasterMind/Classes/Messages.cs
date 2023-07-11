using SimpleMasterMind.Enums;

namespace SimpleMasterMind.Classes
{
    internal class Messages
    {
        /// <summary>
        /// Displays the game rules to the player.
        /// </summary>
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

        /// <summary>
        /// Displays a message indicating that the computer is preparing its color combination.
        /// </summary>
        public void CPUThink()
        {
            Console.WriteLine("\r\nL'ordinateur prépare sa combinaison de couleurs...");
        }

        /// <summary>
        /// Displays a message indicating that the computer has generated a color combination and it's the player's turn.
        /// </summary>
        public void CPUFound()
        {
            Console.WriteLine("\r\nUne combinaison a été générée. C'est à vous de jouer !");
        }

        /// <summary>
        /// Asks the player to input a color.
        /// </summary>
        public void AskPlayerColor()
        {
            Console.WriteLine("\r\nVeuillez indiquer une couleur : ");
        }

        /// <summary>
        /// Displays a message indicating that the player has won the game.
        /// </summary>
        public void GameWin()
        {
            Console.WriteLine("\r\nFélicitations ! Vous avez gagné cette partie !");
        }

        /// <summary>
        /// Displays a message indicating that the player has lost the game.
        /// </summary>
        public void GameLose()
        {
            Console.WriteLine("\r\nDommage ! Vous n'avez pas gagné cette partie.");
        }

        /// <summary>
        /// Displays the number of remaining tries.
        /// </summary>
        /// <param name="arg">The number of remaining tries.</param>
        public void TryCount(int arg)
        {
            Console.WriteLine($"\r\nIl vous reste {arg} essais.");
        }

        /// <summary>
        /// Displays the number of correctly placed colors.
        /// </summary>
        /// <param name="arg">The number of correctly placed colors.</param>
        public void CorrectColor(int arg)
        {
            Console.WriteLine($"\r\nCouleurs au bon endroit : {arg}");
        }

        /// <summary>
        /// Displays the number of misplaced colors.
        /// </summary>
        /// <param name="arg">The number of misplaced colors.</param>
        public void MisplacedColor(int arg)
        {
            Console.WriteLine($"Couleurs au mauvais endroit : {arg}");
        }

        /// <summary>
        /// Displays the number of incorrect colors.
        /// </summary>
        /// <param name="arg">The number of incorrect colors.</param>
        public void IncorrectColor(int arg)
        {
            Console.WriteLine($"Mauvaises couleurs : {arg}");
        }
    }
}
