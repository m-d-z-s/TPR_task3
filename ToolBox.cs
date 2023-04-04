using Newtonsoft.Json;

namespace task3;

public static class ToolBox
{
    private const string PathToDataSet =
        @"C:\Users\brusi\Programming\C#\TPR_C#\task3\bin\Debug\net7.0\apartmentsData.json";
    public static DataList CollectInfo() 
        => JsonConvert.DeserializeObject<DataList>(ReadFile());

    private static string ReadFile() => File.ReadAllText(PathToDataSet);
}