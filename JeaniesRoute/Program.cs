using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeaniesRoute
{
    class Edge
    {
        public int city;
        public int weight;

        public Edge(int city, int weight)
        {
            this.city = city;
            this.weight = weight;
        }
    }
    class City
    {
        public bool mustVisit;
        public List<Edge> adjList;

        public City()
        {
            mustVisit = false;
            adjList = new List<Edge>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] data = line.Split();
            int numberOfVertex, numberOfLetter;
            int.TryParse(data[0], out numberOfVertex);
            int.TryParse(data[1], out numberOfLetter);
            List<City> cities = new List<City>(numberOfVertex);
            for(int i = 0; i < numberOfVertex; i++)
            {
                cities.Add(new City());
            }
            line = Console.ReadLine();
            data = line.Split();
            int letterCity = 0;
            for(int i = 0; i < numberOfLetter; i++)
            {
                int.TryParse(data[i], out letterCity);
                letterCity--;
                cities[letterCity].mustVisit = true;
            }
            int from, to, weight;
            for(int i = 0; i < numberOfVertex - 1; i++)
            {
                line = Console.ReadLine();
                data = line.Split();
                int.TryParse(data[0], out from);
                int.TryParse(data[1], out to);
                int.TryParse(data[2], out weight);
                from--;
                to--;
                cities[from].adjList.Add(new Edge(to, weight));
                cities[to].adjList.Add(new Edge(from, weight));
            }
            CleanGraph(cities);
            int[] dist = new int[numberOfVertex];
            DFS(cities, new bool[numberOfVertex], letterCity, dist);
            int maxDist = 0;
            for(int i = 1; i < numberOfVertex; i++)
            {
                maxDist = dist[maxDist] > dist[i] ? maxDist : i;
            }
            dist = new int[numberOfVertex];
            DFS(cities, new bool[numberOfVertex], maxDist, dist);
            for (int i = 1; i < numberOfVertex; i++)
            {
                maxDist = dist[maxDist] > dist[i] ? maxDist : i;
            }
            int totalCost = -dist[maxDist];
            foreach(City c in cities)
            {
                foreach(Edge e in c.adjList)
                {
                    totalCost += e.weight;
                }
            }
            Console.WriteLine(totalCost);
        }
        static void DFS(List<City> cities, bool[] visited, int cur, int[] dist)
        {
            visited[cur] = true;
            int city;
            for (int i = 0; i < cities[cur].adjList.Count; i++)
            {
                city = cities[cur].adjList[i].city;
                if (!visited[city])
                {
                    dist[city] = dist[cur] + cities[cur].adjList[i].weight;
                    DFS(cities, visited, city, dist);
                }
            }
        }
        static void CondRemove(List<City> cities, int indexToRemove)
        {
            int adjCity;
            City toRemove = cities[indexToRemove];
            if (!toRemove.mustVisit)
            {
                if(toRemove.adjList.Count == 1)
                {
                    adjCity = toRemove.adjList[0].city;
                    cities[adjCity].adjList.RemoveAll(x => x.city == indexToRemove);
                    CondRemove(cities, adjCity);
                    toRemove.adjList.Clear();
                }
                else if(toRemove.adjList.Count == 2)
                {
                    int totalWeight = toRemove.adjList[0].weight + toRemove.adjList[1].weight;
                    adjCity = toRemove.adjList[0].city;
                    int adjCity2 = toRemove.adjList[1].city;
                    cities[adjCity].adjList.RemoveAll(x => x.city == indexToRemove);
                    cities[adjCity].adjList.Add(new Edge(adjCity2, totalWeight));
                    cities[adjCity2].adjList.RemoveAll(x => x.city == indexToRemove);
                    cities[adjCity2].adjList.Add(new Edge(adjCity, totalWeight));
                    toRemove.adjList.Clear();
                }
            }
        }
        static void CleanGraph(List<City> cities)
        {
            
            for (int i = 0; i < cities.Count; i++)
            {
                CondRemove(cities, i);
            }
        }
    }
}
