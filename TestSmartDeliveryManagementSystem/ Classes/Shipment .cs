using System.Reflection.Metadata.Ecma335;
using TestSmartDeliveryManagementSystem;
using TestSmartDeliveryManagementSystem._Classes;
using TestSmartDeliveryManagementSystem.Interfaces;

public abstract class Shipment1
{
    private string trackingcode = default!;
    private string dEscription = default!;
    private decimal weiGht;
    private decimal DEiveryFee;

    public Shipment1(string Trackingcode, string description)
	{
        TrackingCode = Trackingcode;
        Description = description;
	}
    public Shipment1(decimal WEight, decimal Deliveryfeeee, DeliveryAddress1 destination)
    {
        Weight = WEight;
        DeliveryFee = Deliveryfeeee;
        Destination = destination;
    }
    public Shipment1(string trackingCode, string description, decimal WEight, decimal Deliveryfeeee, DeliveryAddress1 destination)
    {
        if (string.IsNullOrWhiteSpace(trackingCode))
            throw new ArgumentException("TrackingCode Can Not Be Empty.", nameof(trackingCode));

        TrackingCode = trackingCode.Trim(); /*TrackingCode; string.IsNullOrWhiteSpace(TrackingCode) ? "UnKnown" : TrackingCode*/
        Description = string.IsNullOrWhiteSpace(Description) ? "UnKnown" : Description; /*string.IsNullOrWhiteSpace(Description) ? "UnKnown" : Description*/
        Weight = WEight > 0 ? WEight : 1;
        DeliveryFee = Deliveryfeeee > 0 ? Deliveryfeeee : 60;
        Destination = destination;

    }

    public abstract decimal Estimatedcost { get; }
    public DeliveryAddress1 Destination
    {
        get;
        set;
    }
    public string TrackingCode
    {
        get { return trackingcode; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                trackingcode = value;
        }
    }
    public string Description
    {
        get { return dEscription; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                Description = value;
        }
    }
    public decimal Weight
    {
        get { return weiGht; }
        set
        {
            if (value > 0 )
                weiGht = value;
        }
    }
    public decimal DeliveryFee
    {
        get { return DEiveryFee; }
        private set
        {
            if (value > 0)
                DEiveryFee = value;
        }
    }
    public virtual decimal EstimatedCost
    {
        get { return DeliveryFee + (decimal)(Weight * 5); }
    }
    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
            DeliveryFee = newFee;
    }

    public abstract void Printshipment();
    public virtual void PrintShipment()
    {
        Console.WriteLine($"Tracking Code :{TrackingCode}");
        Console.WriteLine($"Description :{Description}");
        Console.WriteLine($"Weight :{Weight} KG");
        Console.WriteLine($"Delivery Fee :{DeliveryFee} EGP");
        Console.WriteLine($"Estimated Cost :{EstimatedCost} EGP");
    }
    public void Updatewieght(decimal newWieght)
    {
        weiGht = newWieght;
    }
    public void Updatewieght(decimal newWieght, decimal extrapackingwieght)
    {
        weiGht = newWieght + extrapackingwieght;
    }
}

////////////////////////////////////////////////////////////////////////
///////////// Create static class DeliveryHeleper//////////////////////

public static class DeliveryHelper
{
    public static void PrintShipmentDetails(Shipment1 shipment)
    {
        shipment.PrintShipment();
    }
}

public static class DeliveryReport
{
    public static void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }
    public static void PrintShipment(IInsurable shipment)
    {
        Console.WriteLine($"Insurance :{shipment.CalculateInsurance()} EGP");
    }

    public static void PrintInsurance(IInsurable shipment)
    {
        string name = shipment.GetType().Name.Replace("Shipment1", "Shipment");
        Console.WriteLine(name + "Insurance :" + shipment.CalculateInsurance().ToString("F2") + "EGP");
    }
}

public class Driver
{
    public string DriverName { get; set; }
    public Driver(string driverName)
    {
        DriverName = driverName;
    }
}