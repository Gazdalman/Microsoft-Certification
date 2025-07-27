using System;
using System.Threading.Tasks;

public class Program
{
  interface IPrinter
  {
    public Task PrintMessageAsync(string message); // Because this is an interface, the method must be public and cannot have a body
  }

  public class ConsolePrinter : IPrinter
  {
    public async Task PrintMessageAsync(string message)
    {
      Console.WriteLine("Receiving message...");
      await Task.Delay(2000);
      Console.WriteLine("Received message!");
      Console.WriteLine(message);
    }
  }

  public static async Task Main(string[] args)
  {
    ConsolePrinter cp1 = new ConsolePrinter();
    await cp1.PrintMessageAsync("Hello World");
  }
}
