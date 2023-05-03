using RobotArms;
using Xunit;
using Moq;

public class RobotControllerTests
{
	[Fact]
	public void TestRobotController()
	{
		// Arrange
		Mock<IRobotArm> mockRobotArm = new Mock<IRobotArm>();
		mockRobotArm.Setup(r => r.IsAtPosition(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(true);
		mockRobotArm.Setup(d => d.CompareTool(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

		RobotController robotController = new RobotController(mockRobotArm.Object);

		// Act
		robotController.Execute();
		bool result = robotController.CompareTool(1, 1);

		// Assert
		mockRobotArm.Verify(r => r.MoveToPosition(10, 20, 30), Times.Once);
		mockRobotArm.Verify(r => r.Grab(), Times.Once);
		mockRobotArm.Verify(r => r.MoveToPosition(40, 50, 60), Times.Once);
		mockRobotArm.Verify(r => r.Release(), Times.Once);
        Assert.True(result);
    }
}
