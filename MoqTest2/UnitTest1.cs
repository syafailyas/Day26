using Moq;

class GameController {
	private IDice dice;
	public GameController(IDice dice) {
		this.dice = dice;
	}
	public int Roll() {
		return dice.Roll() * 10;
	}
}
public interface IDice {
	int Roll();
}

public class GameControllerTest{
	[Fact]
	public void Roll_ValueResult(){
		//Arrange
		var mockDice = new Mock<IDice>();
		mockDice.Setup(dice => dice.Roll()).Returns(()=>2);
		GameController game = new GameController(mockDice.Object);
		
		//Act
		int result = game.Roll();
		
		//Assert
		Assert.Equal(20, result);
	}
}
