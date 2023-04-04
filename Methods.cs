using NPOI.POIFS.FileSystem;

namespace task3;

public static class Methods
{
    public static DataList Pareto(DataList dataList)
    {
        var paretoSet = new HashSet<Data>();
        foreach (var entry in dataList.listOfData)
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
        foreach (var entry in dataList.listOfData)
        {
            if (entry.EqualOrGreaterThen(minimum))
            {
                paretoSetMin.Add(entry);
            }
        }

        return new DataList(paretoSetMin.ToList());
    }

    public static Data Sub(DataList dataList) =>
        dataList.listOfData.Aggregate((max, it) => it.condition > max.condition ? it : max);

    public static Data Optimization(DataList dataList)
    {
        dataList.Sort();
        return dataList.listOfData[0];
    }

    public static Data Five(DataList dataList)
    {
        var dataWithCriteria = new Dictionary<double, Data>();
        foreach (var item in dataList.listOfData)
        {
            dataWithCriteria.Add(item.GetMark(),item);
        }

        return dataWithCriteria[dataWithCriteria.Max(pair=>pair.Key)];
    }
    
}