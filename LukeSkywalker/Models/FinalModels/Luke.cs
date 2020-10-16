using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukeSkywalker.Models.Final_Models
{
    public class Luke
    {
        public Luke()
        {
            Films = new List<string>();
            Vehicles = new List<string>();
            Starships = new List<string>();
        }
        public string Name { get; set; }

        public List<string> Films { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Starships { get; set; }
    }
}
