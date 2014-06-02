using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Dna
    {
        List<Edge> edges;
        Fitness fitness;

        public List<Edge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        public Fitness Fitness
        {
            get 
            {   if(fitness == null)
                {
                    evaluate();
                }
                return fitness; 
            }
            set { fitness = value; }
        }

        public Dna()
        {
            int numberOfCities = 20;
            edges = new List<Edge>(numberOfCities);
        }

        public Dna(int stringLength)
        {
            int numberOfCities = stringLength;
            edges = new List<Edge>(numberOfCities);
        }

        public void mutate()
        {
            // TODO: Mutate Dna
        }

        private void evaluate()
        {
            int totalDistance = 0;
            int totalDanger = 0;
            foreach (Edge edge in edges)
            {
                totalDanger -= edge.Danger;
                totalDistance -= edge.Distance;
            }
            this.fitness = new Fitness(totalDistance, totalDanger);
        }

        public override string ToString()
        {
            String answer = "DNA: \n";
            for (int i = 0; i < edges.Count; i++)
            {
                answer += edges.ToString();
            }
            answer += "\n";
            answer += "total distance = " + Fitness.distance * -1;
            answer += "\n";
            answer += "total danger = " + Fitness.danger * -1;
            answer += "\n";
            return answer;
        }
          
    }

    public class Fitness 
    {
        public int distance;
        public int danger;
        public int total;

        public Fitness(int dist, int dang)
        {
            distance = dist;
            danger = dang;
            // TODO: Normalized fitness!
            total = dist + dang;
        }
    }

}
