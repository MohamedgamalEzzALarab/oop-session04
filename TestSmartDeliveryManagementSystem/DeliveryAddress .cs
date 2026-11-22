namespace TestSmartDeliveryManagementSystem
{
    public struct DeliveryAddress1
    {
        public string City;
        public string Street;
        public int BuildingNumber;
        public DeliveryAddress1(string city, string street, int buildingNumber)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be empty.", nameof(city));

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be empty.", nameof(street));

            if (buildingNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(buildingNumber), "Building number must be greater than 0.");

            City = city.Trim();
            Street = street.Trim();
            BuildingNumber = buildingNumber;
        }
        public bool IsValid => !string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(Street) && BuildingNumber > 0;
        
        public string GetFullAddress()
        {
            return $"{BuildingNumber},{Street},{City}";
        }
    }

    //public struct Shipment
    //{
    //    private string trackingCode;
    //    private string description;
    //    private double weight;
    //    private decimal deliveryFee;

    //    public Shipment(string TrackingCode)
    //    {
    //        description = "Unknown";
    //        weight = 1;
    //        deliveryFee = 50;
    //        Destination = new DeliveryAddress1("Unknown", "Unknown", 1);
    //    }
    //    public Shipment(string TrackingCode, string Description, double Weight, decimal DeliveryFee, DeliveryAddress1 destination)
    //    {
    //        trackingCode = string.IsNullOrWhiteSpace(TrackingCode) ? "UNKNOWN" : TrackingCode;
    //        description = string.IsNullOrWhiteSpace(Description) ? "UNKNOWN" : Description;
    //        weight = Weight > 0 ? Weight : 1;
    //        deliveryFee = DeliveryFee > 0 ? DeliveryFee : 50;
    //        Destination = destination;
    //    }

    //    public DeliveryAddress1 Destination { get; set; }
    //    public string TrackingCode
    //    {
    //        get { return TrackingCode; }
    //        set
    //        {
    //            if (!string.IsNullOrEmpty(TrackingCode))
    //                TrackingCode = value;
    //        }
    //    }
    //    public string Description
    //    {
    //        get { return description; }
    //        set
    //        {
    //            if (!string.IsNullOrEmpty(Description))
    //                Description = value;
    //        }
    //    }
    //    public double Weight
    //    {
    //        get { return weight; }
    //        set
    //        {
    //            if (value > 0)
    //                Weight = value;
    //        }
    //    }
    //    public decimal DeliveryFee
    //    {
    //        get { return deliveryFee; }
    //        private set
    //        {
    //            if (value > 0)
    //                DeliveryFee = value;
    //        }
    //    }
    //    public decimal EstimatedCost
    //    {
    //        get { return DeliveryFee + (decimal)(Weight * 5); }
    //    }
    //    public void UpdateDeliveryFee(decimal newFee)
    //    {
    //        if (newFee > 0)
    //            DeliveryFee = newFee;
    //    }
    //    public void PrintShipment()
    //    {
    //        Console.WriteLine($"Tracking Code :{TrackingCode}");
    //        Console.WriteLine($"Description :{Description}");
    //        Console.WriteLine($"Weight :{Weight} KG");
    //        Console.WriteLine($"Delivery Fee :{DeliveryFee} EGP");
    //        Console.WriteLine($"Destination :{Destination.GetFullAddress()}");
    //        Console.WriteLine($"Estimated Cost :{EstimatedCost} EGP");
    //    }
    //}

    //public struct DeliveryCenter
    //{
    //    private Shipment[] Shipments;

    //    public DeliveryCenter(int Size)
    //    {
    //        Shipments = new Shipment[Size];
    //    }
    //    private bool IsvaildIndex(int index)
    //    {
    //        return Shipments != null && index >= 0 && index < Shipments.Length;
    //    }

    //    public Shipment this[int Index]
    //    {
    //        get
    //        {
    //            if (IsvaildIndex(Index))
    //                return Shipments[Index];

    //            return default;
    //        }
    //        set
    //        {
    //            if (IsvaildIndex(Index))
    //                Shipments[Index] = value;
    //        }
    //    }
    //    public Shipment this[string trackingcode]
    //    {
    //        get
    //        {
    //            if (Shipments != null)
    //            {
    //                for (int i = 0; i < Shipments.Length; i++)
    //                {
    //                    if (Shipments[i].TrackingCode != null && Shipments[i].TrackingCode == trackingcode)
    //                        return Shipments[i];
    //                }
    //            }
    //            return default;
    //        }
    //    }
    //    public bool AddShipment(Shipment shipment)
    //    {
    //        if (Shipments == null)
    //            return false;

    //        for (int i = 0; i < Shipments.Length; i++)
    //        {
    //            if (Shipments[i].TrackingCode == null)
    //            {
    //                Shipments[i] = shipment;
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //}
}  
