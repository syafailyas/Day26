using System;
namespace RobotArms;
public class Program
{
    public static void Main()
    {
        RobotController robotController = new(new RobotArm());
        robotController.Execute();
    }
}
