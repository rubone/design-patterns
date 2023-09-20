using Factory.Constants;
using Factory.Interfaces;

namespace Factory.Factory;

public interface ITransportFactory
{
    void RegisterTransport(TransportType transportType, Func<ITransport> factoryMethod);
    
    ITransport CreateTransport(TransportType transportType);
}
