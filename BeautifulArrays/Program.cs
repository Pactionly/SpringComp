using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            int.TryParse(Console.ReadLine(), out size);
            string a = Console.ReadLine();
            string[] list = a.Split();
            Tuple<int, int>[] array = new Tuple<int, int>[size];
            int temp;
            for(int i = 0; i < size; i++)
            {
                int.TryParse(list[i], out temp);
                array[i] = new Tuple<int, int>(temp, i);
            }
            Array.Sort(array);
            int ans = countSwaps(array);
            Array.Reverse(array);
            int revAns = countSwaps(array);
            ans = ans < revAns ? ans : revAns;
            Console.WriteLine(ans);
        }
        static int countSwaps(Tuple<int,int>[] array)
        {
            bool[] visited = new bool[array.Length];
            int count = 0;
            int next;
            for(int i = 0; i < array.Length; i++)
            {
                visited[i] = true;
                next = array[i].Item2;
                while(!visited[next])
                {
                    count++;
                    visited[next] = true;
                    next = array[next].Item2;
                }
            }
            return count;
        }
    }
}
