using SDIManagementSystem.Business;
using SDIManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDIManagementSystem.UI
{
    public partial class Car_Inventory : Form
    {
        private List<Car> listOfCars = CarXmlData.Load();
        private Dictionary<int,int> dictionary = new Dictionary<int, int>();
        public Car_Inventory()
        {
            InitializeComponent();
        }

        private int GetIndexFromDictionary()
        {
            int ListBoxIndex = lstCar.SelectedIndex;
            if (ListBoxIndex < 0)
            {
                return -1;
            }
            return dictionary[ListBoxIndex];
        }

        private bool AllFieldsAreOk()
        {
            if (cbCarType.Text == "")
            {
                MessageBox.Show("Please select a car type!");
                return false;
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name for the car!");
                return false;
            }
            else if (txtNOS.Text == "")
            {
                MessageBox.Show("Please input the number of seats!");
                return false;
            }
            else if (!Validator.ValidateNumber(txtNOS.Text))
            {
                MessageBox.Show("Please input a valid number of seats to proceed!");
                return false;
            }
            else if (txtBatteryName.Text == "" && cbCarType.Text == "Electric")
            {
                MessageBox.Show("Please enter the name of the battery!");
                return false;
            }
            else if (txtFuelName.Text == "" && cbCarType.Text == "Fuel")
            {
                MessageBox.Show("Please enter the name of the fuel!");
                return false;
            }
            return true;
        }

        private void RefreshDisplayList()
        {
            int ListCounter = 0;

            lstCar.Items.Clear();

            foreach (var car in listOfCars)
            {
                bool include = false;

                if (include)
                {
                    lstCar.Items.Add(car.ToString());
                }
                ListCounter++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AllFieldsAreOk())
            {
                return;
            }

            Car CarToAdd;

            if (cbCarType.Text == "Electric")
            {
                CarToAdd = new ElectricCar(txtFuelName.Text);
            }
            else
            {
                CarToAdd = new FuelCar(txtBatteryName.Text);
            }

            CarToAdd.Name = txtName.Text;
            CarToAdd.NumberOfSeats = Convert.ToInt32(txtNOS.Text);

            listOfCars.Add(CarToAdd);

            cbCarType.SelectedIndex = -1;
            txtName.Text = "";
            txtNOS.Text = "";
            txtBatteryName.Text = "";
            txtFuelName.Text = "";

            RefreshDisplayList();
            MessageBox.Show("The car has been added!");
        }

        private void cbCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCarType.Text == "Electric")
            {
                txtBatteryName.Enabled = true;
                txtFuelName.Enabled = false;
            }
            else if (cbCarType.Text == "Fuel")
            {
                txtFuelName.Enabled = true;
                txtBatteryName.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!AllFieldsAreOk())
            {
                return;
            }
            var carToUpdate = new ElectricCar();
            var carToUpdate2 = new FuelCar();
            if(carToUpdate is ElectricCar && cbCarType.Text == "Electric" ||
               carToUpdate2 is FuelCar && cbCarType.Text == "Fuel")
            {
                int listIndex = GetIndexFromDictionary();

                listOfCars.RemoveAt(listIndex);

                if (cbCarType.Text == "Electric")
                {
                    carToUpdate = new ElectricCar();
                }
                else
                {
                    carToUpdate2 = new FuelCar();
                }
                listOfCars.Insert(listIndex, carToUpdate);
                listOfCars.Insert(listIndex, carToUpdate2);

                carToUpdate.Name = txtName.Text;
                carToUpdate2.Name = txtName.Text;
                carToUpdate.NumberOfSeats = Convert.ToInt32(txtNOS.Text);
                carToUpdate2.NumberOfSeats = Convert.ToInt32(txtNOS.Text);

                RefreshDisplayList();

                MessageBox.Show("The list has been updated!");
            }
        }

        private void lstCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ListIndex = GetIndexFromDictionary();

            if (ListIndex < 0)
            {
                return;
            }

            var car = listOfCars[ListIndex];

            if (car is ElectricCar)
            {
                cbCarType.SelectedIndex = 0;
                var CarOfElectric = (ElectricCar)car;
            }
            else
            {
                cbCarType.SelectedIndex = 1;
                var CarOfFuel = (FuelCar)car;
            }

            txtName.Text = car.Name.ToString();
            txtNOS.Text = car.NumberOfSeats.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int Index = GetIndexFromDictionary();

            if (Index < 0)
            {
                MessageBox.Show("Please select a car to remove");
                return;
            }

            var Result = MessageBox.Show("Do you really want to remove?",
                                          "Confirmation",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                return;
            }

            listOfCars.RemoveAt(Index);
            lstCar.Items.RemoveAt(lstCar.SelectedIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CarXmlData.Save(listOfCars);
            MessageBox.Show("Your bike has been saved!");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string Item = lstCar.Text;
        }
    }
}
