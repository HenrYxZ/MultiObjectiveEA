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



        //      Constructor
        public EvolutionaryAlgorithm(Parameters evoParams)
        {
            this.evoParams = evoParams;

        }

        //      Methods
        public void populate()
        {
            Population = new Population(evoParams.pop);
        }

        public virtual void selection()
        {
            population.evaluate();
        }

        public virtual void crossover()
        {

        }

        public virtual void mutation()
        {

        }

    }

    public struct Parameters
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

}
