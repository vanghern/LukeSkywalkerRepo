using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeSkywalker.Models.API
{
    public class People
    {
        public People()
        {
            films = new List<string>();
            starships = new List<string>();
            vehicles = new List<string>();
        }
        public string name { get; set; }

        public List<string> films;
        public List<string> starships;
        public List<string> vehicles;
    }
}
