using LukeSkywalker.Helpers;
using LukeSkywalker.Models.API;
using LukeSkywalker.Models.Final_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LukeSkywalker
{

    public class LukeSkywalkerData
    {
        static HttpClient client = new HttpClient();
        public People Luke;
        public Luke LukeFinalForm;
        public Logger Logger;
        public LukeSkywalkerData()
        {
            Luke = new People();
            LukeFinalForm = new Luke();
            Logger = new Logger();

            #region Http Client     
            try
            {
                Logger.AddLog("Begin HTTP Client Initialization. May the force be with you.");
                client.BaseAddress = new Uri("https://swapi.dev/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Logger.AddLog("HTTP Client Initialization Succesfull");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }

            #endregion

            // API Calls
            #region API Calls

            // Luke
            try
            {
                Luke = GetLuke();
                Logger.AddLog("Connected with Luke Skywalker");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }
            LukeFinalForm.Name = Luke.name;

            // Films
            try
            {
                foreach (var film in Luke.films)
                {
                    var filmName = GetFilm(film);
                    LukeFinalForm.Films.Add(filmName.title);
                }
                Logger.AddLog("All films obtained.");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }

            // Vehicles

            try
            {
                foreach (var vehicle in Luke.vehicles)
                {
                    var vehicleName = GetVehicle(vehicle);
                    LukeFinalForm.Vehicles.Add(vehicleName.name);
                }
                Logger.AddLog("All vehicles obtained.");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }

            // Starships
            try
            {
                foreach (var starship in Luke.starships)
                {
                    var starshipName = GetStarship(starship);
                    LukeFinalForm.Starships.Add(starshipName.name);
                }
                Logger.AddLog("All starships obtained.");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }



            #endregion

            // Save operations to file

            try
            {
                SaveToFileInRootDirectory();
                Logger.AddLog("Luke Skywalker saved in root directory");
            }
            catch (Exception e)
            {
                Logger.AddLog("I have bad feelings about this. " + e.Message + e.InnerException);
                Logger.SaveLogsToFile();
            }

            // Save logs

            Logger.SaveLogsToFile();


        }

        // Get Luke from API
        public People GetLuke()
        {

            People luke = null;
            var lukePath = client.BaseAddress + "people/1/";
            var response = client.GetAsync(lukePath).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            luke = JsonConvert.DeserializeObject<People>(responseStr);
            Logger.AddLog("Luke Skywalker data successfully downloaded");
            return luke;
        }

        // Get Films from API
        public Film GetFilm(string uri)
        {
            Film film = null;
            var response = client.GetAsync(uri).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            film = JsonConvert.DeserializeObject<Film>(responseStr);
            Logger.AddLog("Film data successfully downloaded");
            return film;
        }

        // Get Vehicles from API
        public Vehicle GetVehicle(string uri)
        {
            Vehicle vehicle = null;
            var response = client.GetAsync(uri).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            vehicle = JsonConvert.DeserializeObject<Vehicle>(responseStr);
            Logger.AddLog("Vehicle data successfully downloaded");
            return vehicle;
        }

        // Get Starships from API
        public Starship GetStarship(string uri)
        {
            Starship starship = null;
            var response = client.GetAsync(uri).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            starship = JsonConvert.DeserializeObject<Starship>(responseStr);
            Logger.AddLog("Starship data successfully downloaded");
            return starship;
        }

        // Save to txt file in application root directory
        public void SaveToFileInRootDirectory()
        {
            var lukeJson = JsonConvert.SerializeObject(LukeFinalForm);
            var fileName = "Luke Skywalker.txt";
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName,
                   lukeJson);
            Logger.AddLog("Data has been written to file");

        }
    }
}
