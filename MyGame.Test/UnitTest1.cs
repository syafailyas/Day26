using MyGame;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MyGame.Test
{
	public class GameControllerTests
	{
		private GameController _cut;
		private Mock<IPlayer> _player;
		private Mock<ICard> _card;
		private Mock<IBoard> _board;

		[SetUp]
		public void Setup()
		{
			_player = new Mock<IPlayer>();
			_card = new Mock<ICard>();
			_board = new Mock<IBoard>();
			_cut = new GameController(_player.Object, _board.Object);
		}

		[Test]
		public void AddCards_CardsAddedSuccessfullyReturnsTrue_PlayerExists()
		{
			_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));

			bool result = _cut.AddCards(_player.Object, _card.Object);

			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(It.IsAny<CardStatus>()), Times.Once);
		}
		[Test]
		public void AddCards_ReturnsFalse_PlayerNotExists()
		{
			IPlayer notPlayer = new Mock<IPlayer>().Object;

			bool result = _cut.AddCards(notPlayer, _card.Object);
			
			Assert.IsFalse(result);
		}

		[Test]
		public void GetCards_ReturnsEmpty_PlayerDoesNotExist()
		{
			IPlayer notPlayer = new Mock<IPlayer>().Object;

			IEnumerable<ICard> result = _cut.GetCards(notPlayer);

			Assert.IsFalse(result.Any());
		}

		[Test]
		public void RemoveCard_CardRemovedSuccessfully_CardExists()
		{
			_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));
			_cut.AddCards(_player.Object, _card.Object);

			bool result = _cut.RemoveCard(_player.Object, _card.Object);
			
			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(CardStatus.Removed), Times.Once);
			Assert.IsFalse(_cut.GetCards(_player.Object).Contains(_card.Object));
		}
		[Test]
		public void AddCards_CardsAddedAndEventTriggered_PlayerExists()
		{
			_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));
			bool eventTriggered = false;
			_cut.OnCardUpdate += (card) => eventTriggered = true;

			bool result = _cut.AddCards(_player.Object, _card.Object);
			
			Assert.IsTrue(result);
			_card.Verify(c => c.SetStatus(It.Is<CardStatus>(s => s == CardStatus.OnPlayer)), Times.Once());
			Assert.IsTrue(eventTriggered);
			Assert.AreEqual(1, _cut.GetCards(_player.Object).Count());
			Assert.IsTrue(_cut.GetCards(_player.Object).Contains(_card.Object));
		}
		
		[Test]
		public void ChangeCardStatus_EventTriggered()
		{
			CardStatus newStatus = CardStatus.OnPlayer;
			_card.Setup(c => c.SetStatus(It.IsAny<CardStatus>()));
			bool eventTriggered = false;
			_cut.OnCardUpdate += (card) => eventTriggered = true;
			
			_cut.ChangeCardStatus(_card.Object, newStatus);

			_card.Verify(c => c.SetStatus(newStatus), Times.Once);
			Assert.IsTrue(eventTriggered, "Fail because ");
		}
	}
}
