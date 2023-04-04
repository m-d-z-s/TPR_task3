namespace task3;

public class Data
{
    public int id { get; set; }
    public int price { get; set; }
    public double distanceToUni { get; set; }
    public int hasBusStop { get; set; }
    public int condition { get; set; }
    public bool hasBalcony { get; set; }
    public int travelTime { get; set; }

    // Конструктор класса, который принимает массив значений из строки Excel
    public Data(int id, int price, double distanceToUni, int hasBusStop, int condition, bool hasBalcony, int travelTime)
    {
        this.id = id;
        this.price = price;
        this.distanceToUni = distanceToUni;
        this.hasBusStop = hasBusStop;
        this.condition = condition;
        this.hasBalcony = hasBalcony;
        this.travelTime = travelTime;
    }

    public override string ToString()
    {
        return $"{id}, {price}, {distanceToUni}, {hasBusStop}, {condition}, {hasBalcony}, {travelTime}\n";
    }

    public bool Dominates(Data other) => EqualOrGreaterThen(other) &&
                                         (this.price < other.price ||
                                          this.distanceToUni < other.distanceToUni ||
                                          this.hasBusStop < other.hasBusStop ||
                                          this.condition > other.condition ||
                                          Convert.ToInt32(this.hasBalcony) > Convert.ToInt32(other.hasBalcony) ||
                                          this.travelTime < other.travelTime);

    public bool EqualOrGreaterThen(Data other) => this.price <= other.price &&
                                                  this.distanceToUni <= other.distanceToUni &&
                                                  this.hasBusStop <= other.hasBusStop &&
                                                  this.condition >= other.condition &&
                                                  Convert.ToInt32(this.hasBalcony) >=
                                                  Convert.ToInt32(other.hasBalcony) &&
                                                  this.travelTime <= other.travelTime;

    public double GetMark()
    {
        double criteria = 0.3 * travelTime + 0.3 * distanceToUni + 0.1 * condition + 0.1 * price + 0.1 * hasBusStop +
                          0.1 * Convert.ToInt32(hasBalcony);
        return criteria;
    }
}