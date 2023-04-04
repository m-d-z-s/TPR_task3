namespace task3;

public class DataList
{
    public List<Data> ListOfData;

    public DataList(List<Data> listOfData)
    {
        this.ListOfData = listOfData;
    }

    public override string ToString()
    {
        var output = "";
        foreach (var item in ListOfData)
        {
            output += item.ToString();
        }
        return ListOfData.Aggregate("", (current, item) => current + item);
    }

    public void Sort()
    {
        ListOfData = ListOfData.OrderByDescending(entry => -entry.TravelTime)
            .ThenByDescending(entry => entry.DistanceToUni)
            .ThenByDescending(entry => entry.Condition)
            .ThenByDescending(entry => entry.Price)
            .ThenByDescending(entry => entry.TimeToBusStop)
            .ThenByDescending(entry => entry.HasBalcony).ToList();
    }
}
