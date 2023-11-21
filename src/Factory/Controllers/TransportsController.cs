using Factory.Constants;
using Factory.Factory;
using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers;

[ApiController]
[Route("[controller]")]
public class TransportsController : ControllerBase
{
    private readonly ITransportFactory _factory;

    public TransportsController(ITransportFactory factory)
    {
        _factory = factory;
    }

    [HttpGet]
    public IActionResult Get(TransportType transportType)
    {
        var transport = _factory.CreateTransport(transportType);
        
        return Ok(transport.ToString());
    }
}