using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class EvolutionaryAlgorithm
    {

        //        Attributes
        protected Parameters evoParams;
        protected Dna bestDna;
        protected Population population;
        protected BreedingPool breedingPool;
        protected Statistics stats;


        public Parameters EvoParams
        {
            get { return evoParams; }
            set { evoParams = value; }
        }

        public Dna BestDna
        {
            get { return bestDna; }
            set { bestDna = value; }
        }

        public Population Population
        {
            get { return population; }
            set { population = value; }
        }

        public BreedingPool BreedingPool
        {
            get { return breedingPool; }
            set { breedingPool = value; }
        }

        public Statistics Stats
        {
            get { return stats; }
            set { stats = value; }
        }



        //      Constructor
        public EvolutionaryAlgorithm(Parameters evoParams)
        {
            this.evoParams = evoParams;
            this.stats = new Statistics();

        }

        //      Methods
        public void populate()
        {
            Population = new Population(evoParams.pop);
        }

        public virtual void selection()
        {

        }

        public virtual void crossover()
        {

        }

        public virtual void mutation()
        {

        }

    }

    struct Parameters
    {
        public int gen, pop;
        public double xover, mut;
        public Parameters(int g, int p, double x, double m)
        {
            gen = g;
            pop = p;
            xover = x;
            mut = m;
        }
    }

    struct Statistics
    {
        public double totalFitness;
        public double totalDistance;
        public double totalDanger;

        public Statistics()
        {
            totalFitness = 0;
            totalDistance = 0;
            totalDanger = 0;
        }

    }
}
