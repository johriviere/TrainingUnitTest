using System;

namespace Domain
{
    public class Car : ICar
    {
        public bool IsStarted { get; private set; }
        public int Speed { get; private set; }

        public bool IsBroken { get; private set; }

        public Car()
        {
            IsBroken = false;
            IsStarted = false;
        }

        public void Move(int speed)
        {
            if (IsStarted)
            {
                Speed = speed;
            }
        }

        public bool Start()
        {
            if (IsBroken)
            {
                return false;
            }
            IsStarted = true;
            return true;
        }

        public bool Stop()
        {
            IsStarted = false;
            Speed = 0;
            return true;
        }

        public void BreakDown()
        {
            IsBroken = true;
            IsStarted = false;
            Speed = 0;
        }
    }
}
