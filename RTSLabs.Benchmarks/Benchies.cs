namespace RTSLabs.Benchmarks
{
  using BenchmarkDotNet.Attributes;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The benchies.
  /// </summary>
  [MemoryDiagnoser]
  public class Benchies
  {
    /// <summary>
    /// My class.
    /// </summary>
    private static readonly MyClass MyClass = new MyClass();

    /// <summary>
    /// Test array.
    /// </summary>
    private static readonly int[] Array = Enumerable.Range(0, 1000).ToArray();

    /// <summary>
    /// Above below benchmark.
    /// </summary>
    [Benchmark]
    public void AboveBelow()
    {
      MyClass.AboveBelow(Array, 50);
    }

    /// <summary>
    /// Rotates the string.
    /// </summary>
    [Benchmark]
    public void RotateString()
    {
      MyClass.RotateString("Timothy Eckstein is the freaking best in all the world", 34);
    }
  }
}