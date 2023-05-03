using SimpleCalculation;
class Program 
{
	static void Main() 
	{
		SimpleCalculator simpleCalculator = new();
		int a = 10;
		int b = 12;
		int x = simpleCalculator.Add(a, b);
		int y = simpleCalculator.Subtract(a, b);
	}
}
public class SimpleCalculator : ICalculator
{
	public int Add(int a, int b)
	{
		return a + b;
	}

	public int Subtract(int a, int b)
	{
		return a - b;
	}
}
