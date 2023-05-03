namespace RobotArms;

public class RobotController
{
	private readonly IRobotArm _robotArm;

	public RobotController(IRobotArm robotArm)
	{
		_robotArm = robotArm;
	}

	public void Execute()
	{
		_robotArm.MoveToPosition(10, 20, 30);
		if (_robotArm.IsAtPosition(10, 20, 30))
		{
			_robotArm.Grab();
		}

		_robotArm.MoveToPosition(40, 50, 60);
		if (_robotArm.IsAtPosition(40, 50, 60))
		{
			_robotArm.Release();
		}
	}
	
	public bool CompareTool(int x, int y)
	{
		return _robotArm.CompareTool(x, y);
	}
}
