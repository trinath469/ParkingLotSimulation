using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotSimulation;

namespace ParkingLotSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot obj = new ParkingLot();
            WelcomeScreen();

            Console.ReadLine();
        }

        private static void WelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Select the Option");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Park a Vehicle      2. Unpark a Vehicle");
            SelectOption();
            WelcomeScreen();
            return;
        }

        private static void SelectOption()
        {
            int userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                ChooseVehicleType();
                return;
            }
            else if (userChoice == 2)
            {
                UnParkVehicle();
                return;
            }
            else
            {
                Console.WriteLine("Enter the Correct Option : ");
                SelectOption();
            }
        }

        public static void ChooseVehicleType()
        {
            Console.Clear();
            Console.WriteLine("Select Vehicle Type ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Four Wheeler       2. Two Wheeler      3. Welcome Screen");
            var option = Console.ReadLine();

            if (option == "1")
            {
                Vehicle vehicle = new Vehicle();
                Console.Write("Enter the Vehicle Number : ");
                vehicle.VehicleNumber = Console.ReadLine();
                vehicle.VehicleType = "Car";
                ParkingSpot parkingSpot = new ParkingSpot();
                parkingSpot.Park(vehicle);
            }

            else if (option == "2")
            {
                Vehicle vehicle = new Vehicle();
                Console.Write("Enter the Vehicle Number : ");
                vehicle.VehicleNumber = Console.ReadLine();
                vehicle.VehicleType = "Bike";
                ParkingSpot parkingSpot = new ParkingSpot();
                parkingSpot.Park(vehicle);
            }
            else if (option == "3")
            {
                Console.WriteLine("Enter the Correct Option ");
                ChooseVehicleType();
            }

            return;
        }

        public static void UnParkVehicle()
        {
            Vehicle vehicle = new Vehicle();
            Console.Write("Enter the Vehicle Number : ");
            vehicle.VehicleNumber = Console.ReadLine();
            ParkingSpot parkingSpot = new ParkingSpot();
            parkingSpot.UnPark(vehicle);
        }
    }
}
