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
        int[][] distances;
        int[][] dangers;
        RealTimeInfo realTimeInfo;
        InfoWriter infoWriter;

        internal RealTimeInfo RealTimeInfo
        {
            get { return realTimeInfo; }
            set { realTimeInfo = value; }
        }

        public int[][] Distances
        {
            get { return distances; }
            set { distances = value; }
        }

        public int[][] Dangers
        {
            get { return dangers; }
            set { dangers = value; }
        }

        // Constructor

        public MultiObjectiveEA(MultiObjParams p) : base(p.evoParams)
        {
            this.alpha = p.alpha;
        }

        // Methods

        public override void select()
        {
            generateDominanceRanking();
            int breedingSize = this.ranking.Count;
            if(breedingSize > this.evoParams.pop/2) 
            {
                breedingPool = new BreedingPool(breedingSize);
                breedingPool.add(this.ranking);
            }
            else
            {
                breedingPool = new BreedingPool(this.evoParams.pop / 2);
                int counter = 0;
                while(breedingPool.Count < this.evoParams.pop / 2)
                {
                    breedingPool.add(this.population.Dnas[counter]);
                    counter++;
                }
            }
            
        }

        public override Dna crossover(Dna x, Dna y)
        {
            Dna newDna = new Dna();
            // -1 for visited, 0 otherwise
            int[] visitedCities = new int[x.Edges.Count];
            Random r = new Random();
            int pivot = r.Next(visitedCities.Length);
            for (int i = 0; i < pivot; i++)
			{
                visitedCities[x.Edges[i].Vertices[0] - 1] = -1;
                newDna.Edges.Add(x.Edges[i]);
			}
            visitedCities[newDna.Edges[newDna.Edges.Count - 1].Vertices[1] - 1] = -1;
            int[] restOrder = new int[visitedCities.Length - pivot];
            int counter = 0;
            for (int i = 0; i < y.Edges.Count; i++)
            {
                int currentOriginVertex = y.Edges[i].Vertices[0] - 1;
                if(visitedCities[currentOriginVertex] == 0)
                {
                    restOrder[counter] = currentOriginVertex;
                    counter++;
                    visitedCities[currentOriginVertex] = -1;
                }
            }

            for (int i = 0; i < restOrder.Length-1; i++)
			{
                newDna.Edges.Add(new Edge(restOrder[i] + 1, restOrder[i + 1] + 1));
			}
            newDna.Edges.Add(new Edge(restOrder[restOrder.Length-1] + 1, restOrder[0] + 1));
            newDna.evaluate(distances, dangers);
            return newDna;
        }

        public override void mutate(Dna dna)
        {
            Random r = new Random();
            int pivot1 = r.Next(dna.Edges.Count);
            int pivot2 = r.Next(dna.Edges.Count);
            while(pivot2 == pivot1)
                pivot2 = r.Next(dna.Edges.Count);

            // Swap the cities
            int aux = dna.Edges[pivot1].Vertices[0];
            dna.Edges[pivot1].Vertices[0] = dna.Edges[pivot2].Vertices[0];
            if (pivot1 == 0)
                dna.Edges[dna.Edges.Count - 1].Vertices[1] = dna.Edges[pivot2].Vertices[0];
            else
                dna.Edges[pivot1-1].Vertices[1] = dna.Edges[pivot2].Vertices[0];

            dna.Edges[pivot2].Vertices[0] = aux;
            if (pivot2 == 0)
                dna.Edges[dna.Edges.Count - 1].Vertices[1] = aux;
            else
                dna.Edges[pivot2 - 1].Vertices[1] = aux;
            dna.evaluate(distances, dangers);

        }

        public override void run(int option)
        {
            string output = "rutas.out";
            realTimeInfo = new RealTimeInfo(option);
            infoWriter = new InfoWriter(output);

            this.population = new Population(evoParams.pop);

            populate();
            
            for (int currentGen = 0; currentGen < evoParams.gen; currentGen++)
            {
                this.currentGeneration = currentGen;
                population.GenerationNumber = currentGen;
                population.evaluate(distances, dangers);
                realTimeInfo.show(population);

                select();
                infoWriter.write(this.ranking);

                reproduce();
                mutate();
            }
        }

        public void generateDominanceRanking()
        {
            List<Dna> distanceSortedDnas = new List<Dna>(this.population.Dnas);
            List<Dna> dangerSortedDnas = new List<Dna>(this.population.Dnas);
            distanceSortedDnas.OrderByDescending(x => x.Fitness.distance);
            dangerSortedDnas.OrderByDescending(x => x.Fitness.danger);

            this.ranking = new DominanceRanking(this.alpha, this.currentGeneration);

            for (int i = 0; i < this.alpha; i++)
            {
                // Gets all non-dominated Dnas for this level in the ranking
                this.ranking.Levels.Add(dominatedByX(distanceSortedDnas, dangerSortedDnas, i));
            }
        }

        private DominanceLevel dominatedByX(List<Dna> xSortedDnas, List<Dna> ySortedDnas, int lvl)
        {
            // Returns the list of the first non-dominated level
            DominanceLevel level = new DominanceLevel(lvl);

            // This maps the index from the x list to the y list
            // it's good to store this since we may use the mapping a lot
            /*int[] mapXToY = new int[xSortedDnas.Count];
            for (int i = 0; i < xSortedDnas.Count; i++)
            {
                mapXToY[i] = ySortedDnas.IndexOf(xSortedDnas[i]);
            }*/
            int minNonDominatedYIndex = ySortedDnas.Count-1;
            for (int j = 0; j < xSortedDnas.Count; j++)
            {
                Dna currentDna = xSortedDnas[j];
                int currentDnaYIndex = ySortedDnas.IndexOf(currentDna);

                // CurrentDna that is worse on X has to be better in Y than the last non-dominated Dna
                if(currentDnaYIndex <= minNonDominatedYIndex && currentDnaYIndex >= 0)
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
            return level;
        }
        
    }

    public struct MultiObjParams
    {
        public Parameters evoParams;
        public int alpha;

        public MultiObjParams(Parameters evoP, int a)
        {
            evoParams = evoP;
            alpha = a;
        }
    }
}
