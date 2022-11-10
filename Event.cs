//class event
public class Event
{
    //attributes
    public string _title;
    public DateOnly _date;
    //public int SeatsCapacity; //not needed because default setter and getter
    //public int SeatsTaken;    //not needed because default setter and getter

    //properties
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new GestoreEventiException("The Name Set is empty or not valid");
            }
            _title = value;
        }
    }
    public DateOnly Date
    {
        get
        {
            return _date;
        }
        set
        {
            if (value <= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new GestoreEventiException("The Date set is not valid");
            }
            _date = value;
        }
    }
    public int SeatsCapacity { get; }
    public int SeatsTaken { get; private set; }

    //constructor
    public Event(string title, DateOnly date, int MaxCapacity)
    {
        Title = title;
        Date = date;
        if (MaxCapacity < 0)
        {
            throw new GestoreEventiException("Insert a positive integer");
        }
        SeatsCapacity = MaxCapacity;
        SeatsTaken = 0;
    }

    public int PrenotaPosti(int inputBookings)
    {
        //if date is not past
        //if seatsBooked >= than remaining posts

        if ((SeatsCapacity-SeatsTaken) >= inputBookings && Date >= DateOnly.FromDateTime(DateTime.Now))
        {
            return SeatsTaken += inputBookings;
        }
        else
        {
            return 0;
        }
    }

    public int DisdiciPosti(int inputUnBookings)
    {
        //delete post from event
        if ((SeatsTaken - inputUnBookings) >= 0 && Date >= DateOnly.FromDateTime(DateTime.Now))
        {
            return SeatsTaken -= inputUnBookings;
        }
        else
        {
            return 0;
        }
    }
    public override string ToString()
    {
        return Date + " - " + Title;
    }

    //public void PrintEvent(string eventActual)
    //{
    //    Console.WriteLine("nome evento: {0} \n " +
    //          "Date event {1} \n " +
    //          "Max available seats: {2} \n " +
    //          "Seats Booked: {3} \n " +
    //          "Seats Available: {4}", eventActual.Title, eventActual.Date, eventActual.SeatsCapacity, eventActual.SeatsTaken, (eventActual.SeatsCapacity - eventActual.SeatsTaken));
    //}
}

