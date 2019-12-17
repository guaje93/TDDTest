using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TDD
{
    public class FizzBuzzGameTests
    {
        public FizzBuzzGameTests()
        {

        }

        [Theory,
            InlineData(1, "1"),
        InlineData(2, "2"),
        InlineData(3, "Fizz"),
        InlineData(5, "Buzz"),
        InlineData(15, "Fizz buzz")]
        public void Should_return_values_according_to_FizzBuzz_games_roles(int input, string expected)
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            var result = game.Play(input);
            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void When_input_is_2_should_return_two()
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            var result = game.Play(2);
            //assert
            Assert.Equal("2", result);
        }
        [Fact]
        public void When_input_is_3_should_return_Fizz()
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            var result = game.Play(3);
            //assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void When_input_is_5_should_return_Buzz()
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            var result = game.Play(5);
            //assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void When_input_is_15_should_return_Fizz_Buzz()
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            var result = game.Play(15);
            //assert
            Assert.Equal("Fizz buzz", result);
        }
    }
}
