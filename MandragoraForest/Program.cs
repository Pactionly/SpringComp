using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandragoraForest
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int tests);
            for(int t = 0; t < tests; t++)
            {
                int.TryParse(Console.ReadLine(), out int size);
                string line = Console.ReadLine();
                string[] data = line.Split();
                long[] health = new long[size];
                for(int i = 0; i < size; i++)
                {
                    long.TryParse(data[i], out health[i]);
                }
                Array.Sort(health);
                long totalRemaining = health.Sum();
                int index = 0;
                long max = 0;
                long temp;
                while(true)
                {
                    temp = (index + 1) * totalRemaining;
                    if (temp > max)
                    {
                        max = temp;
                    }
                    else
                    {
                        break;
                    }
                    totalRemaining -= health[index];
                    index++;
                }
                Console.WriteLine(max);
            }
        }
    }
}
