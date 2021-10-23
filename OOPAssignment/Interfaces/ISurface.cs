using OOPAssignment.structs;


namespace OOPAssignment.Interfaces
{
    public interface ISurface
    {
        public long Width { get; }
        public long Height { get; }
        public bool IsCoordinatesInBounds(Coordinates coordinates);

    }
}
