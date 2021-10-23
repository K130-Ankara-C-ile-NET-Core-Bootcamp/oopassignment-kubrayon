namespace OOPAssignment.Interfaces
{
    public interface ICommand<T>
    {
        public void ExecuteCommand(T commandObject);
    }
}
