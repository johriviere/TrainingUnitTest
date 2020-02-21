using Domain;
using Unity;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.Start();

            Driver driver = Bootstrap.Container.Resolve<Driver>();
            driver.GoHome(isDrunk: false);
        }
    }
}
