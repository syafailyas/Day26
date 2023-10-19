using System;
using NUnit.Framework;
using Moq;

public interface IPlayer
{
	int level{ get; set; }
	string GetName();
	bool SetName(string name);
}

public class GameRunner
{
	private IList<IPlayer> _players;

	public GameRunner(IList<IPlayer> players)
	{
		_players = players;
	}

	public IList<IPlayer> GetListPlayers()
	{
		return _players;
	}
}

[TestFixture]
public class GameRunnerTests
{
	[Test]
	public void GetListPlayers_ReturnsCorrectPlayers()
	{
		// ARRANGE
		var player1 = new Mock<IPlayer>();
		player1.SetupProperty(u => u.level, 1);
		player1.Setup(u => u.GetName()).Returns(()=> "satrio");
		
		var player2 = new Mock<IPlayer>();
		player2.SetupProperty(u => u.level, 3);
		player2.Setup(u => u.GetName()).Returns(()=> "joko");

		IList<IPlayer> players = new IPlayer[] { player1.Object, player2.Object };
		var GameRunner = new GameRunner(players);

		// ACT
		IList<IPlayer> result = GameRunner.GetListPlayers();

		// ASSERT
		Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result[0].GetName(), Is.EqualTo("satrio"));
        Assert.That(result[1].GetName(), Is.EqualTo("joko"));
	}
}