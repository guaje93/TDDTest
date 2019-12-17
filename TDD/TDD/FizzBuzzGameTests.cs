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
        public void Should_throw_invalid_argument_exception_when_input_is_lower_than_0()
        {
            //arrange
            var game = new FizzBuzzGame();
            //act
            //assert
            Assert.Throws<InvalidArgumentException>(() =>game.Play(-1));
        }
    }
}
