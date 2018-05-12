using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingValleys
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            int.TryParse(Console.ReadLine(), out length);
            string path = Console.ReadLine();
            int height = 0;
            int valleyCount = 0;
            for (int i = 0; i < length; i++)
            {
                if (path[i] == 'U')
                {
                    height++;
                    if(height == 0)
                    {
                        valleyCount++;
                    }
                }
                else
                {
                    height--;
                }
            }
            Console.WriteLine(valleyCount);
        }
    }
}
