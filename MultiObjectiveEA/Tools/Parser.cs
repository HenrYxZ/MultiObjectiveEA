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

        public MultiObjParams getParameters(string filePath)
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
            double xover = Convert.ToDouble(lines.Dequeue().Split('=')[1].Trim());
            double mut = Convert.ToDouble(lines.Dequeue().Split('=')[1].Trim());
            int alfa = Convert.ToInt32(lines.Dequeue().Split('=')[1].Trim());

            MultiObjParams p = new MultiObjParams();
            p.evoParams.gen = gens;
            p.evoParams.pop = popu;
            p.evoParams.xover = xover;
            p.evoParams.mut = mut;
            p.alpha = alfa;
            return p;
        }

        // Method for 2014tarea2datosDist.csv and 2014tarea2datosDanger.csv
        public int[][] getMatrix(string filePath)
        {
            int [][] matrix = new int[20][];
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                int counter = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    matrix[counter] = new int[20];
                    for (int i = counter+2; i < data.Length; i++)
                    {
                        matrix[counter][i - 1] = Convert.ToInt32(data[i]);
                    }
                    counter++;
                }
            }
            return matrix;
        }
    }
}
