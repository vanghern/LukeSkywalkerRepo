using System;
using LukeSkywalker;
using LukeSkywalker.Models.API;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest
    {
        [TestCase]
        public void GetLukeTest()
        {

            LukeSkywalkerData luke = new LukeSkywalkerData();
            Assert.AreEqual("Luke Skywalker", luke.GetLuke().name);
        }

        [TestCase]
        public void GetFilmCorretly()
        {

            LukeSkywalkerData luke = new LukeSkywalkerData();
            var film = new Film();
            film.title = "A New Hope";
            var testFilm = luke.GetFilm("https://swapi.dev/api/films/1/");
            Assert.AreEqual(film.title, testFilm.title); 
        }

        [TestCase]
        public void GetFilmWithNullUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();            
            var testFilm = luke.GetFilm("");
            Assert.AreEqual(null, testFilm.title);
        }

        [TestCase]
        public void GetFilmWithIncorrectUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();           
            var testFilm = luke.GetFilm("https://swapi.dev/api/people/1/");
            Assert.AreEqual(null, testFilm.title);
        }

        [TestCase]
        public void GetVehicleCorretly()
        {

            LukeSkywalkerData luke = new LukeSkywalkerData();
            var vehicle = new Vehicle();
            vehicle.name = "Snowspeeder";
            var testVehicle = luke.GetVehicle("https://swapi.dev/api/vehicles/14/");
            Assert.AreEqual(vehicle.name, testVehicle.name);
        }

        [TestCase]
        public void GetVehicleWithNullUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();
            var testVehicle = luke.GetVehicle("");
            Assert.AreEqual(null, testVehicle.name);
        }

        [TestCase]
        public void GetVehicleWithIncorrectUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();
            var testVehicle = luke.GetVehicle("https://swapi.dev/api/films/1/");
            Assert.AreEqual(null, testVehicle.name);
        }

        [TestCase]
        public void GetStarshipCorretly()
        {

            LukeSkywalkerData luke = new LukeSkywalkerData();
            var starship = new Starship();
            starship.name = "X-wing";
            var testStarship = luke.GetStarship("https://swapi.dev/api/starships/12/");
            Assert.AreEqual(starship.name, testStarship.name);
        }

        [TestCase]
        public void GetStarshipWithNullUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();
            var testStarship = luke.GetStarship("");
            Assert.AreEqual(null, testStarship.name);
        }

        [TestCase]
        public void GetStarshipWithIncorrectUrl()
        {
            LukeSkywalkerData luke = new LukeSkywalkerData();
            var testStarship = luke.GetStarship("https://swapi.dev/api/films/1/");
            Assert.AreEqual(null, testStarship.name);
        }
    }
}
