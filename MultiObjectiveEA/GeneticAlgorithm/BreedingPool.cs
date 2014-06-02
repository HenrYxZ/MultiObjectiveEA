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
        public int Count { get {return elite.Count;}}

        public BreedingPool(int breedingSize)
        {
            elite = new List<Dna>(breedingSize);
        }

        public void add(DominanceRanking ranking)
        {
            foreach (DominanceLevel level in ranking.Levels)
            {
                foreach (Dna dna in level.Dnas)
                {
                    elite.Add(dna);
                }
            }
        }

        public Dna get(int index)
        {
            return elite[index];
        }

        public void removeAt(int index)
        {
            elite.RemoveAt(index);
        }
    }
}
