// <copyright file="MyClass.cs" company="RTS Labs">
// Copyright (c) RTS Labs. All rights reserved.
// </copyright>

namespace RTSLabs
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Diagnostics.CodeAnalysis;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// My class.
  /// </summary>
  public class MyClass
  {
    /// <summary>
    /// Finds number of values above or below test value.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="testValue">The test value.</param>
    /// <returns>An AboveBelowData.</returns>
    public (int above, int below) AboveBelow([DisallowNull] int[] array, int testValue)
    {
      return this.AboveBelowLinq(array, testValue);
    }

    /// <summary>
    /// Rotates the string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="rotation">The rotation.</param>
    /// <returns>A string.</returns>
    public string RotateString([DisallowNull] string input, int rotation)
    {
      if (input == string.Empty)
      {
        return input;
      }

      if (rotation == 0)
      {
        return input;
      }

      rotation %= input.Length;
      if (rotation < 0)
      {
        rotation += input.Length;
      }

      return this.RotateStringSingleAllocation(input, rotation);
    }

    /// <summary>
    /// Rotates the string traditional.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="rotation">The rotation.</param>
    /// <returns>A string.</returns>
    private string RotateStringTraditional(string input, int rotation)
    {
      int slicePoint = input.Length - rotation;
      return $"{input.Substring(slicePoint)}{input.Substring(0, slicePoint)}";
    }

    /// <summary>
    /// Rotates the string single allocation.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="rotation">The rotation.</param>
    /// <returns>A string.</returns>
    private unsafe string RotateStringSingleAllocation(string input, int rotation)
    {
      char[] buffer = new char[input.Length];

      fixed (char* inputPtr = input)
      {
        char* start = inputPtr;
        char* end = inputPtr + input.Length;
        char* begin = inputPtr + (input.Length - rotation);
        char* ptr = begin;
        int index = 0;
        while (index < input.Length)
        {
          buffer[index++] = *ptr;
          ptr++;
          if (ptr == end)
          {
            ptr = start;
          }
        }
      }

      return new string(buffer);
    }

    /// <summary>
    /// Above below traditional.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="testValue">The test value.</param>
    /// <returns>An AboveBelowData.</returns>
    private (int above, int below) AboveBelowTraditional(int[] array, int testValue)
    {
      int below = 0;
      int above = 0;

      for (int i = 0; i < array.Length; i++)
      {
        if (array[i] < testValue)
        {
          below++;
        }

        if (array[i] > testValue)
        {
          above++;
        }
      }

      return (above, below);
    }

    /// <summary>
    /// Above below linq.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="testValue">The test value.</param>
    /// <returns>An AboveBelowData.</returns>
    private (int above, int below) AboveBelowLinq(int[] array, int testValue)
    {
      return (array.Where(x => x > testValue).Count(), array.Where(x => x < testValue).Count());
    }
  }
}