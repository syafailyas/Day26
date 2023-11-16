using NUnit.Framework;

namespace Calculation.Tests
{
	[TestFixture]
	public class NumberCalculationTests
	{
		private NumberCalculation numberCalc;

		[SetUp]
		public void Setup()
		{
			numberCalc = new NumberCalculation();
		}

		[Test]
		public void Add_ShouldReturnCorrectResult()
		{
			// Arrange
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(22));
		}

		[Test]
		public void Multiply_ShouldReturnCorrectResult()
		{
			// Arrange
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Multiply(a, b);

			// Assert
			Assert.That(result, Is.EqualTo(120));
		}

		[Test]
		public void Subtract_ShouldReturnCorrectResult()
		{
			// Arrange
			int a = 10;
			int b = 12;

			// Act
			int result = numberCalc.Subtract(a, b);

			// Assert
			Assert.AreEqual(-2, result);
		}

		[Test]
		public void Divide_ShouldReturnCorrectResult()
		{
			// Arrange
			int a = 10;
			int b = 2;

			// Act
			int result = numberCalc.Divide(a, b);

			// Assert
			Assert.AreEqual(5, result);
		}

		[Test]
		public void Divide_ShouldThrowDivideByZeroException()
		{
			// Arrange
			int a = 10;
			int b = 0;

			// Act and Assert
			Assert.Throws<DivideByZeroException>(() => numberCalc.Divide(a, b));
		}

		[TestCaseSource(nameof(TestCaseData))]
		public void Add_ShouldReturnCorrectResult_TestCase((int, int ,int) tuples)
		{
			// Arrange
			int a = tuples.Item1;
			int b = tuples.Item2;
			int expected = tuples.Item3;
			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.AreEqual(expected, result);
		}
		static IEnumerable<(int, int ,int)> TestCaseData() 
		{
			yield return (3, 5, 8);
			yield return (0, 0, 0);
			yield return (-10, 10, 0);
		}
		
		[TestCaseSource(typeof(TCS), nameof(TCS.Data))]
		public void Add_ShouldReturnCorrectResult_TestCase(int a,int b, int expected)
		{
			// Arrange
			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}

public class TCS
{
	public static object[] Data =
	{
		new object[] { 12, 3, 4 },
		new object[] { 12, 2, 6 },
		new object[] { 12, 4, 3 }
	};
}