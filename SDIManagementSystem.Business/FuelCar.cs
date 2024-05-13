using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIManagementSystem.Business
{
    public class FuelCar : Car
    {
        private string _fuelName;

        public string FuelName { get => _fuelName; set => _fuelName = value; }

        public override string ToString()
        {
            return $"Car Type: Fuel, " + base.ToString() + ", Fuel Name: " + _fuelName.ToString(); 
        }

        public FuelCar() : base()
        {
            _fuelName = "";
        }

        public FuelCar(string intialFuelName) : base()
        {
            _fuelName = intialFuelName;
        }
    }
}
