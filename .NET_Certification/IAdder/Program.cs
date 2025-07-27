using System;
using System.Threading.Tasks;

public class Program
{
  interface IAdder
  {
    public Task<int> AddAsync(int a, int b); // The Task<int> return type indicates that this method is asynchronous and will return an integer result
  }

  public class SlowAdder : IAdder
  {
    public async Task<int> AddAsync(int a, int b)
    {
      Console.WriteLine("Adding Numbers...");
      await Task.Delay(3000);
      Console.WriteLine("Calculation Complete!");

      return a + b;
    }
  }

  public static async Task Main(string[] args)
  {
    SlowAdder slowAdder = new SlowAdder();

    int result = await slowAdder.AddAsync(1, 5);

    Console.WriteLine(result);
  }
}
