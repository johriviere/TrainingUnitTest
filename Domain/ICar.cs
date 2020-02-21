namespace Domain
{
    public interface ICar
    {
        bool Start();

        void Move(int speed);

        bool Stop();

        void BreakDown();
    }
}
