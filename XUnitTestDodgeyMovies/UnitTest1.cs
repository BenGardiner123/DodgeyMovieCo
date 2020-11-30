using System;
using Xunit;
using DodgeyMovieCo;

namespace XUnitTestDodgeyMovies
{
    public class UnitTest1
    {
        Movie m1 = new DodgeyMovieCo.Movie();
        Actor a1 = new DodgeyMovieCo.Actor();

        [Theory]
        [InlineData(50, 12445)]
        [InlineData(20, 862)]
        [InlineData(17, 552)]
        public void NumActorsTest(int expected, int movieNum)
        {
            
            Assert.Equal(expected, m1.NumActors(movieNum));
            
        }

        //these arent validated theorydata
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(12, 12445)]
        [InlineData(13, 12445)]
        [InlineData(345, 12445)]
        [InlineData(-29, 12445)]
        public void MovieAgeTest(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));

        }

        [Fact]
        public void setFullNameTest()
        {

        }
    }
}
