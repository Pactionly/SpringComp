using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] counts = new int[1001];
            int.TryParse(Console.ReadLine(), out int size);
            string line = Console.ReadLine();
            string[] data = line.Split();
            int temp;
            for(int i = 0; i < size; i++)
            {
                int.TryParse(data[i], out temp);
                counts[temp]++;
            }
            int max = 0;
            for(int i = 1; i < 1001; i++)
            {
                max = counts[max] >= counts[i] ? max : i;
            }
            Console.WriteLine(max);
        }
    }
}
