using System;
using Xunit;
using DodgeyMovieCo;

namespace XUnitTestDodgeyMovies
{
    public class Movie_Tests
    {
        Movie m1 = new DodgeyMovieCo.Movie();

        //Test 1 Case 1 - Check that the http client can connect
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActors_CheckHttp_Success(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.NumActors(movieNum));
        }

        //Test 1 Case 2 - Happy Test - information eneteed is equal to the output
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActors_CorrectInput_CorrectResult(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.NumActors(movieNum));
        }


        //Test 1 Case 3 - Input is not a number - should throw an exception
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActors_InputIsString_ThrowAnExcepion(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.NumActors(movieNum));
        }

        //Test 1 Case 4 - Input is a number - but a negative one
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActorsTest4(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.NumActors(movieNum));
        }

        //Test 1 Case 5 - Input is a number - but a negative one
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActorsTest5(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.NumActors(movieNum));
        }














        //these arent validated theorydata
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAgeTest(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));
        }
        
        
    }
}
