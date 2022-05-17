namespace RTSLabs.UnitTests
{
  using System;
  using NUnit.Framework;

  /// <summary>
  /// The my class tests.
  /// </summary>
  [TestFixture]
  internal class MyClassTests
  {
    /// <summary>
    /// AboveBelow with empty array returns two zeros.
    /// </summary>
    [Test]
    public void AboveBelowEmptyArray()
    {
      var myClass = new MyClass();
      var result = myClass.AboveBelow(Array.Empty<int>(), 0);
      Assert.AreEqual(0, result.above, "Above is not 0");
      Assert.AreEqual(0, result.below, "Below is not 0");
    }

    /// <summary>
    /// AboveBelow all below.
    /// </summary>
    [Test]
    public void AboveBelowAllBelow()
    {
      var myClass = new MyClass();
      var result = myClass.AboveBelow(new int[] { 1, 2, 3 }, 5);
      Assert.AreEqual(0, result.above, "Above is not 0");
      Assert.AreEqual(3, result.below, "Below is not 3");
    }

    /// <summary>
    /// AboveBelow all above.
    /// </summary>
    [Test]
    public void AboveBelowAllAbove()
    {
      var myClass = new MyClass();
      var result = myClass.AboveBelow(new int[] { 1, 2, 3 }, -1);
      Assert.AreEqual(3, result.above, "Above is not 3");
      Assert.AreEqual(0, result.below, "Below is not 0");
    }

    /// <summary>
    /// AboveBelow all equal.
    /// </summary>
    [Test]
    public void AboveBelowAllEqual()
    {
      var myClass = new MyClass();
      var result = myClass.AboveBelow(new int[] { 1, 1, 1 }, 1);
      Assert.AreEqual(0, result.above, "Above is not 0");
      Assert.AreEqual(0, result.below, "Below is not 0");
    }

    /// <summary>
    /// Rotates the string empty.
    /// </summary>
    [Test]
    public void RotateStringEmpty()
    {
      var myClass = new MyClass();
      var rotated = myClass.RotateString(string.Empty, 20);
      Assert.AreEqual("", rotated);
    }

    /// <summary>
    /// Rotates the string zero.
    /// </summary>
    [Test]
    public void RotateStringZero()
    {
      var myClass = new MyClass();
      var rotated = myClass.RotateString("Timothy Eckstein", 0);
      Assert.AreEqual("Timothy Eckstein", rotated);
    }

    /// <summary>
    /// Rotates the string normal.
    /// </summary>
    [Test]
    public void RotateStringNormal()
    {
      var myClass = new MyClass();
      var rotated = myClass.RotateString("Timothy Eckstein", 4);
      Assert.AreEqual("teinTimothy Ecks", rotated);
    }

    /// <summary>
    /// Rotates the string larger than string.
    /// </summary>
    [Test]
    public void RotateStringLargerThanString()
    {
      var myClass = new MyClass();
      var rotated = myClass.RotateString("Timothy Eckstein", 20);
      Assert.AreEqual("teinTimothy Ecks", rotated);
    }

    /// <summary>
    /// Rotates the string less than zero.
    /// </summary>
    [Test]
    public void RotateStringLessThanZero()
    {
      var myClass = new MyClass();
      var rotated = myClass.RotateString("Timothy Eckstein", -4);
      Assert.AreEqual("thy EcksteinTimo", rotated);
    }
  }
}