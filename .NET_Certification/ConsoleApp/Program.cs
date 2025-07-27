// Method to divide two numbers
using System;
using System.Threading.Tasks;
public class Program
{
    public async Task DownloadDataAsync()
    {
        Console.WriteLine("Before Timer");
        await Task.Delay(3000);
        Console.WriteLine("After Timer");

    }

    public async Task DownloadDataAsync2()
    {
        Console.WriteLine("Before Timer 2");
        await Task.Delay(3000);
        Console.WriteLine("After Timer 2");
    }

    public static async Task Main(string[] args)
    {
        Program program = new Program();

        Task task1 = program.DownloadDataAsync();
        Task task2 = program.DownloadDataAsync2();

        await Task.WhenAll(task1, task2);

    }
}
