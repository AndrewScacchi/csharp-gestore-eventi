//creare classe eccezioni per il programma for custom exceptions
public class GestoreEventiException : Exception
{
    public GestoreEventiException()
    {
    }

    public GestoreEventiException(string message) : base(message)
    {
    }
}

