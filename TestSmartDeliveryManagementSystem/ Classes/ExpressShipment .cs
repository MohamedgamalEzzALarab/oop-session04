using System;
using System.Collections.Generic;
using System.Text;
using TestSmartDeliveryManagementSystem.Interfaces;

namespace TestSmartDeliveryManagementSystem._Classes
{
    public class ExpressShipment : Shipment1,ITrackable,IInsurable
    {
        private double extrafee;
        public ExpressShipment(string Trackingcode, string Description, decimal WEight, decimal Deliveryfeeee, double Extrafee, DeliveryAddress1 destination) : base(Trackingcode, Description, WEight, Deliveryfeeee, destination)
        {
            extrafee = Extrafee;
        }
        public decimal ExtraFee
        {
            get
            {
                return (decimal) extrafee;
            }
            set
            {
                if (value >= 0) {
                    ExtraFee = value;
                }
            }
        }

        public override decimal Estimatedcost => DeliveryFee + (decimal)(Weight * 5) + ExtraFee;

        public decimal CalculateInsurance()
        {
            return Estimatedcost * 0.08m;
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + "is Out for Delivery.";
        }

        public override void Printshipment()
        {
            Console.WriteLine("ExpressShipment");

            base.PrintShipment();

            Console.WriteLine($"Extrafee:{extrafee}");
            Console.WriteLine("Estimatedcost :" + Estimatedcost + "EGP ");
        }
    }
}
