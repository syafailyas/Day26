using NUnit.Framework;
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

		[Test]
		public void TestAddition()
		{
			int a = 10;
			int b = 12;
			int expected = 22;

			int actual = numberCalculation.Add(a, b);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestSubtraction()
		{
			int a = 10;
			int b = 12;
			int expected = -2;

			int actual = numberCalculation.Subtract(a, b);

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestMultiplication()
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
		public void TestDivisionByZero()
		{
			int a = 10;
			int b = 1;

			Assert.Throws<System.DivideByZeroException>(() => numberCalculation.Divide(a, b));
		}
	}
}
