using System;
using Xunit;
using DodgeyMovieCo;

namespace XUnitTestDodgeyMovies
{
    public class Actor_Tests
    {
        Actor a1 = new DodgeyMovieCo.Actor();
       
        //these arent validated theorydata
       
        [Theory]
        [InlineData("Tony Barrett", "Tony", "Barrett")]
        public void setFullNameTest(string expected, string givenName, string surname)
        {
            Assert.Equal(expected, a1.setFullName(givenName, surname));

        }
    }
}
