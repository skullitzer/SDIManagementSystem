using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDIManagementSystem.Business
{
    public abstract class Car
    {
        [Serializable]
        [XmlInclude(typeof(ElectricCar))]
        [XmlInclude(typeof(FuelCar))]
        private string _name;
        private int _numberOfSeats;

        public string Name { get => _name; set => _name = value; }
        public int NumberOfSeats { get => _numberOfSeats; set => _numberOfSeats = value; }

        public Car()
        {
            _name = "";
            _numberOfSeats = 0;
        }

        public override string ToString()
        {
            return $"Name: {_name}, Number of Seats: {_numberOfSeats}";
        }
    }
}
