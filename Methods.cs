namespace task3;

public static class Methods
{
    public static DataList Pareto(DataList dataList)
    {
        var paretoSet = new HashSet<Data>();
        foreach (var entry in dataList.ListOfData)
        {
            var isParetoOptimal = true;
            foreach (var other in paretoSet)
            {
                if (other.Dominates(entry))
                {
                    isParetoOptimal = false;
                    break;
                }
                if (entry.Dominates(other)) paretoSet.Remove(other);
            }
            if (isParetoOptimal) paretoSet.Add(entry);
        }

        return new DataList(paretoSet.ToList());
    }

    public static DataList ParetoMin(DataList dataList)
    {
        var minimum = new Data(0, 30000, 3.5, 15, 1, false, 30);
        var paretoSetMin = new HashSet<Data>();
        foreach (var entry in dataList.ListOfData)
        {
            if (entry.EqualOrGreaterThen(minimum))
            {
                paretoSetMin.Add(entry);
            }
        }

        return new DataList(paretoSetMin.ToList());
    }

    public static Data SubOptimisation(DataList dataList) =>
        dataList.ListOfData.Aggregate((max, it) => it.Condition > max.Condition ? it : max);

    public static Data Lexicographics(DataList dataList)
    {
        dataList.Sort();
        return dataList.ListOfData[0];
    }

    public static Data CombinedCriteria(DataList dataList)
    {
        var dataWithCriteria = new Dictionary<double, Data>();
        foreach (var item in dataList.ListOfData)
        {
            dataWithCriteria.Add(item.GetMark(),item);
        }

        return dataWithCriteria[dataWithCriteria.Max(pair=>pair.Key)];
    }
}
