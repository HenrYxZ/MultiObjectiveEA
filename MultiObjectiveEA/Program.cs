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
            MultiObjParams MOEAParams = parser.getParameters("opt.parametros.txt");
            MultiObjectiveEA moea = new MultiObjectiveEA(MOEAParams);
            moea.Distances = parser.getMatrix("20141tarea2datosDist.csv");
            moea.Dangers = parser.getMatrix("20141tarea2datosDanger.csv");

            Console.WriteLine("Welcome to the multi-objective optimizer!!\n"
                            + "Press 1 if you don't want realtime output,\n" +
                              "2 for really fast realtime output\n" +
                              "3 for readable realtime output");

            moea.run(Convert.ToInt32(Console.ReadLine()));
            /*
            Dna d = new Dna();
            Dna a = new Dna();
            List<Dna> l1 = new List<Dna>(2);
            List<Dna> l2 = new List<Dna>(2);
            Dna b = a;
            l1.Add(d); l1.Add(a); l1.Add()
            l2.Add()
            */
        }
    }
}
