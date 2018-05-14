using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] data = line.Split();
            int.TryParse(data[0], out int size);
            int.TryParse(data[1], out int swaps);
            line = Console.ReadLine();
            data = line.Split();
            Console.Write(size);
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp;
            int.TryParse(data[0], out temp);
            if (temp != size)
            {
                swaps--;
                dict[size] = temp;
            }
            for (int i = 1; i < size; i++)
            {
                int.TryParse(data[i], out temp);
                while (dict.ContainsKey(temp))
                {
                    temp = dict[temp];
                }
                if (swaps > 0 && temp != size - i)
                {
                    swaps--;
                    dict[size - i] = temp;
                    temp = size - i;
                }
                Console.Write(" " + temp);
            }
            Console.WriteLine();
        }
    }
}
