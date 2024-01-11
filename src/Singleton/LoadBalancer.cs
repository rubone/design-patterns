namespace Singleton;

public sealed class LoadBalancer
{
    static LoadBalancer instance;
    List<string> servers = new List<string>();
    Random random = new Random();
    
    private static object locker = new object();
    
    private LoadBalancer()
    {
        servers.Add("Server I");
        servers.Add("Server II");
        servers.Add("Server III");
        servers.Add("Server IV");
        servers.Add("Server V");
    }
    
    public static LoadBalancer GetLoadBalancer()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new LoadBalancer();
                }
            }
        }
        
        return instance;
    }
    
    public string Server
    {
        get
        {
            int r = random.Next(servers.Count);
            return servers[r].ToString();
        }
    }
}