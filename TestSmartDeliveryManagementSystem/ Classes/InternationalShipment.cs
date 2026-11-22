using System;
using System.Collections.Generic;
using System.Text;
using TestSmartDeliveryManagementSystem.Interfaces;

namespace TestSmartDeliveryManagementSystem._Classes
{
    public class InternationalShipment : Shipment1,ITrackable,IInsurable
    {
        private string destinationcountry;
        private decimal customsfee;
        public InternationalShipment(string TrackingCode, string Description, decimal WEight, decimal Deliveryfeeee, decimal Customsfee, DeliveryAddress1 destination, string Destinationcountry) : base(TrackingCode, Description, WEight, Deliveryfeeee, destination)
        {
            destinationcountry = Destinationcountry;
            customsfee = Customsfee;
        }
        public string DestinationCountry
        {
            get { return destinationcountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    DestinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get { return customsfee; }
            set
            {
                if(value >= 0)
                {
                    CustomsFee = value;
                }
            }
        }

        public override decimal Estimatedcost => DeliveryFee + (Weight * 5) + CustomsFee;

        public decimal CalculateInsurance()
        {
            return Estimatedcost * 0.012m;
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + "has been Delivered.";
        }

        public override void Printshipment()
        {
            Console.WriteLine("InternationalShipment");

            base.PrintShipment();

            Console.WriteLine($"Destinationcountry:{destinationcountry}");

            Console.WriteLine($"CustomsFee:{customsfee}");

            Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Customs report for " + TrackingCode + " - Customs Fee: " + CustomsFee + " EGP");
        }
    }
}
