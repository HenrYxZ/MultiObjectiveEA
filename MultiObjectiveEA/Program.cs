using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Parameters evoParams =  parser.getParameters("opt.parametros.txt");
            MultiObjectiveEA ea = new MultiObjectiveEA(evoParams);
        }
    }
}
