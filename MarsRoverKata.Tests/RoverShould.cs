using MarsRoverKata.Domain;
using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverShould
    {
        private CommandExecutor _commandExecutor;

        [SetUp]
        public void SetUp()
        {
            _commandExecutor = new CommandExecutor();
        }

        [Test]
        public void EnsureThatItsStartingPositionIs00N()
        {
            Assert.That(_commandExecutor.Execute(""), Is.EqualTo("0:0:N"));
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void RotateRight(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("L", "0:0:W")]
        public void RotateLeft(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("M", "0:1:N")]
        [TestCase("MMMM", "0:4:N")]
        public void MoveNorth(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("MMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMMM", "0:2:N")]
        public void WrapFromTopToBottomWhenMovingUp(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("RM", "1:0:E")]
        [TestCase("RMMMMMMMMMMMMMM", "4:0:E")]
        public void MoveEast(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("LM", "9:0:W")]
        [TestCase("LMMM", "7:0:W")]
        public void MoveWest(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }

        [TestCase("LLM", "0:9:S")]
        [TestCase("LLMMM", "0:7:S")]
        public void MoveSouth(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }
        
        [TestCase("LRR", "0:0:E")]
        public void RotateLeftAndRight(string command, string position)
        {
            Assert.That(_commandExecutor.Execute(command), Is.EqualTo(position));
        }
    }
}