using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Population
    {
        List<Dna> dnas;
        Statistics stats;
        // Won't use the best Dna
        int bestDnaIndex;
        int[][] dangers;
        int[][] distances;
        int generationNumber;

        public int GenerationNumber
        {
            get { return generationNumber; }
            set { generationNumber = value; }
        }

        public int[][] Dangers
        {
            get { return dangers; }
            set { dangers = value; }
        }

        public int[][] Distances
        {
            get { return distances; }
            set { distances = value; }
        }

        public List<Dna> Dnas
        {
            get { return dnas; }
            set { dnas = value; }
        }

        public Statistics Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public int Count { get { return dnas.Count; } }

        public Population(int popSize, bool empty)
        {
            dnas = new List<Dna>(popSize);
            int numberOfCities = 20;
            stats = new Statistics();
            if (empty) return;

            for(int i=0; i < popSize; i++)
            {
                    dnas[i] = new Dna();
                    setRandomEdges(numberOfCities, dnas[i]);
            }

            
        }

        public Population(Population original)
        {
            this.dnas = new List<Dna>(original.Dnas);
            this.stats = original.Stats;
            this.bestDnaIndex = original.bestDnaIndex;
            // If the original population hasn't be evaluated we evaluate the new one
            if(this.stats.total.distance == 0)
            {
                evaluate();
            }
            
        }

        public void evaluate()
        {

            // evaluates every Dna, sets the stats for this population and returns the bestDna found
            foreach(Dna dna in this.dnas)
            {
                this.stats.total.danger += dna.Fitness.danger;
                this.stats.total.distance += dna.Fitness.distance;
                this.stats.total.fitness += dna.Fitness.total;
                if (this.stats.min.distance > dna.Fitness.distance)
                    this.stats.min.distance = dna.Fitness.distance;
                if (this.stats.min.danger > dna.Fitness.danger)
                    this.stats.min.danger = dna.Fitness.danger;
                if (this.stats.max.distance < dna.Fitness.distance)
                    this.stats.max.distance = dna.Fitness.distance;
                if (this.stats.max.danger < dna.Fitness.danger)
                    this.stats.max.danger = dna.Fitness.danger;
            }
        }

        public Dna bestDna()
        {
            return dnas[bestDnaIndex];
        }

        public void add(Dna d)
        {
            this.dnas.Add(d);
        }

        public void removeAt(int index)
        {
            this.dnas.RemoveAt(index);
        }

        public void setRandomEdges(int numberOfCities, Dna dna)
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


            dna.Edges.Add(getEdge(shuffledCities[0], shuffledCities[1]));

            for (int i = 1; i < numberOfCities; i++)
            {
                int city = chooseRandomCity(cities, r);
                if (i == numberOfCities - 1)
                    dna.Edges.Add(getEdge(city, 1));
                else
                    getEdge(dna.Edges[i - 1].Vertices[1], city);
            }
        }

        public Edge getEdge(int p1, int p2)
        {
            int distance, danger;
            if(p1 < p2)
            {
                distance = distances[p1][p2];
                danger = dangers[p1][p2];
            }
            else
            {
                distance = distances[p2][p1];
                danger = dangers[p2][p1];
            }
            return new Edge(new int[2] { p1, p2 }, distance, danger);
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

    struct Min
    {
        public int distance;
        public int danger;
    }

    struct Max
    {
        public int distance;
        public int danger;
    }

    struct Total
    {
        public int distance;
        public int danger;
        public int fitness;
    }

    struct Statistics
    {
        public Min min;
        public Max max;
        public Total total;
    }
}
