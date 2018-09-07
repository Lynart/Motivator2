using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Motivator2
{
    class Program
    {
        static int MAX_TICKS = 21;
        static string WIN = "Buy Monster Hunter Generation Ultimate and a Switch NOW!";
        static string TICKING = "Leveling up...";
        static string TICKED = "Believe in the you from yesterday who believes in you today!";
        static void Main(string[] args)
        {
            Stats stats = new Stats();
            stats.Load();
            int ticks = stats.GetProgress();

            DisplayProgressBar(ticks, MAX_TICKS);

            stats.Save();

            Console.ReadKey();
        }

        private static void DisplayProgressBar(int ticks, int maxTicks)
        {
            var options = new ProgressBarOptions
            {
                ForegroundColor = ConsoleColor.Red,
                ForegroundColorDone = ConsoleColor.White,
                BackgroundColor = ConsoleColor.DarkGray,
                BackgroundCharacter = '\u2593'
            };
            using (var pbar = new ProgressBar(maxTicks, "", options))
            {
                for (int i = 1; i <= ticks; i++)
                {
                    if (i != ticks)
                        pbar.Tick(TICKING);
                    else if (i == ticks)
                        pbar.Tick(TICKED);
                    else if (i == MAX_TICKS)
                        pbar.Tick(WIN);
                    Thread.Sleep(500);
                }
            }
        }
    }
}
