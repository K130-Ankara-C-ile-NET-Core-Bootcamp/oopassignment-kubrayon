using System.Collections.Generic;


namespace OOPAssignment.Interfaces
{
    public interface IObserver<T>
    {
        public void Update(T provider);

        public List<T> GetObservables();
    }
}
