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

        public List<DominanceLevel> Levels
        {
            get { return levels; }
            set { levels = value; }
        }

        public DominanceRanking(int alpha)
        {
            this.levels = new List<DominanceLevel>(alpha);
        }
    }
}
