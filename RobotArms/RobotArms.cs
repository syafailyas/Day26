namespace RobotArms;
public class RobotArm : IRobotArm
{
	private double _x;
	private double _y;
	private double _z;
	private bool _isHolding;

	public void MoveToPosition(double x, double y, double z)
	{
		_x = x;
		_y = y;
		_z = z;
	}

	public bool IsAtPosition(double x, double y, double z)
	{
		return _x == x && _y == y && _z == z;
	}

	public void Grab()
	{
		if (!_isHolding)
		{
			_isHolding = true;
			Console.WriteLine("The robot arm has grabbed an object.");
		}
		else
		{
			Console.WriteLine("The robot arm is already holding an object.");
		}
	}

	public void Release()
	{
		if (_isHolding)
		{
			_isHolding = false;
			Console.WriteLine("The robot arm has released the object.");
		}
		else
		{
			Console.WriteLine("The robot arm is not holding an object.");
		}
	}
	
	public bool CompareTool(int x, int y)
	{
		return x==y;
	}
}
