namespace Interfaces
{
    public interface IObserver
    {
        void UpdateObs(ISubject subject);
        void Subscribed(ISubject subject);
    }
}