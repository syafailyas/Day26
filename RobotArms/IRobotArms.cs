namespace RobotArms;
public interface IRobotArm
{
	void MoveToPosition(double x, double y, double z);
	bool IsAtPosition(double x, double y, double z);
	void Grab();
	void Release();
    bool CompareTool(int x, int y);
}
