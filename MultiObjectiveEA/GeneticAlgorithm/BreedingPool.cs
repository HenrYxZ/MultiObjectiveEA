using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class BreedingPool
    {
        List<Dna> elite;

        public BreedingPool(int breedingSize)
        {
            elite = new List<Dna>(breedingSize);
        }
    }
}
