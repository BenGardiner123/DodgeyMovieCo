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



        //*************************************************** Movie TEST ********************************************************

        [Fact]

        public void NumActors_CheckType_Success()
        {
            Movie m1 = new DodgeyMovieCo.Movie()
            {
                ActorList = new System.Collections.Generic.List<Actor>() { }

            };
            Assert.IsType<int>(m1.NumActors());
        }

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

        public void NumActors_NotTheSame_Success()
        {
            Movie m1 = new DodgeyMovieCo.Movie()
            {
                ActorList = new System.Collections.Generic.List<Actor>() { }

            };
            Assert.NotEqual(1, m1.NumActors());

        }

        [Fact]
    

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

       

        //*************************************************** Actor TEST ********************************************************


        
       [Fact]

        public void MovieAge_CheckIntReturned_Success()
        {
            Movie movietest = new Movie()
            {
                ReleaseYear = 1888
            };

            //something like IsInt()?
            Assert.IsType<int>(movietest.GetAge());
        }

        
        [Fact]

        public void MovieAge_CheckAge_Success()
        {
            Movie movietest = new Movie()
            {
                ReleaseYear = 1888
            };

            //something like IsInt()?
            Assert.Equal(132, movietest.GetAge());
        }

        [Fact]

        public void MovieAge_CheckAgeUnequal_Success()
        {
            Movie movietest = new Movie()
            {
                ReleaseYear = 1888
            };

            //something like IsInt()?
            Assert.NotEqual(1323, movietest.GetAge());
        }

     

    }
}
