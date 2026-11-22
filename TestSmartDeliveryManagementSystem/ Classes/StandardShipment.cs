using System;
using System.Collections.Generic;
using System.Text;
using TestSmartDeliveryManagementSystem.Interfaces;

namespace TestSmartDeliveryManagementSystem._Classes
{
    public class StandardShipment : Shipment1,ITrackable,IInsurable
    {
        private decimal hight;
        public StandardShipment(string Trackingcode, string Description, decimal WEight, decimal Deliveryfeeee, decimal Hight, DeliveryAddress1 destination) : base(Trackingcode, Description, WEight, Deliveryfeeee, destination)
        {
            hight = Hight;
        }
        
        public override decimal Estimatedcost{
            get { return DeliveryFee + (Weight * 5); }
            }

        public decimal CalculateInsurance()
        {
            return Estimatedcost * 0.05m;
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + "Is ready.";
        }

        public override void Printshipment()
        {
            Console.WriteLine("StandardShipment");

            base.PrintShipment();

            Console.WriteLine($"Hight:{hight}");
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }
    }
}