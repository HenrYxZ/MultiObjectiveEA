using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class DominanceRanking
    {
        List<DominanceLevel> levels;
        int currentGeneration;

        public int Count { get { int total = 0; foreach (DominanceLevel d in levels) total += d.Count; return total; } }

        public int CurrentGeneration
        {
            get { return currentGeneration; }
            set { currentGeneration = value; }
        }

        public List<DominanceLevel> Levels
        {
            get { return levels; }
            set { levels = value; }
        }

        public DominanceRanking(int alpha, int currentGen)
        {
            this.levels = new List<DominanceLevel>(alpha);
            this.currentGeneration = currentGen;
        }
    }
}
