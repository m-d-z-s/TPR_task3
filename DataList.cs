namespace task3;

public class DataList
{
    public List<Data> listOfData;

    public DataList(List<Data> listOfData)
    {
        this.listOfData = listOfData;
    }

    public override string ToString()
    {
        return listOfData.Aggregate("", (current, item) => current + item);
    }

    public void Sort()
    {
        listOfData = listOfData.OrderByDescending(entry => -entry.travelTime)
            .ThenByDescending(entry => -entry.distanceToUni)
            .ThenByDescending(entry => entry.condition)
            .ThenByDescending(entry => -entry.price)
            .ThenByDescending(entry => -entry.hasBusStop)
            .ThenByDescending(entry => entry.hasBalcony).ToList();
    }
}

