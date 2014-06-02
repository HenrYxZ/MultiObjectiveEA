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
        int bestDnaIndex;

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

        public Population(int popSize)
        {
            dnas = new List<Dna>(popSize);
            for(int i=0; i < popSize; i++)
            {
                dnas[i] = new Dna();
            }

            stats = new Statistics();
        }

        public Population(Population original)
        {
            this.dnas = new List<Dna>(original.Dnas);
            this.stats = original.Stats;
            this.bestDnaIndex = original.bestDnaIndex;
            // If the original population hasn't be evaluated we evaluate the new one
            if(this.stats.totalDistance == 0)
            {
                evaluate();
            }
            
        }

        public void evaluate()
        {

            // evaluates every Dna, sets the stats for this population and returns the bestDna found
            foreach(Dna dna in this.dnas)
            {
                this.stats.totalDanger += dna.Fitness.danger;
                this.stats.totalDistance += dna.Fitness.distance;
                this.stats.totalFitness += dna.Fitness.total;
                if (this.stats.minDistance > dna.Fitness.distance)
                    this.stats.minDistance = dna.Fitness.distance;
                if (this.stats.minDanger > dna.Fitness.danger)
                    this.stats.minDanger = dna.Fitness.danger;
                if (this.stats.maxDistance < dna.Fitness.distance)
                    this.stats.maxDistance = dna.Fitness.distance;
                if (this.stats.maxDanger < dna.Fitness.danger)
                    this.stats.maxDanger = dna.Fitness.danger;
            }
        }

        public Dna bestDna()
        {
            return dnas[bestDnaIndex];
        }
    }



    struct Statistics
    {
        public double totalFitness;
        public double totalDistance;
        public double totalDanger;
        public int minDistance;
        public int minDanger;
        public int maxDanger;
        public int maxDistance;

        public Statistics()
        {
            totalFitness = 0;
            totalDistance = 0;
            totalDanger = 0;
            minDistance = 100000;
            minDanger = 100000;
            maxDistance = 0;
            maxDanger = 0;
        }


        
    }
}
