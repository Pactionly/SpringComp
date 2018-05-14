using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumLoss
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int size);
            string line = Console.ReadLine();
            string[] data = line.Split();
            Tuple<long, int>[] prices = new Tuple<long, int>[size];
            long temp;
            for(int i = 0; i < size; i++)
            {
                long.TryParse(data[i], out temp);
                prices[i] = new Tuple<long, int>(temp, i);
            }
            Array.Sort(prices);
            long minLoss = long.MaxValue;
            for(int i = size - 1; i > 0; i--)
            {
                temp = prices[i].Item1 - prices[i - 1].Item1;
                if (temp > 0 && prices[i].Item2 < prices[i - 1].Item2)
                {
                    minLoss = minLoss < temp ? minLoss : temp;
                }
            }
            Console.WriteLine(minLoss);
        }
    }
}
