using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiObjectiveEA
{
    class InfoWriter
    {
        String filePath;

        public String FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public InfoWriter(string filePath)
        {

        }

        public void write(DominanceRanking ranking)
        {
            using (StreamWriter sw = new StreamWriter(this.filePath))
            {
                sw.WriteLine("First Level in Non-Dominance Ranking in generation {0}:\n", ranking.CurrentGeneration);
                sw.WriteLine(ranking.Levels[0]);
            }
        }
    }
}
