using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motivator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stats stats = new Stats();
            stats.Load();
            Console.WriteLine(stats.GetProgress());
            stats.Save();

            Console.ReadLine();
        }
    }
}
