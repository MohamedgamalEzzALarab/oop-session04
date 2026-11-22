using System;
using System.Collections.Generic;
using System.Text;
using TestSmartDeliveryManagementSystem.Interfaces;

namespace TestSmartDeliveryManagementSystem._Classes
{
    public class DeliveryCenter1
    {
        public string CenterName = default!;
        private Shipment1[] Shipments2 = new Shipment1[20];
        private int count = 0;
        public Driver? AssignedDriver { get; set; }
        public Shipment1 this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return Shipments2[index];

                return default;
            }
            set
            {
                if (index >= 0 && index < count)
                    Shipments2[index] = value;
            }
        }
        public Shipment1 this[string trackingcode]
        {
            get
            {
                if (Shipments2 != null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (Shipments2[i]?.TrackingCode == trackingcode)
                            return Shipments2[i];
                    }
                }
                return null;
            }
        }
        public bool AddShipment(Shipment1 shipment)
        {
            if (count >= Shipments2.Length)
                return false;

           Shipments2[count] = shipment;
            count++;
              return true;
        }
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < count; i++)
            {
                if (Shipments2[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        Shipments2[j] = Shipments2[j + 1];
                    }
                    count--;
                    Shipments2[count] = null;
                    return true;
                }
            }
            return false;
        }
        public void PrintAllShipments()
        {
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine();
                }
                Shipments2[i].PrintShipment();
            }
            //Shipment1[] shipmenttypes =
            //{
            //    new StandardShipment("ss22","OPPO",2,30,3,new DeliveryAddress1("Sohag","Saqolta",2)),
            //    new ExpressShipment("BB23","Realme",5,20,30.5,new DeliveryAddress1("Sohag","Saqolta",8)),
            //    new InternationalShipment("ss25","Samsoung",4,60,2,new DeliveryAddress1("Sohag","Saqolta",5),"Egypt")
            //};

            //foreach(Shipment1 Ship in shipmenttypes){
            //    Ship.PrintShipment();
            //    Console.WriteLine(Ship.EstimatedCost);
            //}
        }
        public void PrintTrackingStatuses()
        {
            for (int i = 0; i < count; i++)
            {
                ITrackable trackable = Shipments2[i] as ITrackable;
                if (trackable != null)
                    Console.WriteLine(trackable.GetTrackingStatus());
                Console.WriteLine();
            }
        }
    }
}