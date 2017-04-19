using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public enum AnimalType
    {
        Dog,
        Cat
    }

    public class Animal
    {
        public string Name { get; set; }
        
        public AnimalType Type { get; set; }

        public DateTime TimeOfArrival { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
