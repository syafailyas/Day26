using NUnit.Framework;
using Calculation;
using NUnit.Framework.Interfaces;
namespace Calculation.Tests
{
	[TestFixture]
	public class NumberCalculationTests
	{
		private NumberCalculation numberCalculation;
		
		[SetUp]
		public void Setup()
		{
			numberCalculation = new NumberCalculation();
		}

		[TestCase(5, 4, 9)] //[Fact]
		[TestCase(2, 3, 5)]
		[TestCase(6, 1, 7)]
		[TestCase(0, 0, 0)]
		public void Add_ReturnCorrectNumber_AdditionOfTwoNumber(int a, int b, int expected)
		{
			//Arrange

			//Act
			int actual = numberCalculation.Add(a, b);

			//Assert
			Assert.That(actual, Is.EqualTo(expected), "ini salah");
		}

		[Test]
		public void Subtract_SubstractionOfTwoNumbers()
		{
			//Arrange
			int a = 10;
			int b = 12;
			int expected = -2;
			//Act
			int actual = numberCalculation.Subtract(a, b);
			//Assert
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Multiply_ReturnCorrectNumber()
		{
			int a = 10;
			int b = 12;
			int expected = 120;

			int actual = numberCalculation.Multiply(a, b);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestDivision()
		{
			int a = 10;
			int b = 2;
			int expected = 5;

			int actual = numberCalculation.Divide(a, b);
			
			
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Divide_ShouldThrowDivideByZeroException_DivideByZero()
		{
			int a = 10;
			int b = 0;

			Assert.Throws<DivideByZeroException>(() => numberCalculation.Divide(a, b));
		}
	}
}
