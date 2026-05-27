using BenchmarkDotNet.Running;

namespace CryptoClients.Net.Benchmark.Client
{
    public class Program
    {
        public static int ServerPort = 5000;

        public static void Main(string[] args)
        {
            //var tester = new LibraryComparisonBenchmarksRest();
            //tester.Setup();
            //tester.CCXT_Ticker().Wait();
            //tester.Cleanup();
            //Console.ReadLine();

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
