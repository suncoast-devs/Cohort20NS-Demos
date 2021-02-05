using System;
using System.Collections.Generic;
using Colors.Net;
using Colors.Net.StringColorExtensions;
using DotnetIteration.Models;

namespace DotnetIteration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Yelling();
            Console.WriteLine();
            Double();
            Console.WriteLine();
            StringyIndexes();
            Console.WriteLine();
            OnlyTheEvenSurvive();
            Console.WriteLine();
            OnlyTheEvenIndexedSurvive();
            Console.WriteLine();
            BestMovieOfTheYear();
            Console.WriteLine();
            EveryoneIsOdd();
            Console.WriteLine();
            FindTheNeedle();
            Console.WriteLine();
            FindTheNeedleIndex();
            Console.WriteLine();
            SomeoneToLove();
            Console.WriteLine();
        }

        public static void Passed(string method, string message = "")
        {
            ColoredConsole.WriteLine($"PASSED    {method.PadRight(32)} {message}".Green());
        }

        public static void Failed(string method, string message = "")
        {
            ColoredConsole.WriteLine($"FAILED    {method.PadRight(32)} {message}".Red());
        }

        public static void NotImplemented(string method)
        {
            ColoredConsole.WriteLine($"SKIPPED!  {method.PadRight(32)} Remove/comment the throw new System.NotImplementedException(). Replace that line with your own code.".Yellow());
        }

        public static void CompareLists<T>(IEnumerable<T> expected, IEnumerable<T> actual, string method)
        {
            var expectedString = String.Join(", ", expected);
            var actualString = String.Join(", ", actual);

            if (expectedString == actualString)
            {
                Passed(method, "");
            }
            else
            {
                Failed(method, $"Received {{{actualString}}} when expecting {{{expectedString}}}");
            }
        }


        public static void Yelling()
        {
            try
            {
                var data = new List<string> { "now", "is", "the", "best", "time" };

                var expected = new List<string> { "NOW", "IS", "THE", "BEST", "TIME" };
                var actual = Iteration.Yelling(data);

                CompareLists(expected, actual, "Yelling");
            }
            catch (System.Exception)
            {
                NotImplemented("Yelling");
            }
        }

        public static void Double()
        {
            try
            {
                var expected = new List<int> { 2, 4, 6, 8, 10 };
                var data = new List<int> { 1, 2, 3, 4, 5 };
                var actual = Iteration.Double(data);

                CompareLists(expected, actual, "Double");
            }
            catch (System.Exception)
            {
                NotImplemented("Double");
            }
        }

        public static void StringyIndexes()
        {
            try
            {
                var data = new List<string> { "how", "now", "brown", "cow" };
                var expected = new List<string> {
                   "how is at index 0",
                   "now is at index 1",
                   "brown is at index 2",
                   "cow is at index 3"
                };
                var actual = Iteration.StringyIndexes(data);

                CompareLists(expected, actual, "StringyIndexes");
            }
            catch (System.Exception)
            {
                NotImplemented("StringyIndexes");
            }
        }

        public static void OnlyTheEvenSurvive()
        {
            try
            {
                var data = new List<int> { 42, 50, 100, 5, -43, 17, 44 };
                var expected = new List<int> { 42, 50, 100, 44 };
                var actual = Iteration.OnlyTheEvenSurvive(data);

                CompareLists(expected, actual, "OnlyTheEvenSurvive");
            }
            catch (System.Exception)
            {
                NotImplemented("OnlyTheEvenSurvive");
            }
        }

        public static void OnlyTheEvenIndexedSurvive()
        {
            try
            {
                var data = new List<int> { 31, 67, 64, 96, 14, 24, 43, 51, 48, 80, 58, 43, 64, 84, 98, 99, 69, 93, 5, 32, 29, 4, 28, 18, 86, 22, 20, 74, 35, 27, 85, 79, 65, 32, 56, 94, 93, 20, 29, 22, 72 };
                var expected = new List<int> { 31, 64, 14, 43, 48, 58, 64, 98, 69, 5, 29, 28, 86, 20, 35, 85, 65, 56, 93, 29, 72 };
                var actual = Iteration.OnlyTheEvenIndexedSurvive(data);

                CompareLists(expected, actual, "OnlyTheEvenIndexedSurvive");
            }
            catch (System.Exception)
            {
                NotImplemented("OnlyTheEvenIndexedSurvive");
            }
        }

        public static void BestMovieOfTheYear()
        {
            try
            {
                var data = new List<Movie> {
                   new Movie { Name= "The Grand Budapest Hotel", Year = 2014, Score= 91 },
                   new Movie { Name= "Birdman", Year = 2014, Score= 91 },
                   new Movie { Name= "Transformers: Age of Extinction", Year = 2014, Score= 18 },
                   new Movie { Name= "Rage", Year = 2014, Score= 14 },
                   new Movie { Name= "Get Out", Year = 2017, Score= 99 },
                   new Movie { Name= "Justice League", Year = 2017, Score= 40 },
                   new Movie { Name= "Ghost in the Shell", Year = 2017, Score= 46 },
                   new Movie { Name= "The Big Sick", Year = 2017, Score= 98 }

                   };
                var movies2014 = new List<string> { "The Grand Budapest Hotel", "Birdman" };
                var movies2017 = new List<string> { "Get Out", "The Big Sick" };
                var movies2001 = new List<string> { };

                var actualMovies2014 = Iteration.BestMovieOfTheYear(data, 2014);
                var actualMovies2017 = Iteration.BestMovieOfTheYear(data, 2017);
                var actualMovies2001 = Iteration.BestMovieOfTheYear(data, 2001);

                CompareLists(movies2014, actualMovies2014, "BestMovieOfTheYear in 2014");
                CompareLists(movies2017, actualMovies2017, "BestMovieOfTheYear in 2017");
                CompareLists(movies2001, actualMovies2001, "BestMovieOfTheYear in 2001");
            }
            catch (System.Exception)
            {
                NotImplemented("BestMovieOfTheYear");
            }
        }

        public static void EveryoneIsOdd()
        {
            try
            {
                var trueData = new List<int> { 9, 15, 27, 101, 33 };
                var falseData = new List<int> { 9, 23, 3, 4, 77 };

                if (Iteration.EveryoneIsOdd(trueData))
                {
                    Passed("EveryoneIsOdd for odds");
                }
                else
                {
                    Failed("EveryoneIsOdd for odds");
                }

                if (!Iteration.EveryoneIsOdd(falseData))
                {
                    Passed("EveryoneIsOdd for evens");
                }
                else
                {
                    Failed("EveryoneIsOdd for evens");
                }
            }
            catch (System.Exception)
            {
                NotImplemented("EveryoneIsOdd");
            }
        }

        public static void FindTheNeedle()
        {
            try
            {
                var data = new List<string> { "one", "time", "there was a needle at", "the market" };
                var expected = "there was a needle at";
                if (expected == Iteration.FindTheNeedle(data))
                {
                    Passed("FindTheNeedle");
                }
                else
                {
                    Failed("FindTheNeedle");
                }
            }
            catch (System.Exception)
            {
                NotImplemented("FindTheNeedle");
            }
        }

        public static void FindTheNeedleIndex()
        {
            try
            {
                var data = new List<string> { "one", "time", "there was a needle at", "the market" };
                var expected = 2;
                if (expected == Iteration.FindTheNeedleIndex(data))
                {
                    Passed("FindTheNeedleIndex");
                }
                else
                {
                    Failed("FindTheNeedleIndex");
                }
            }
            catch (System.Exception)
            {
                NotImplemented("FindTheNeedleIndex");
            }
        }

        public static void SomeoneToLove()
        {
            try
            {
                var falseData = new List<string> { "how", "now", "brown", "cow" };
                var trueData = new List<string> { "how", "now", "blue", "cow" };

                if (Iteration.SomeoneToLove(trueData))
                {
                    Passed("SomeoneToLove");
                }
                else
                {
                    Failed("SomeoneToLove");
                }

                if (!Iteration.SomeoneToLove(falseData))
                {
                    Passed("SomeoneToLove");
                }
                else
                {
                    Failed("SomeoneToLove");
                }
            }
            catch (System.Exception)
            {
                NotImplemented("SomeoneToLove");
            }
        }
    }
}
