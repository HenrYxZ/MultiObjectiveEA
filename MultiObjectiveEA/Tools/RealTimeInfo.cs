using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class RealTimeInfo
    {
        bool slowInfo = false;

        public RealTimeInfo(bool slowInfo)
        {
            this.slowInfo = slowInfo;
        }

        public void show(Population p)
        {
            Statistics stats = p.Stats;
           
            String s = "In generation {0} stats are:\n" +
                      "Average distance: {1}, average danger: {2}, average fitness: {3} \n";

            int avgDistance = stats.total.distance/p.Dnas.Count;
            int avgDanger = stats.total.danger/p.Dnas.Count;
            int avgFitness = stats.total.danger/p.Dnas.Count;

            Console.WriteLine(s, p.GenerationNumber, avgDistance, avgDanger, avgFitness);

            Console.WriteLine("Total fitness " + stats.total.fitness);
            Console.WriteLine("Best DNA distance " + stats.min.distance);
            Console.WriteLine("Best DNA danger" + stats.min.danger);
            Console.WriteLine("Worst DNA distance" + stats.max.distance);
            Console.WriteLine("Worst DNA danger" + stats.max.danger);

            if(slowInfo)
                // Time to look at the output
                System.Threading.Thread.Sleep(60);
        }
    }
}
