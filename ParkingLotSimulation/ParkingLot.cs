using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    class ParkingLot
    {
        static List<ParkingSpot> parkingSpots;

        public ParkingLot()
        {
            parkingSpots = new List<ParkingSpot>();

            for (int i = 100; i <= 110; i++)
            {
                parkingSpots.Add(new CarParkingSpot(i));
            }

            for (int i = 200; i <= 210; i++)
            {
                parkingSpots.Add(new BikeParkingSpot(i));
            }

        }

        public static ParkingSpot FindFreeSlot(Vehicle vehicle)
        {
            return parkingSpots.Find(p => p.VehicleType == vehicle.VehicleType && p.IsAvailable == true);
        }

        public static ParkingSpot FindBookedSlot(Vehicle vehicle)
        {
            return parkingSpots.Find(p => p.Vehicle.VehicleNumber == vehicle.VehicleNumber);
        }
    }

    public class ParkingSpot
    {
        public bool IsAvailable { get; set; }
        public string VehicleType { get; set; }
        public Vehicle Vehicle { get; set; }
        public int SlotId { get; set; }
        public double ParkingFee { get; set; }
        public ParkingMeter Meter { get; set; }
        
        public void Park(ParkingLotSimulation.Vehicle vehicle)
        {
            ParkingSpot ps = ParkingLot.FindFreeSlot(vehicle);
            if (ps != null)
            {
                ps.IsAvailable = false;
                ps.Vehicle = vehicle;
                ps.Meter.parkedTime = DateTime.Now;
                Console.WriteLine("{0} (No : {1}) Parked Successfully at Slot Id : {2}", vehicle.VehicleType, vehicle.VehicleNumber, ps.SlotId);
                Console.WriteLine("Press any key to Exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No SLots available for Parking");
                Console.WriteLine("Press any key to Exit");
                Console.ReadKey();
            }
            return;
        }

        public void UnPark(ParkingLotSimulation.Vehicle vehicle)
        {
            ParkingSpot ps = ParkingLot.FindBookedSlot(vehicle);
            if (ps != null)
            {
                ps.IsAvailable = true;
                ps.Meter.AmoutPayable(ps);
                Console.WriteLine("{0} Number : {1} UnParked Successfully from Slot ID : {2}", ps.VehicleType, vehicle.VehicleNumber, ps.SlotId);
                ps.Vehicle.VehicleNumber = null;
                Console.WriteLine("Press any Key to goto Welcome Screen");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Vehicle with Number : {0} Not Found", vehicle.VehicleNumber);
                Console.WriteLine("Press any Key to goto Welcome Screen");
                Console.ReadKey();
            }
            return;  
        }
    }

    public class CarParkingSpot : ParkingSpot
    {
        public CarParkingSpot(int slotId)
        {
            this.IsAvailable = true;
            this.VehicleType = "Car";
            this.SlotId = slotId;
            this.ParkingFee = 25;
            this.Meter = new ParkingMeter();
        }
    }

    public class BikeParkingSpot : ParkingSpot
    {

        public BikeParkingSpot(int slotId)
        {
            this.IsAvailable = true;
            this.VehicleType = "Bike";
            this.SlotId = slotId;
            this.ParkingFee = 10;
            this.Meter = new ParkingMeter();
        }
    }

    public class Vehicle
    {
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
    }

    public class ParkingMeter
    {
        public DateTime parkedTime { get; set; }

        internal void AmoutPayable(ParkingSpot ps)
        {
            int totalTime = (DateTime.Now - ps.Meter.parkedTime).Minutes;
            Console.WriteLine("Total Minutes {0} (No : {1}) Parked is : {2} Minutes", ps.VehicleType,ps.Vehicle.VehicleNumber, totalTime);

            
            double amountPayable = (totalTime * ps.ParkingFee) / 60;

            Console.WriteLine("Total Amount Payable is : ${0}", amountPayable);
        }

    }
}
