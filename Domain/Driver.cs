using Domain.Constants;

namespace Domain
{
    public class Driver : IDriver
    {
        private readonly ICar _car;

        public Driver(ICar car)
        {
            _car = car;
        }

        public bool GoHome(bool isDrunk)
        {
            if (!isDrunk)
            {
                _car.Start();
                _car.Move(Speed.LegalLimitation);
                _car.Stop();
                return true;
            }
            else
            {
                _car.Start();
                _car.Move(200);
                _car.BreakDown();
                return false;
            }
        }
    }
}
