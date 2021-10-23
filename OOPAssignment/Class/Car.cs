using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPAssignment.Enums;
using OOPAssignment.Interfaces;
using OOPAssignment.structs;

namespace OOPAssignment.Class
{
    public class Car : ICarCommand, Interfaces.IObservable<CarInfo>
    {
        public Guid Id;
        public Coordinates Coordinates;
        public Direction Direction { get; set; }
        public ISurface Surface { get; set; }
        private Interfaces.IObserver<CarInfo> Observer;

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }

        public void Attach(Interfaces.IObserver<CarInfo> observer)
        {
            Observer = observer;
            Notify();
        }

        public void Move()
        {
            MovementFactor move = new() { XFactor = (int)Coordinates.X, YFactor = (int)Coordinates.Y };

            if (Direction == Direction.N)
                move.YFactor++;
            else if (Direction == Direction.W)
                move.XFactor--;
            else if (Direction == Direction.S)
                move.YFactor--;
            else if (Direction == Direction.E)
                move.XFactor++;
            else
                throw new Exception("Hata! Araç hareket edemedi.");

            Coordinates = new Coordinates { X = move.XFactor, Y = move.YFactor };

            Notify();
        }

        public void Notify()
        {
            Coordinates _coordinates = new() { X = Coordinates.X, Y = Coordinates.Y };
            CarInfo _info = new CarInfo(Id, _coordinates);
            Observer.Update(_info);
        }

        public void TurnLeft()
        {
            if (Direction == Direction.N)
                Direction = Direction.W;
            else if (Direction == Direction.W)
                Direction = Direction.S;
            else if (Direction == Direction.S)
                Direction = Direction.E;
            else if (Direction == Direction.E)
                Direction = Direction.N;
            else
                throw new Exception("Hata! Araç sola dönemedi.");
        }

        public void TurnRight()
        {
            if (Direction == Direction.N)
                Direction = Direction.E;
            else if (Direction == Direction.E)
                Direction = Direction.S;
            else if (Direction == Direction.S)
                Direction = Direction.W;
            else if (Direction == Direction.W)
                Direction = Direction.N;
            else
                throw new Exception("Hata! Araç sağa dönemedi.");
        }


    }
}
