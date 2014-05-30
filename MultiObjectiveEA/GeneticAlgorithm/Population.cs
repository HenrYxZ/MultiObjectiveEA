using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Population
    {
        List<Dna> population;

        public Population(int popSize)
        {
            population = new List<Dna>(popSize);
            for(int i=0; i < popSize; i++)
            {
                population[i] = new Dna();
            }
        }
    }
}
