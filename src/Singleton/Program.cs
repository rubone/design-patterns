// See https://aka.ms/new-console-template for more information

using Singleton;

LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

if (b1 == b2 && b2 == b3 && b3 == b4)
{
    Console.WriteLine("Same instance\n");
}

LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
for (int i = 0; i < 15; i++)
{
    string serverName = balancer.Server;
    Console.WriteLine("Dispatch Request to: " + serverName);
}

Console.ReadKey();
