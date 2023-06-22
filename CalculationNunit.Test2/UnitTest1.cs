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
			Assert.AreEqual(22, result);
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
			Assert.AreEqual(120, result);
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

		[TestCase(3, 5, 90)]
		[TestCase(0, 0, 0)]
		[TestCase(-10, 10, 0)]
		public void Add_ShouldReturnCorrectResult_TestCase(int a, int b, int expected)
		{
			// Arrange

			// Act
			int result = numberCalc.Add(a, b);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
