using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Timers;
using System.Xml.Linq;
using TestSmartDeliveryManagementSystem._Classes;
using TestSmartDeliveryManagementSystem.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using static TestSmartDeliveryManagementSystem.Shipment;

namespace TestSmartDeliveryManagementSystem
{
    //public struct DeliveryAddress
    //{
    //    public string City; public string Street;
    //}

    //public class Customer
    //{
    //    public string Name;
    //}
    //a) What happens when a DeliveryAddress variable is copied into another variable and the copy is modified?

    //Since a struct is a value type, when a copy of the variable is taken and modified, it will be placed in a new object on the stack, and the new object will be independent of the old one.Modifying the copy does not affect the original variable.

    //b) What happens when a Customer variable is copied into another variable and one variable modifies the object.

    //Since the class is a reference type, this means that when we take a copy of the Customer variable and put it in another variable, it means we took a reference of the original variable and put it in the new variable, so both variables end up pointing to the same object on the heap, and here any modification will have an effect.

    //public struct Shipment
    //{
    //    public string Description;
    //    public double Weight;
    //    public decimal DeliveryFee;
    //}

    //a) Identify at least three problems with this design from an encapsulation perspective.

    //The three problems are that the variables are defined as Public as an access modifier, and the question mentions that it wants to apply the principle of encapsulation in OOP, which involves hiding the variables and preventing any direct modification, with changes being done through Properties.This goes against the principle of encapsulation.

    //b) How can private fields and public properties improve this design?

    //Because using private fields and public properties achieves the principle of Encapsulation, this way there won't be any problems and the code will run as it should.

    //a) What is the difference between a class and a struct?

    //    1- A struct is a value type stored in the stack and is suitable for small and simple data.It copies the value and does not support inheritance. The default constructor always exists even after creating another constructor that takes parameters, and it does not accept null values.

    //2- A class is a reference type stored in the heap and is suitable for large and complex data.It features a shared state, copies the reference, and fully supports inheritance. The default constructor does not exist if you create a constructor that takes parameters.It allows storing null values because it is stored in the heap.

    //b) Why are classes more suitable than structs for large applications?

    //Because the class is stored in the heap and is suitable for large and complex data, and it also has a shared state, it can store null values too.

    //public class Shipment
    //{
    //    public string TrackingCode { get; set; }
    //}
    //public class ExpressShip : Shipment
    //{
    //    public decimal Extrafee {  get; set; }
    //}
    //a) Which class is the parent class?

    //The class Shipment.

    //b) Which class is the child class?

    //The class ExpressShip.

    //c) What members are inherited by ExpressShipment?

    //The string Field TrackingCode

    //d) Why is inheritance better than duplicating the same code in multiple classes?

    //Because repeating code is a big mistake and causes a lot of errors in writing code and leads to what is called spaghetti coding.That's why OOP and inheritance were created; they have a lot of advantages, including making code reusable and maintainable.

    //a)  What is the difference between Method Overloading and Method Overriding?

    //    Overloading means having more than one function with the same name but different numbers of parameters and parameter data types to execute different coding or logic and parameter order.

    //On the other hand, overriding is used with virtual, abstract, and override as keywords.In the child class, you have to use the override keyword to use a method overridden from the parent class. This method should have the same name, same parameters, and same return type.You also need to specify the access modifier at the beginning, and it must be fixed—it can’t be different from the original access modifier.

    //b)  What is the difference between Static Binding and Dynamic Binding?

    //    In Static binding, it happens at compile time and is executed during the compilation.It’s for reference types, uses the keyword 'new', and is used with method overloading, operator overloading, and method hiding.It offers faster performance but is less flexible.  

    //On the other hand, Dynamic binding happens at run time and is executed during runtime via the CLR. It’s determined by the actual object, uses 'virtual' + 'override', and is used with method overriding, abstract methods, and interfaces.It has slower performance but is more flexible.


    
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////// Answears Of Assignment04 Questions//////////////////////////////////////// 
    //Q1 Abstraction

    //a)  What is Abstraction in Object-Oriented Programming?

    //Abstraction is the process of hiding the details of coding or execution and writing the logic(body) in the backend from the external system, creating an abstract layer through which services are presented to the external system.This helps prevent the high-level components from depending on low-level ones, which could cause a problem called tight coupling.

    //b)  Why is abstraction considered one of the four pillars of OOP?

    //Because abstraction has features similar to OOP characteristics in terms of maintainability and being easily extendable.It includes the abstract class, which can be inherited by multiple classes, and consequently objects can be created from it.It also works with loosely coupling, meaning that the high-level doesn't depend on the low-level.

    //Q2  Abstract Classes vs.Interfaces

    //a)  What is the difference between an Abstract Class and an Interface?

    //An Abstract Class is defined with the keyword 'abstract' and can be inherited by more than one class. You can write both abstract methods and concrete methods inside it, as well as fields and constructors.So, you can create objects from it, use access modifiers, and provide base functionality and common behavior.
    //As for the interface, we define it with the keyword 'interface', and one class can implement multiple interfaces.Before C# 8.0, it contained only abstract methods. From C# 8.0 onwards, it can also include default and static methods, but no fields inside it—only constants and constructors. The members are public by default, and it defines a contract.

    //b)  When would you choose an Interface instead of an Abstract Class?

    //We choose an Interface when there are two or more classes with extensions that are not inherited by them, and at the same time, they are different, so we implement these classes.As for the Abstract Class, we choose it when there are shared things among multiple classes, so we create interfaces and then implement them in other classes because you can write inheritance and interfaces inside it, and it inherits everything inside.

    //c)  Can a class inherit from multiple abstract classes? Can it implement multiple interfaces?


    //No, because inheritance doesn't support a class inheriting from multiple classes. Yes, it can, because an interface allows implementation by multiple classes, or a class can implement multiple interfaces.
    internal class Program
    {
        static string ReadText(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static decimal ReadNumber(string message)
        {
            Console.WriteLine(message);
            decimal.TryParse(Console.ReadLine(), out decimal number);
            return number;
        }

        static DeliveryAddress1 ReadAddress()
        {
            string city = ReadText("Enter City:");
            string street = ReadText("Enter Street:");
            Console.WriteLine("Enter Building Number:");
            int.TryParse(Console.ReadLine(), out int building);
            return new DeliveryAddress1(city, street, building);
        }
        static void Main(string[] args)
        {
            //DeliveryCenter Delivery1 = new DeliveryCenter(10); 

            //for(int i = 0; i <= 2; i++)
            //{
            //    Console.WriteLine("\n Enter Shipment" + i + "Data");
            //    Console.Write("Tracking Code: ");
            //    string code = Console.ReadLine();
            //    Console.Write("Description: ");
            //    string desc = Console.ReadLine();
            //    Console.Write("Weight: ");
            //    double weight = double.Parse(Console.ReadLine());
            //    Console.Write("Delivery Fee: ");
            //    decimal fee = decimal.Parse(Console.ReadLine());
            //    Console.Write("City: ");
            //    string city = Console.ReadLine();
            //    Console.Write("Street: ");
            //    string street = Console.ReadLine();
            //    Console.Write("Building Number: ");
            //    int building = int.Parse(Console.ReadLine());

            //    DeliveryAddress address = new DeliveryAddress(city, street, building);
            //    Shipment shipment = new Shipment(code, desc, weight, fee, address);

            //    if(Delivery1.AddShipment(shipment))
            //        Console.WriteLine("Shipment added successfully.");
            //    else
            //        Console.WriteLine("Delivery center is full.");
            //}

            //Console.WriteLine("\n--- All Shipments ---");
            //for(int i = 0; i < 3; i++)
            //{
            //    Delivery1[i].PrintShipment();
            //    Console.WriteLine();
            //}
            //Console.Write("Enter a tracking code to search: ");
            //string search = Console.ReadLine();
            //Shipment found = Delivery1[search];

            //if (found.TrackingCode != null)
            //    Console.WriteLine("Shipment found: " + found.TrackingCode + " - " + found.Description);
            //else
            //    Console.WriteLine("Shipment not found.");

            //Console.WriteLine("\n--- Struct Copy Test ---");
            //DeliveryAddress original = new DeliveryAddress("Cairo", "Tahrir Street", 15);
            //DeliveryAddress copy = original;
            //copy.Street = "Makram Ebeid Street";
            //copy.BuildingNumber = 20;
            //Console.WriteLine("Original Address: " + original.GetFullAddress());
            //Console.WriteLine("Copied Address: " + copy.GetFullAddress());
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            static string ReadNonEmpty(string msg)
            {
                while (true)
                {
                    Console.Write(msg);
                    string s = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(s)) return s;
                    Console.WriteLine("Value cannot be empty.");
                }
            }

            static decimal ReadPositiveDecimal(string msg)
            {
                while (true)
                {
                    Console.Write(msg);
                    if (decimal.TryParse(Console.ReadLine(), out decimal v) && v > 0) return v;
                    Console.WriteLine("Invalid value, try again.");
                }
            }

            static int ReadPositiveInt(string msg)
            {
                while (true)
                {
                    Console.Write(msg);
                    if (int.TryParse(Console.ReadLine(), out int v) && v > 0) return v;
                    Console.WriteLine("Invalid number, try again.");
                }
            }

            Driver Driv = new Driver("Mohamed Gamal Ezz AL arab");
            Console.WriteLine(Driv);

            DeliveryCenter1 DEEL = new DeliveryCenter1();
            //Console.WriteLine("please Enter delivery CenterName here : ");
            DEEL.CenterName = ReadNonEmpty("please Enter delivery CenterName here : ");
            Console.WriteLine(DEEL.CenterName);

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ StandardShipment --------------");
            Console.WriteLine("         --------------------------     ");
            //Console.Write("Enter The Trackingcode(1) :");
            //string Code1 = ReadNonEmpty("Enter The Trackingcode(1) :");
            //Console.Write("Enter The Description(1) :");
            //string Desc1 = Console.ReadLine();     
            //Console.Write("Enter The Weight(1) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Weight1);
            //Console.Write("Enter The Deliveryfee(1) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Deliveryfee1);
            //Console.Write("Enter The Hight :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Hight);
            //Console.Write("Enter The City :");
            //string City1 = Console.ReadLine();
            //Console.Write("Enter The Street :");
            //string Street1 = Console.ReadLine();
            //Console.Write("Enter The BuildingNmber :");
            //int.TryParse(/*Console.ReadLine*/(), out int BuildingNmber1);
            string Code1 = ReadNonEmpty("Enter The Trackingcode(1) :");
            string Desc1 = ReadNonEmpty("Enter The Description(1) :");
            decimal Weight1 = ReadPositiveDecimal("Enter The Weight(1) :");
            decimal Deliveryfee1 = ReadPositiveDecimal("Enter The Deliveryfee(1) :");
            decimal Hight = ReadPositiveDecimal("Enter The Hight :");
            string City1 = ReadNonEmpty("Enter The City :");
            string Street1 = ReadNonEmpty("Enter The Street :");
            int BuildingNmber1 = ReadPositiveInt("Enter The BuildingNmber :");
            StandardShipment Ship = new StandardShipment(Code1, Desc1, Weight1, Deliveryfee1, Hight, new DeliveryAddress1(City1, Street1, BuildingNmber1));

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ ExpressShipment --------------");
            Console.WriteLine("        --------------------------     ");
            //Console.Write("Enter The Trackingcode(2) :");
            //string Code2 = Console.ReadLine();
            //Console.Write("Enter The Description(2) :");
            //string Desc2 = Console.ReadLine();
            //Console.Write("Enter The Weight(2) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Weight2);
            //Console.Write("Enter The Deliveryfee(2) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Deliveryfee2);
            //Console.Write("Enter The City :");
            //string City2 = Console.ReadLine();
            //Console.Write("Enter The Street :");
            //string Street2 = Console.ReadLine();
            //Console.Write("Enter The BuildingNmber :");
            //int.TryParse(Console.ReadLine(), out int BuildingNmber2);
            //Console.Write("Enter The Extrafee :");
            //double.TryParse(Console.ReadLine(), out double Extrafee);
            string Code2 = ReadNonEmpty("Enter The Trackingcode(2) :");
            string Desc2 = ReadNonEmpty("Enter The Description(2) :");
            decimal Weight2 = ReadPositiveDecimal("Enter The Weight(2) :");
            decimal Deliveryfee2 = ReadPositiveDecimal("Enter The Deliveryfee(2) :");
            double Extrafee = (double)ReadPositiveDecimal("Enter The Extrafee(2) :");
            string City2 = ReadNonEmpty("Enter The City :");
            string Street2 = ReadNonEmpty("Enter The Street :");
            int BuildingNmber2 = ReadPositiveInt("Enter The BuildingNmber :");
            ExpressShipment Expr = new ExpressShipment(Code2, Desc2, Weight2, Deliveryfee2, Extrafee,new DeliveryAddress1(City2, Street2, BuildingNmber2));
             

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ InternationalShipment --------------");
            Console.WriteLine("          --------------------------     ");
            //Console.Write("Enter The Trackingcode(3) :");
            //string Code3 = Console.ReadLine();
            //Console.Write("Enter The Description(3) :");
            //string Desc3 = Console.ReadLine();
            //Console.Write("Enter The Weight(3) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Weight3);
            //Console.Write("Enter The Deliveryfee(3) :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Deliveryfee3);
            //Console.Write("Enter The Destinationcountry :");
            //string Destinat = Console.ReadLine();
            //Console.Write("Enter The Customsfee :");
            //Decimal.TryParse(Console.ReadLine(), out decimal Customsfee);
            //Console.Write("Enter The City :");
            //string City3 = Console.ReadLine();
            //Console.Write("Enter The Street :");
            //string Street3 = Console.ReadLine();
            //Console.Write("Enter The BuildingNmber :");
            //int.TryParse(Console.ReadLine(), out int BuildingNmber3);
            string Code3 = ReadNonEmpty("Enter The Trackingcode(3) :");
            string Desc3 = ReadNonEmpty("Enter The Description(3) :");
            decimal Weight3 = ReadPositiveDecimal("Enter The Weight(3) :");
            decimal Deliveryfee3 = ReadPositiveDecimal("Enter The Deliveryfee(3) :");
            decimal Customsfee = ReadPositiveDecimal("Enter The Extrafee(3) :");
            string City3 = ReadNonEmpty("Enter The City :");
            string Street3 = ReadNonEmpty("Enter The Street :");
            int BuildingNmber3 = ReadPositiveInt("Enter The BuildingNmber :");
            string Destinat = ReadNonEmpty("Enter The Destination :");
            InternationalShipment Inter = new InternationalShipment(Code3, Desc3, Weight3, Deliveryfee3, Customsfee, new DeliveryAddress1(City3, Street3, BuildingNmber3), Destinat);
            

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ Add The Shipments --------------");
            if (DEEL.AddShipment(Ship))
                Console.WriteLine("Shipment Added Successfully.");
            else
                Console.WriteLine("Delivery center is full.");


            if(DEEL.AddShipment(Expr))
                Console.WriteLine("Shipment Added Successfully.");
            else
                Console.WriteLine("Delivery center is full.");


            if(DEEL.AddShipment(Inter))
                Console.WriteLine("Shipment Added Successfully.");
            else
                Console.WriteLine("Delivery center is full.");

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ Print All Shipments --------------");
            Console.WriteLine("========================================");
            Console.WriteLine("Delivery Center :" + DEEL.CenterName);
            Console.WriteLine("========================================");
            DEEL.PrintAllShipments();

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ Search By Tracking Code --------------");
            Console.WriteLine("Enter The Tracking Code To Search :");
            string search = Console.ReadLine();
            Shipment1 found = DEEL[search];

            if (found != null)
                found.PrintShipment();
            else
                Console.WriteLine("Not Found The Shipment.");

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("------------ Remove The Shipment --------------");
            Console.WriteLine("Enter The Tracking Code To Removing :");
            string Remov = Console.ReadLine();

            if (DEEL.RemoveShipment(Remov))
                Console.WriteLine("Shipment Removed Successfully.");
            else
                Console.WriteLine("Not Found The Shipment.");

            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("--------- Print The Remaining Shipments ------------");
            Console.WriteLine("========================================");
            Console.WriteLine("          Remaining Shipments :      ");
            Console.WriteLine("========================================");
            Console.WriteLine();
            DEEL.PrintAllShipments();
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine("          Add them to the center              ");
            Console.WriteLine("========================================");
            DEEL.AddShipment(Ship);
            DEEL.AddShipment(Expr);
            DEEL.AddShipment(Inter);
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine("          DeliveryCenter1               ");
            Console.WriteLine("========================================");
            DEEL.PrintAllShipments();
            Console.WriteLine();

            Console.WriteLine("          Tracking Status               ");
            Console.WriteLine("========================================");
            DEEL.PrintTrackingStatuses();
            Console.WriteLine();

            Console.WriteLine("                 Insurance               ");
            Console.WriteLine("========================================");
            DeliveryReport.PrintInsurance(Ship);
            DeliveryReport.PrintInsurance(Expr);
            DeliveryReport.PrintInsurance(Inter);
            Console.WriteLine();
            Console.WriteLine("          ITrackable[] Tracking Status               ");
            Console.WriteLine("==============================================");
            ITrackable[] trackables = { Expr, Inter };
            foreach(ITrackable itrack in trackables)
            {
                DeliveryReport.PrintShipment(itrack);
            }
            Console.WriteLine();

            Console.WriteLine("          IInsurable[] insurance values             ");
            Console.WriteLine("===============================================");
            IInsurable[] insurables = { Expr, Inter };
            foreach (IInsurable insurable in insurables)
            {
                DeliveryReport.PrintInsurance(insurable);
            }
            Console.WriteLine();
            Console.WriteLine("============================================================");
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
    }
