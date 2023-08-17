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
		_players = players.ToList();
	}

	public IList<IPlayer> GetListPlayers()
	{
		return _players.ToList();
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
		Assert.AreEqual(2, result.Count());
        Assert.AreEqual("satrio",player1.Object.GetName());
        Assert.AreEqual("joko", player2.Object.GetName());
	}
}