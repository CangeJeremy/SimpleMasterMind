using SimpleMasterMind.Classes;

namespace SimpleMasterMind
{
    internal class Program
    {
        private static bool _isDebug = true;

        static void Main()
        {
            MasterMind masterMind = new MasterMind();
            masterMind.Game();

            if(_isDebug)
            {
                masterMind.Debug();
            }
        }
    }
}