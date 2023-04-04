namespace task3;

public class Data
{
    public int Id { get; }
    public int Price { get; }
    public double DistanceToUni { get; }
    public int TimeToBusStop { get; }
    public int Condition { get; }
    public bool HasBalcony { get; }
    public int TravelTime { get; }

    public Data(int id, int price, double distanceToUni, int timeToBusStop, int condition, bool hasBalcony, int travelTime)
    {
        this.Id = id;
        this.Price = price;
        this.DistanceToUni = distanceToUni;
        this.TimeToBusStop = timeToBusStop;
        this.Condition = condition;
        this.HasBalcony = hasBalcony;
        this.TravelTime = travelTime;
    }

    public override string ToString()
    {
        return $"{Id}, {Price}, {DistanceToUni}, {TimeToBusStop}, {Condition}, {HasBalcony}, {TravelTime}";
    }

    public bool Dominates(Data other) => EqualOrGreaterThen(other) &&
                                         (this.Price < other.Price ||
                                          this.DistanceToUni < other.DistanceToUni ||
                                          this.TimeToBusStop < other.TimeToBusStop ||
                                          this.Condition > other.Condition ||
                                          Convert.ToInt32(this.HasBalcony) > Convert.ToInt32(other.HasBalcony) ||
                                          this.TravelTime < other.TravelTime);

    public bool EqualOrGreaterThen(Data other) => this.Price <= other.Price &&
                                                  this.DistanceToUni <= other.DistanceToUni &&
                                                  this.TimeToBusStop <= other.TimeToBusStop &&
                                                  this.Condition >= other.Condition &&
                                                  Convert.ToInt32(this.HasBalcony) >=
                                                  Convert.ToInt32(other.HasBalcony) &&
                                                  this.TravelTime <= other.TravelTime;

    public double GetMark()
    {
        return 0.3 * -TravelTime + 0.3 * -DistanceToUni + 0.1 * Condition + 0.1 * -Price
               + 0.1 * -TimeToBusStop + 0.1 * Convert.ToInt32(HasBalcony);
    }
}
