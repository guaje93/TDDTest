using System;

namespace TDD
{
    internal class FizzBuzzGame
    {
        public FizzBuzzGame()
        {
        }

        internal string Play(int input)
        {
            if (DivisibleBy15(input))
                return "Fizz buzz";
            if (DivisibleBy3(input))
                return "Fizz";
            if (DivisibleBy5(input))
                return "Buzz";
            return input.ToString();
        }

        private static bool DivisibleBy5(int input)
        {
            return DivisibleValue(input, 5);
        }


        private static bool DivisibleBy3(int input)
        {
            return DivisibleValue(input, 3);
        }

        private static bool DivisibleBy15(int input)
        {
            return DivisibleValue(input, 15);

        }
        private static bool DivisibleValue(int input, int divisor)
        {
            return input % divisor == 0;
        }
    }
}