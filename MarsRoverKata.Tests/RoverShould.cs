using System.Collections.Generic;
using MarsRoverKata.Domain;
using NUnit.Framework;

namespace MarsRoverKata.Tests
{
    [TestFixture]
    public class RoverShould
    {
        private Rover _rover;

        [SetUp]
        public void SetUp()
        {
            _rover = new Rover(new CommandsMapper());
        }

        [Test]
        public void Ensure_That_Its_Starting_Position_Is_00N()
        {
            Assert.That(_rover.Execute(""), Is.EqualTo("0:0:N"));
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void Rotate_Right(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("L", "0:0:W")]
        public void Rotate_Left(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("M", "0:1:N")]
        [TestCase("MMMM", "0:4:N")]
        public void Move_North(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("MMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMMM", "0:2:N")]
        public void Wrap_From_Top_To_Bottom_When_Moving_Up(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("RM", "1:0:E")]
        [TestCase("RMMMMMMMMMMMMMM", "4:0:E")]
        public void Move_East(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("LM", "9:0:W")]
        [TestCase("LMMM", "7:0:W")]
        public void Move_West(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("LLM", "0:9:S")]
        [TestCase("LLMMM", "0:7:S")]
        public void Move_South(string command, string position)
        {
            Assert.That(_rover.Execute(command), Is.EqualTo(position));
        }

        [TestCase("MMMM", "0:3:N")]
        public void StopAtObstacle(string inputCommand, string expectedOutput)
        {
            var obstacles = new List<Coordinate>
            {
                new Coordinate(0, 4)
            };
            var rover = new Rover(new CommandsMapper(obstacles));

            Assert.AreEqual(expectedOutput, rover.Execute(inputCommand));
        }
    }
}