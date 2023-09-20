using Factory.Constants;
using Factory.Interfaces;

namespace Factory.Factory;

public class TransportFactory : ITransportFactory
{
    private readonly Dictionary<TransportType, Func<ITransport>> transports;
    
    public TransportFactory()
    {
        transports = new Dictionary<TransportType, Func<ITransport>>();
    }   
    
    public void RegisterTransport(TransportType transportType, Func<ITransport> factoryMethod)
    {
        transports.Add(transportType, factoryMethod);
    }

    public ITransport CreateTransport(TransportType transportType)
    {
        Func<ITransport> function = transports[transportType];
        
        ITransport transport = function();
        
        return transport;
    }
}
