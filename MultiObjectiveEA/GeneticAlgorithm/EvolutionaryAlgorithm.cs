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
        protected int currentGeneration;


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
        public virtual void populate()
        {
            this.population.generateDnas();
        }

        public virtual void select()
        {
            
        }

        public virtual void reproduce()
        {
            Population newPopulation = new Population(evoParams.pop);
            this.population = newPopulation;

            Random xover = new Random();
            // generates pairs of parents and their child
            // the last with the first

            //pairs
            Random index = new Random();
            List<DnaPair> Parents = new List<DnaPair>();
            int pos;
            while (Parents.Count < breedingPool.Count / 2)
            {
                pos = index.Next(breedingPool.Count);
                Dna x = breedingPool.get(pos);
                //breedingPool.removeAt(pos);

                pos = index.Next(breedingPool.Count);
                Dna y = breedingPool.get(pos);
                //breedingPool.removeAt(pos);

                DnaPair p = new DnaPair(x, y);
                Parents.Add(p);
            }

            foreach (DnaPair p in Parents)
            {
                if (xover.NextDouble() <= evoParams.xover)
                {
                    newPopulation.add(crossover(p.x, p.y));
                    newPopulation.add(crossover(p.y, p.x));
                    if (xover.Next(2) == 1)
                    {   // Copy parents
                        newPopulation.add(p.x);
                        newPopulation.add(p.y);
                    }
                    else
                    {   // Generate new dna's
                        Dna newDnaX = new Dna();
                        Dna newDnaY = new Dna();
                        newPopulation.add(newDnaX);
                        newPopulation.add(newDnaY);
                    }
                }
                else
                {
                    newPopulation.add(p.x);
                    newPopulation.add(p.y);
                    Dna newDnaX = new Dna();
                    Dna newDnaY = new Dna();
                    newPopulation.add(newDnaX);
                    newPopulation.add(newDnaY);
                }
            }

            while (newPopulation.Count > evoParams.pop)
                newPopulation.removeAt(0);
            population = newPopulation;
        }

        public virtual Dna crossover(Dna x, Dna y)
        {
            return null;
        }

        public void mutate()
        {
            for (int i = 0; i < population.Dnas.Count; i++)
            {
                mutate(population.Dnas[i]);
            }
        }

        public virtual void mutate(Dna dna)
        {

        }

        public virtual void run(int option)
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

    struct DnaPair
    {
        public Dna x;
        public Dna y;

        public DnaPair (Dna x1, Dna y1)
        {
            this.x = x1;
            this.y = y1;
        }
    }

}
