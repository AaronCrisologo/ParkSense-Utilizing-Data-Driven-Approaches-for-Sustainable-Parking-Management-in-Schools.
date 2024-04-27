namespace ParkingManagementSystem
{
    public class Program
    {
        private static string connectionString = "server=localhost;database=parkingslot1;uid=root;pwd=4122133pogi;";

        static void Main(string[] args)
        {
            using (ParkingLot parkingLot = new ParkingLot(10, connectionString))

            do
            {
                Console.WriteLine("-----Welcome to Parksense-----");
                Console.WriteLine("Would you like to park your car?,   press 1");
                Console.WriteLine("Do you want to take your car?,      press 2");
                Console.WriteLine("Display the parking area,           press 3");
                Console.WriteLine("Display the logs,                   press 4");
                Console.WriteLine("Exit the program,                   press 5\n");
                Console.Write("What do you want to do: ");

                if (!int.TryParse(Console.ReadLine(), out int dec))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine();

                switch (dec)
                {
                    case 1:
                        Console.Write("Enter your full name: ");
                        string fullName = Console.ReadLine();
                        Console.Write("Enter your vehicle type: ");
                        string vehicleType = Console.ReadLine();
                        Console.Write("Enter your car's license number: ");
                        string num = Console.ReadLine();
                        string pwd = null;
                        Console.Write("which department(cics, coe, ceafa, cit): ");
                        string dep = Console.ReadLine().ToLower();
                        parkingLot.ParkVehicle(fullName, vehicleType, num, true, dep);
                        Console.WriteLine("Your car has been parked");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 2:
                        Console.Write("Input your car's license number: ");
                        string car = Console.ReadLine();
                        parkingLot.LeaveParking(car, "ceafa");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 3:
                        parkingLot.DisplayParkingStatus();
                        break;
                    case 4:
                        parkingLot.DisplayParkingLog();
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again");
                        Console.WriteLine("++++++++++++++++++++++++++++\n");
                        break;
                }

            } while (true);
        }
    }
}
