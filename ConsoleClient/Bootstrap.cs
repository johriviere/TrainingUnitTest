using Domain;
using Unity;

namespace ConsoleClient
{
    public class Bootstrap
    {
        public static IUnityContainer Container;
        public static void Start()
        {
            Container = new UnityContainer();
            Register();
        }

        private static void Register()
        {
            Container.RegisterType<IDriver, Driver>();
            Container.RegisterType<ICar, Car>();
        }
    }
}
