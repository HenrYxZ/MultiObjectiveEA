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

        public Population(int popSize)
        {
            dnas = new List<Dna>(popSize);
            stats = new Statistics();
        }

        public void generateDnas()
        {
            for (int i = 0; i < dnas.Capacity; i++)
            {
                
                dnas.Add(new Dna());
            }
        }

        public void evaluate(int[][] distances, int[][] dangers)
        {

            // evaluates every Dna, sets the stats for this population and returns the bestDna found
            for (int i = 0; i < dnas.Count; i++)
			{
                dnas[i].evaluate(distances, dangers);
                this.stats.total.danger += dnas[i].Fitness.danger;
                this.stats.total.distance += dnas[i].Fitness.distance;
                this.stats.total.fitness += dnas[i].Fitness.total;
                if (this.stats.min.distance > dnas[i].Fitness.distance)
                    this.stats.min.distance = dnas[i].Fitness.distance;
                if (this.stats.min.danger > dnas[i].Fitness.danger)
                    this.stats.min.danger = dnas[i].Fitness.danger;
                if (this.stats.max.distance < dnas[i].Fitness.distance)
                    this.stats.max.distance = dnas[i].Fitness.distance;
                if (this.stats.max.danger < dnas[i].Fitness.danger)
                    this.stats.max.danger = dnas[i].Fitness.danger;
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
