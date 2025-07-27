using System.Threading.Tasks;

public class Program
{
  interface IDataFetcher
  {
    public Task<string> FetchDataAsync(string source);
  }

  public class DataFetcher : IDataFetcher
  {
    public async Task<string> FetchDataAsync(string source)
    {
      Console.WriteLine("Fetching Data from Source...");
      if (String.IsNullOrEmpty(source))
      {
        throw new ArgumentException("Source cannot be null or empty");
      }
      else
      {
        await Task.Delay(2000);
      }

      return "Fetched Data From " + source;
    }
  }

  public static async Task Main(string[] args)
  {
    DataFetcher df = new DataFetcher();

    try
    {
      string result = await df.FetchDataAsync("");
      Console.WriteLine(result);

    }
    catch (ArgumentException ex)
    {

      Console.WriteLine(ex.Message);
    }
  }
}
