using Factory.Interfaces;

namespace Factory.Models;

public class Truck : ITransport
{
    public void Deliver()
    {
        throw new NotImplementedException();
    }
}