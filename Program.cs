using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task3
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var apart =  ToolBox.CollectInfo();
            foreach (var item in apart.listOfData)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("pareto");
            var pareto = Methods.Pareto(apart);
            foreach (var item in pareto.listOfData)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("pareto min");
            var paretoMin = Methods.ParetoMin(pareto);
            foreach (var item in paretoMin.listOfData)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Sub");
            var sub = Methods.Sub(paretoMin);
            Console.WriteLine(sub);

            Console.WriteLine("Optimization");
            var optimization = Methods.Optimization(apart);
            Console.WriteLine(optimization);

            Console.WriteLine("Five");
            var five = Methods.Five(apart);
            Console.WriteLine(five);
        }
    }
}

