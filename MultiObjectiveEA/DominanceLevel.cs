using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class DominanceLevel
    {
        List<Dna> dnas;
        int level;

        public DominanceLevel()
        {

        }

        public void add(Dna dna)
        {
            dnas.Add(dna);
        }
    }
}
