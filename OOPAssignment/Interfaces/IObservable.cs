
namespace OOPAssignment.Interfaces
{
    public interface IObservable<T>
    {
        public void Attach(IObserver<T> observer);

        public void Notify();
    }
}
