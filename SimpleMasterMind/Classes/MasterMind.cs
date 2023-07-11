using SimpleMasterMind.Enums;

namespace SimpleMasterMind.Classes
{
    internal class MasterMind
    {
        private readonly Messages gameMessages = new Messages();
        private readonly Random random = new Random();

        private int _playerMaxTry = 10;
        private Colors[]? _cpuCombination;
        private Colors[]? _playerCombination;
        private bool[]? _checkedPositions;
        private bool _gameWon;

        /// <summary>
        /// Starts the MasterMind game.
        /// </summary>
        public void Game()
        {
            gameMessages.GameRules();
            AskPlayerReady();
            AskPlayerCombination();
        }

        /// <summary>
        /// Asks the player if they are ready to play the game.
        /// </summary>
        private void AskPlayerReady()
        {
            char _playerReady = Console.ReadLine()[0];

            if (_playerReady == 'Y' || _playerReady == 'y')
            {
                SetCombination();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Sets the color combination for the CPU.
        /// </summary>
        private void SetCombination()
        {
            _cpuCombination = new Colors[4];
            _playerCombination = new Colors[_cpuCombination.Length];
            _checkedPositions = new bool[_cpuCombination.Length];

            gameMessages.CPUThink();

            for (int i = 0; i < _cpuCombination.Length; i++)
            {
                _cpuCombination[i] = Enum.GetValues<Colors>()[random.Next(_cpuCombination.Length)];
            }

            gameMessages.CPUFound();
        }

        /// <summary>
        /// Asks the player for their color combination and checks it against the CPU combination.
        /// </summary>
        private void AskPlayerCombination()
        {
            while (_playerMaxTry > 0)
            {
                int _playerTimeAsked = 0;

                if (!_gameWon)
                {
                    _checkedPositions = new bool[_cpuCombination.Length];

                    while (_playerTimeAsked < _playerCombination.Length)
                    {
                        gameMessages.AskPlayerColor();

                        string _playerInput = Console.ReadLine();
                        _playerInput = _playerInput.ToLower();

                        foreach (string colorName in Enum.GetNames(typeof(Colors)))
                        {
                            if (colorName.ToLower() == _playerInput)
                            {
                                if (Enum.TryParse(colorName, true, out Colors color))
                                {
                                    _playerCombination[_playerTimeAsked] = color;
                                    _playerTimeAsked++;
                                    break;
                                }
                            }
                        }
                    }
                    TryPlayerCombination();
                }
                else
                {
                    EndGame(true);
                }
            }
            EndGame(false);
        }

        /// <summary>
        /// Checks the player's color combination against the CPU combination and provides feedback.
        /// </summary>
        private void TryPlayerCombination()
        {
            int _correctColors = 0;
            int _misplacedColors = 0;

            for (int i = 0; i < _playerCombination.Length; i++)
            {
                if (_playerCombination[i] == _cpuCombination[i])
                {
                    _correctColors++;
                    _checkedPositions[i] = true;
                }
            }

            for (int i = 0; i < _playerCombination.Length; i++)
            {
                if (!_checkedPositions[i])
                {
                    for (int j = 0; j < _cpuCombination.Length; j++)
                    {
                        if (_playerCombination[i] == _cpuCombination[j] && !_checkedPositions[j])
                        {
                            _misplacedColors++;
                            _checkedPositions[j] = true;
                            break;
                        }
                    }
                }
            }

            int _incorrectColors = _cpuCombination.Length - _correctColors - _misplacedColors;

            if (_correctColors == _cpuCombination.Length && _misplacedColors == 0)
            {
                _gameWon = true;
            }

            if (_playerMaxTry > 0 && _correctColors != _cpuCombination.Length || _misplacedColors != 0)
            {
                _playerMaxTry--;
                gameMessages.TryCount(_playerMaxTry);
                gameMessages.CorrectColor(_correctColors);
                gameMessages.MisplacedColor(_misplacedColors);
                gameMessages.IncorrectColor(_incorrectColors);
            }
        }

        /// <summary>
        /// Ends the game and displays the appropriate message based on the status.
        /// </summary>
        /// <param name="status">The status of the game.</param>
        private void EndGame(bool status)
        {
            if (status)
            {
                gameMessages.GameWin();
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                gameMessages.GameLose();
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}