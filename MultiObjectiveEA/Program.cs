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
            /*Parser parser = new Parser();
            MultiObjParams MOEAParams =  parser.getParameters("opt.parametros.txt");
            MultiObjectiveEA ea = new MultiObjectiveEA(MOEAParams);
            ea.Distances = parser.getMatrix("2014tarea2datosDist.csv");
            ea.Dangers = parser.getMatrix("2014tarea2datosDanger.csv");
            ea.run();*/

            B b = new B();
            b.print();
            Console.ReadKey();
        }
    }

    class A
    {
        public virtual void print()
        {
            hello();
        }

        public virtual void hello()
        {
            Console.WriteLine("hello fro A");
        }
    }

    class B : A 
    {
        public override void hello()
        {
            Console.WriteLine("hello fro B");
        }
    }
}
