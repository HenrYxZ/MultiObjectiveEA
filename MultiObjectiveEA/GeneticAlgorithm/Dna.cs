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

        public Fitness Fitness
        {
            get 
            {   if(fitness == null)
                {
                    double totalDistance = 0;
                    double totalDanger = 0;
                    foreach (Edge edge in edges)
                    {
                        totalDanger -= edge.Danger;
                        totalDistance -= edge.Distance;
                    }
                    this.fitness = new Fitness(totalDistance, totalDanger);
                }
                return fitness; 
            }
            set { fitness = value; }
        }

        public Dna()
        {
            int numberOfCities = 20;
            edges = new List<Edge>(numberOfCities);
            setRandomEdges(numberOfCities);
        }

        public Dna(int stringLength)
        {
            int numberOfCities = stringLength;
            edges = new List<Edge>(numberOfCities);
            setRandomEdges(numberOfCities);
        }

        public void mutate()
        {

        }

        private void setRandomEdges(int numberOfCities)
        {
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


            this.edges[0] = new Edge(shuffledCities[0], shuffledCities[1]);

            for (int i = 1; i < numberOfCities; i++)
            {
                int city = chooseRandomCity(cities, r);
                if (i == numberOfCities - 1)
                    edges[i] = new Edge(city, 1);
                else
                    edges[i] = new Edge(edges[i - 1].Vertices[1], city);
            }
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
        public double distance;
        public double danger;

        public Fitness(double dist, double dang)
        {
            distance = dist;
            danger = dang;
        }
    }

}
