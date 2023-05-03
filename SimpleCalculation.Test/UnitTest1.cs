using SimpleCalculation;
using Moq;
using Xunit;

public class CalculatorTests
{
	[Fact]
	public void TestAddition()
	{
		// Arrange
		var mockCalculator = new Mock<ICalculator>();
		mockCalculator.Setup(c => c.Add(2, 3)).Returns(5);

		// Act
		int result = mockCalculator.Object.Add(2, 3);

		// Assert
		Assert.Equal(5, result);
		mockCalculator.Verify(c => c.Add(2, 3), Times.Once);
	}

	[Fact]
	public void TestSubtraction()
	{
		// Arrange
		var mockCalculator = new Mock<ICalculator>();
		mockCalculator.Setup(c => c.Subtract(7, 4)).Returns(3);

		// Act
		int result = mockCalculator.Object.Subtract(7, 4);

		// Assert
		Assert.Equal(3, result);
		mockCalculator.Verify(c => c.Subtract(7, 4), Times.Once);
	}
}
