namespace RTSLabs.Benchmarks
{
  using System;
  using BenchmarkDotNet.Running;

  /// <summary>
  /// The program.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// Entry point.
    /// </summary>
    private static void Main()
    {
      BenchmarkRunner.Run<Benchies>();

      Console.ReadLine();
    }
  }
}