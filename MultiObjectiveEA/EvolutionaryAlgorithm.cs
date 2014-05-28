using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class EvolutionaryAlgorithm
    {

        //Attributes
        protected int populationSize;
        protected int generations;
        protected float xover;
        protected float mutation;
        protected int alfa;
        protected Dna bestDna;
        protected Population population;
        protected BreedingPool breedingPool;

        public EvolutionaryAlgorithm()
        {

        }

        //Methods
        public void populate()
        {

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
}
