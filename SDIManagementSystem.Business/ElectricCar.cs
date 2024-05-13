using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIManagementSystem.Business
{
    public class ElectricCar : Car
    {
        private string _batteryName;

        public string BatteryName { get => _batteryName; set => _batteryName = value; }

        public override string ToString()
        {
            return $"Car Type: Electric, " + base.ToString() + ", Battery Name: " + BatteryName.ToString(); 
        }

        public ElectricCar() : base()
        {
            BatteryName = "";
        }

        public ElectricCar(string intialBatteryName) : this()
        {
            BatteryName = intialBatteryName;
        }
    }
}
