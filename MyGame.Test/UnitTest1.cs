using System.Collections;
using System.ComponentModel;
using Moq;


namespace MyGame.Test
{
	public class GameControllerTests
	{
		private GameController _game;
		private static Mock<IPlayer> _player;
		private static Mock<ICard> _card;
		private static Mock<IBoard> _board;

		[SetUp]
		public void SetUp()
		{
			_player = new Mock<IPlayer>();
			_card = new Mock<ICard>();
			_board = new Mock<IBoard>();
			_game = new GameController(_player.Object, _board.Object);
		}

		[Test]
		public void AddCards_CardsAddedSuccessfullyReturnsTrue_PlayerExists()
		{
			//_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));

			bool result = _game.AddCards(_player.Object, _card.Object);

			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(CardStatus.OnPlayer), Times.Once);
		}
		[Test]
		public void AddCards_ReturnsFalse_PlayerNotExists()
		{
			IPlayer notPlayer = new Mock<IPlayer>().Object;

			bool result = _game.AddCards(notPlayer, _card.Object);

			Assert.IsFalse(result);
		}

		[Test]
		public void GetCards_ReturnsEmpty_PlayerDoesNotExist()
		{
			IPlayer notPlayer = new Mock<IPlayer>().Object;

			IEnumerable<ICard> result = _game.GetCards(notPlayer);

			Assert.IsFalse(result.Any());
		}

		[TestCaseSource(typeof(TCS),nameof(TCS.Data))]
		public void RemoveCard_CardRemovedSuccessfully_CardExists(IPlayer p, ICard card)
		{
			//_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));
			_game.AddCards(p, card);

			bool result = _game.RemoveCard(_player.Object, _card.Object);

			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(CardStatus.Removed), Times.Once);
			Assert.IsFalse(_game.GetCards(_player.Object).Contains(_card.Object));
		}
		[Test]
		public void AddCards_CardsAddedAndEventTriggered_PlayerExists()
		{
			//_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));
			bool eventTriggered = false;
			_game.OnCardUpdate += ((card) => eventTriggered = true);

			bool result = _game.AddCards(_player.Object, _card.Object);

			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(CardStatus.OnPlayer), Times.Once());
			Assert.IsTrue(eventTriggered);
			Assert.AreEqual(1, _game.GetCards(_player.Object).Count());
			Assert.IsTrue(_game.GetCards(_player.Object).Contains(_card.Object));
		}

		[Test]
		public void ChangeCardStatus_EventTriggered()
		{
			CardStatus newStatus = CardStatus.OnPlayer;
			//_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));

			bool eventTriggered = false;
			_game.OnCardUpdate += ((card) => eventTriggered = true);

			_game.ChangeCardStatus(_card.Object, newStatus);

			_card.Verify(c => c.SetStatus(newStatus), Times.Once);

			Assert.IsTrue(eventTriggered, "Fail because .... ");
		}
		class TCS 
		{
			public static object[] Data =
			{
				new object [] { _player.Object , _card.Object },
				new object [] { new Mock<IPlayer>().Object , _card.Object }
			};
		}
	}
}
