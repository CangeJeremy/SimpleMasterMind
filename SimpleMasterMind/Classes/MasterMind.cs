using SimpleMasterMind.Enums;

namespace SimpleMasterMind.Classes
{
    internal class MasterMind
    {
        Messages gameMessages = new Messages();
        Random random = new Random();

        private int _playerMaxTry = 10;
        private int _playerTimeAsked;
        private int _correctColors;
        private int _misplacedColors;
        private int _incorrectColors;
        private char _playerReady;
        private string? _playerInput;
        private Colors[]? _cpuCombination;
        private Colors[]? _playerCombination;
        private bool[]? _checkedPositions;
        private bool _gameWon;

        public void Game()
        {
            gameMessages.GameRules();
            AskPlayerReady();
            AskPlayerCombination();
        }

        private void AskPlayerReady()
        {
            _playerReady = Console.ReadLine()[0];

            if (_playerReady == 'Y' || _playerReady == 'y')
            {
                SetCombination();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void SetCombination()
        {
            _cpuCombination = new Colors[4];
            _playerCombination = new Colors[_cpuCombination.Length];
            _checkedPositions = new bool[_cpuCombination.Length];

            gameMessages.CPUThink();

            for(int i = 0; i < _cpuCombination.Length; i++)
            {
                _cpuCombination[i] = Enum.GetValues<Colors>()[random.Next(_cpuCombination.Length)];
            }

            gameMessages.CPUFound();
        }

        private void AskPlayerCombination()
        {
            while (_playerMaxTry > 0)
            {
                _playerTimeAsked = 0;

                if(!_gameWon)
                {
                    _checkedPositions = new bool[_cpuCombination.Length];

                    while (_playerTimeAsked < _playerCombination.Length)
                    {
                        gameMessages.AskPlayerColor();

                        _playerInput = Console.ReadLine();
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

        private void TryPlayerCombination()
        {
            _correctColors = 0;
            _misplacedColors = 0;
            _incorrectColors = 0;

            for (int i = 0; i < _playerCombination.Length; i++)
            {
                if (_playerCombination[i] == _cpuCombination[i])
                {
                    _correctColors++;
                    _checkedPositions[i] = true;
                }
            }

            for(int i = 0; i < _playerCombination.Length ; i++)
            {
                if (!_checkedPositions[i])
                {
                    for(int j = 0; j < _cpuCombination.Length; j++)
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

            _incorrectColors = _cpuCombination.Length - _correctColors - _misplacedColors;

            if( _correctColors == _cpuCombination.Length && _misplacedColors == 0)
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

        private void EndGame(bool status)
        {
            if(status)
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

        public void Debug()
        {
            foreach(Colors colors in _cpuCombination)
            {
                Console.WriteLine(colors.ToString());
            }
        }
    }
}
