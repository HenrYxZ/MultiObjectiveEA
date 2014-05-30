using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiObjectiveEA
{
    class Parser
    {
        // Methods for "opt.parametros.txt"

        public Parameters getParameters(string filePath)
        {
            Queue<string> lines = new Queue<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int counter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Enqueue(line);
                    counter++;
                }
            }

            int gens = Convert.ToInt32(lines.Dequeue().Split('=')[1].Trim());
            int popu = Convert.ToInt32(lines.Dequeue().Split('=')[1].Trim());
            float xover = Convert.ToSingle(lines.Dequeue().Split('=')[1].Trim());
            float mut = Convert.ToSingle(lines.Dequeue().Split('=')[1].Trim());
            int money = Convert.ToInt32(lines.Dequeue().Split('=')[1].Trim());

            Parameters p = new Parameters();
            p.gen = gens;
            p.pop = popu;
            p.xover = xover;
            p.mut = mut;

            return p;
        }
    }
}
