using System;
using Xunit;
using DodgeyMovieCo;
using DodgeyMovieCo.Models;

namespace XUnitTestDodgeyMovies
{
    public class Movie_Tests
    {
        Movie m1 = new DodgeyMovieCo.Movie();
        DodgeyMovieCo.Models.Casting c1 = new DodgeyMovieCo.Models.Casting();



        //*************************************************** TEST NUMBER 1 ********************************************************

        //Test 1 Case 1 - Check that the function returns an int?

        
       
        
        [Fact]

        public void NumActors_CheckReturned_Success()
        {
            Movie m1 = new DodgeyMovieCo.Movie()
            {
                ActorList = new System.Collections.Generic.List<Actor>() { }

            };
            Assert.Equal(0, m1.NumActors());

        }

        [Fact]
        //Test 1 Case 2 - add 3 actors to the list - returns three

        public void NumActors_Add3_returns3()
         {
            Movie m1 = new DodgeyMovieCo.Movie()
            {
                ActorList = new System.Collections.Generic.List<Actor>() 
                {
                    new Actor()
                    {
                        ActorNo = 7743,
                        FullName = "Pedro Ximinez",
                        GivenName = "Pedro",
                        Surname = "Ximinez"
                        
                    },
                      new Actor()
                    {
                        ActorNo = 7742,
                        FullName = "Daniel Ortega",
                        GivenName = "Daniel",
                        Surname = "Ortega"

                    },
                        new Actor()
                    {
                        ActorNo = 7744,
                        FullName = "Tomas Borge",
                        GivenName = "Tomas",
                        Surname = "Borge"

                    }
                }

            };

            Assert.Equal(3, m1.NumActors());

         }

       

        //*************************************************** TEST NUMBER 2 ********************************************************


        /*//Test 2  case 1  - Check that the function returns an int?
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAge_CheckIntReturned_Success(int expected, int movieNum)
        {
            //something like IsInt()?
            Assert.Equal(expected, m1.GetAge(movieNum));
        }

        //Test 2  case 2  - Happy Test - information entered is in the db correct output
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAge_CorrectInput_CorreectOutput(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));
        }

        //Test 2  case 3 - Input is a spcial char or NaN- should throw an exception
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAge_InputNaN_ThrowsEx(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));
        }

        //Test 2  Case 4 - Input is a number - but a negative one
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAge_InputNegNum_ThrowsEx(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));
        }

        //Test 2  Case 5 - Input is outside range of int
        [Theory]
        [InlineData(50, 12445)]
        [InlineData(-29, 12445)]

        public void MovieAge_InputOutsideRange_ThrowsEx(int expected, int movieNum)
        {
            Assert.Equal(expected, m1.GetAge(movieNum));
        }*/

    }
}
