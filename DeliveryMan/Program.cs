using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            string[] values = data.Split();
            int numberOfVertex, numberOfEdge;
            int.TryParse(values[0], out numberOfVertex);
            int.TryParse(values[1], out numberOfEdge);
            long[,] dist = new long[numberOfVertex, numberOfVertex];
            for(int i = 0; i < numberOfVertex; i++)
            {
                for(int j = 0; j < numberOfVertex; j++)
                {
                    if(i == j)
                    {
                        dist[i, j] = 0;
                    }
                    else
                    {
                        dist[i, j] = int.MaxValue;
                    }
                }
            }
            int from;
            int to;
            int weight;
            for(int i = 0; i < numberOfEdge; i++)
            {
                data = Console.ReadLine();
                values = data.Split();
                int.TryParse(values[0], out from);
                int.TryParse(values[1], out to);
                int.TryParse(values[2], out weight);
                dist[from - 1, to - 1] = weight;
            }

            for(int k = 0; k < numberOfVertex; k++)
            {
                for(int i = 0; i < numberOfVertex; i++)
                {
                    for(int j = 0; j < numberOfVertex; j++)
                    {
                        if(dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }
            int numberOfPaths;
            int.TryParse(Console.ReadLine(), out numberOfPaths);
            for(int i = 0; i < numberOfPaths; i++)
            {
                data = Console.ReadLine();
                values = data.Split();
                int.TryParse(values[0], out from);
                int.TryParse(values[1], out to);
                from--;
                to--;
                if(dist[from, to] == int.MaxValue)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(dist[from, to]);
                }
            }
        }
    }
}
