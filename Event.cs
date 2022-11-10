﻿//class event
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
                throw new GestoreEventiException("Il nome passato è vuoto");
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
                throw new GestoreEventiException("La data passata è antecedente a quella attuale");
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
            throw new GestoreEventiException("Inserire un numero maggiore a zero");
        }
        SeatsCapacity = MaxCapacity;
        SeatsTaken = 0;
    }
}
