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

        public List<Dna> Dnas
        {
            get { return dnas; }
            set { dnas = value; }
        }
        

        public DominanceLevel(int lvl)
        {
            this.level = lvl;
        }

        public void add(Dna dna)
        {
            dnas.Add(dna);
        }

        public override string ToString()
        {
            String answer = "Dominance Level " + level + ": \n\n";
            foreach (Dna d in dnas)
            {
                answer += d.ToString();
            }

            return answer;
        }
    }
}
