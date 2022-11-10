//MILESTONE 1 DONE
//MILESTONE 2 


using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Test Programm Start");
Console.WriteLine("");

Console.WriteLine("What would you like to do?");
Console.WriteLine("1 - See All available events [unavailable now]");
Console.WriteLine("2 - Add a new Event");
string answerPromptA = Console.ReadLine();
if(answerPromptA == "1")
{
    Console.WriteLine("The option Selected is not Available");
}
else if(answerPromptA == "2")
{
    Console.WriteLine("To create a new event insert Event Name:");
    string nameEvent = Console.ReadLine();

    Console.WriteLine("Insert date event (mm/dd/yyyy)");
    DateOnly dateEvent = DateOnly.Parse((Console.ReadLine()));

    Console.WriteLine("Insert total seats numbers");
    int maxSeatsEvent = Convert.ToInt32(Console.ReadLine());


    try
    {
        //creating event and printing results
        Event event1 = new Event(nameEvent, dateEvent, maxSeatsEvent);

        //Further interaction with the Booking


        //Booking Reservation ONCE
        Console.WriteLine("---");
        Console.WriteLine("Would you like to reserve some seats? [y/n]");
        string answerBooking = Console.ReadLine();
        if (answerBooking == "y")
        {
            Console.WriteLine("How Many Seats you wanna book?");
            int toBeBooked = Convert.ToInt32(Console.ReadLine());
            event1.PrenotaPosti(toBeBooked);

            Console.WriteLine("Seats Available: {0}", (event1.SeatsCapacity - event1.SeatsTaken));

            //PrintEvent("");
        }
        else
        {
            Console.WriteLine("nome evento: {0} \n " +
               "Date event {1} \n " +
               "Max available seats: {2} \n " +
               "Seats Booked: {3} \n " +
               "Seats Available: {4}", event1.Title, event1.Date, event1.SeatsTaken, event1.SeatsTaken, (event1.SeatsCapacity - event1.SeatsTaken));
        }
        //Booking removal Until NO
        bool cycleUnbookTrue = true;
        do
        {
            Console.WriteLine("---");
            Console.WriteLine("Do you wanna unbook some seats? [y/n]");
            string answerUnBooking = Console.ReadLine();


            cycleUnbookTrue = true;
            if (answerUnBooking == "y")
            {
                Console.WriteLine("How Many Seats you wanna Unbook?");
                int toBeUnBooked = Convert.ToInt32(Console.ReadLine());
                event1.DisdiciPosti(toBeUnBooked);

                Console.WriteLine("Remaining Booking {0} out of {1} max Seats", event1.SeatsTaken, event1.SeatsCapacity);
            }
            else
            {
                cycleUnbookTrue = false;
                Console.WriteLine("nome evento: {0} \n " +
                "Date event {1} \n " +
                "Max available seats: {2} \n " +
                "Seats Booked: {3} \n " +
                "Seats Available: {4}", event1.Title, event1.Date, event1.SeatsTaken, event1.SeatsTaken, (event1.SeatsCapacity - event1.SeatsTaken));
            }
        }
        while (cycleUnbookTrue);
    }
    catch (GestoreEventiException e)
    {
        Console.WriteLine(e.ToString());
    }

}
else
{
    Console.WriteLine("The option Selected is not Available");
}


