using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Dna
    {
        List<Edge> edges;
        Fitness fitness;

        public List<Edge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        public Fitness Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }

        public Dna()
        {
            int numberOfCities = 20;
            edges = new List<Edge>(numberOfCities);
            generateEdges();
        }

        public Dna(int stringLength)
        {
            int numberOfCities = stringLength;
            edges = new List<Edge>(numberOfCities);
            generateEdges();
        }

        public void mutate()
        {
            // TODO: Mutate Dna
        }

        public void evaluate(int[][] dists, int[][] dangs)
        {
            int totalDistance = 0;
            int totalDanger = 0;
            foreach (Edge edge in edges)
            {
                int danger;  
                int distance;

                if(edge.Vertices[0] < edge.Vertices[1])
                {
                    distance = dists[edge.Vertices[0]-1][edge.Vertices[1]-1];
                    danger = dangs[edge.Vertices[0]-1][edge.Vertices[1]-1];
                }

                else
                {
                    distance = dists[edge.Vertices[1]-1][edge.Vertices[0]-1];
                    danger = dangs[edge.Vertices[1]-1][edge.Vertices[0]-1];
                }

                totalDanger -= danger;
                totalDistance -= distance;
            }
            this.fitness = new Fitness(totalDistance, totalDanger);
        }

        public override string ToString()
        {
            String answer = "DNA: \n";
            for (int i = 0; i < edges.Count; i++)
            {
                answer += edges.ToString();
            }
            answer += "\n";
            answer += "total distance = " + Fitness.distance * -1;
            answer += "\n";
            answer += "total danger = " + Fitness.danger * -1;
            answer += "\n";
            return answer;
        }
          

        private void generateEdges()
        {
            int numberOfCities = 20;
            List<int> cities = new List<int>();
            for (int i = 0; i < numberOfCities; i++)
            {
                cities.Add(i + 1);
            }
            /* shuffledCities is a list for the random order of the travel, for example
             [3 4 1 5 9 2 6 8 7] means c3 -> c4 -> c1 ... -> c7 */
            int[] shuffledCities = new int[numberOfCities];
            Random r = new Random();

            shuffledCities[0] = chooseRandomCity(cities, r);
            shuffledCities[1] = chooseRandomCity(cities, r);


            edges.Add(new Edge(shuffledCities[0], shuffledCities[1]));

            for (int i = 1; i < numberOfCities - 1; i++)
            {
                int city = chooseRandomCity(cities, r);
                edges.Add(new Edge(edges[i - 1].Vertices[1], city));
            }
            edges.Add(new Edge(edges[edges.Count - 1].Vertices[1], shuffledCities[0]));
        }

        private int chooseRandomCity(List<int> cities, Random r)
        {
            // Gets a random city and removes it from the list
            int index = r.Next(cities.Count);
            int city = cities[index];
            cities.RemoveAt(index);
            return city;
        }
    }

    public class Fitness 
    {
        public int distance;
        public int danger;
        public int total;

        public Fitness(int dist, int dang)
        {
            distance = dist;
            danger = dang;
            // TODO: Normalized fitness!
            total = dist + dang;
        }
    }

}
