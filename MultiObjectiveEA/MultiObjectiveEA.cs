using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class MultiObjectiveEA : EvolutionaryAlgorithm
    {
        int alpha;
        DominanceRanking ranking;

        public MultiObjectiveEA(MultiObjParams p) : base(p.evoParams)
        {
            this.alpha = p.alpha;
            this.ranking = new DominanceRanking(p.alpha);
        }

        public void generateDominanceRanking()
        {
            List<Dna> distanceSortedDnas = new List<Dna>(this.population.Dnas);
            List<Dna> dangerSortedDnas = new List<Dna>(this.population.Dnas);
            distanceSortedDnas.OrderByDescending(x => x.Fitness.distance);
            dangerSortedDnas.OrderByDescending(x => x.Fitness.danger);

            this.ranking = new DominanceRanking(this.alpha);

            for (int i = 0; i < this.alpha; i++)
            {
                // Gets all non-dominated Dnas for this level in the ranking
                this.ranking.Levels[i] = dominatedByX(distanceSortedDnas, dangerSortedDnas);
            }
        }

        private DominanceLevel dominatedByX(List<Dna> xSortedDnas, List<Dna> ySortedDnas)
        {
            // Returns the list of the first non-dominated level
            DominanceLevel level = new DominanceLevel();

            // This maps the index from the x list to the y list
            // it's good to store this since we may use the mapping a lot
            /*int[] mapXToY = new int[xSortedDnas.Count];
            for (int i = 0; i < xSortedDnas.Count; i++)
            {
                mapXToY[i] = ySortedDnas.IndexOf(xSortedDnas[i]);
            }*/
            int minNonDominatedYIndex = ySortedDnas.Count;
            for (int j = 0; j < xSortedDnas.Count; j++)
            {
                Dna currentDna = xSortedDnas[j];
                int currentDnaYIndex = ySortedDnas.IndexOf(currentDna);

                // CurrentDna that is worse on X has to be better in Y than the last non-dominated Dna
                if(currentDnaYIndex < minNonDominatedYIndex)
                {
                    xSortedDnas.RemoveAt(j);
                    ySortedDnas.RemoveAt(minNonDominatedYIndex);
                    minNonDominatedYIndex = currentDnaYIndex-1;
                    level.add(currentDna);
                }
                // If there isn't any Dna better in Y than the current there won't be any competitor
                if (minNonDominatedYIndex == -1)
                    return level;
            } // end of xSorted list iteration
            return null;
        }
        
    }

    public struct MultiObjParams
    {
        public Parameters evoParams;
        public int alpha;

        public MultiObjParams()
        {
            evoParams = new Parameters();
            alpha = 0;
        }
    }
}
