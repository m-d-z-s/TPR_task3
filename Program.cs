namespace task3;

public static class Program
{
    private static void Main()
    {
        var apartments =  ToolBox.CollectInfo(); // collecting data about apartments
        
        Console.WriteLine("Initial dataset:"); // showing the initial dataset
        foreach (var item in apartments.ListOfData) 
        {
            Console.WriteLine(item);
        }
        
        Console.WriteLine("\nPareto's set:"); // getting Pareto's set 
        var pareto = Methods.Pareto(apartments);
        foreach (var item in pareto.ListOfData)
        {
            Console.WriteLine(item);
        }
            
        Console.WriteLine("\nPareto's set with lowest criteria: "); // narrowing Pareto's set by comparing to the lowest
        var paretoMin = Methods.ParetoMin(pareto);
        foreach (var item in paretoMin.ListOfData)
        {
            Console.WriteLine(item);
        }
            
        Console.WriteLine("\nSub-optimisation:"); // getting the result by sub-optimisation
        var sub = Methods.SubOptimisation(paretoMin);
        Console.WriteLine(sub);

        Console.WriteLine("\nOptimization"); // getting the result by lexicographical method
        var lexicographicsResult = Methods.Lexicographics(apartments);
        Console.WriteLine(lexicographicsResult);

        Console.WriteLine("\nResult by combined criteria:"); // getting the result by combined criteria method
        var combinedCriteriaResult = Methods.CombinedCriteria(apartments);
        Console.WriteLine(combinedCriteriaResult);
    }
}
