using System;
using System.Collections.Generic;
using System.Linq;
using OOPAssignment.Interfaces;
using OOPAssignment.structs;

namespace OOPAssignment.Class
{
    public class Surface : ISurface, ICollidableSurface, Interfaces.IObserver<CarInfo>
    {
        public long Width { get; set; }

        public long Height { get; set; }

        private List<CarInfo> ObservableCars = new List<CarInfo>();

        public Surface(long width, long height)
        {
            Width = width;
            Height = height;
        }
        public bool IsCoordinatesInBounds(Coordinates coordinates)
        {
            bool location = false;

            if ((coordinates.X >= 0 && coordinates.X <= Width) && (coordinates.Y >= 0 && coordinates.Y <= Height))
                location = true;

            return location;
        }
        public bool IsCoordinatesEmpty(Coordinates coordinates)
        {
            if (ObservableCars is not null)
            {
                foreach (var carLocation in ObservableCars)
                {
                    //Console.WriteLine("ObservableCars= " );
                    if (carLocation.Coordinates.X == coordinates.X && carLocation.Coordinates.Y == coordinates.Y)
                        return false;
                }
            }

            return true;
        }
        public void Update(CarInfo provider)
        {
            if (IsCoordinatesInBounds(provider.Coordinates))
            {
                var carList = GetObservables();
                if (carList.Contains(provider))
                {
                    var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
                    car.Coordinates = provider.Coordinates;
                }
                else if (IsCoordinatesEmpty(provider.Coordinates))
                {
                    ObservableCars.Add(provider);
                }
                else
                {
                    var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
                    if (car.Coordinates.X == provider.Coordinates.X && car.Coordinates.Y == provider.Coordinates.Y)
                        throw new Exception("Hata! Araçlar aynı konumda başlayamaz");
                    else
                        ObservableCars.Add(provider);
                }
            }
            else
            {
                throw new Exception("Hata! Araç alan dışına çıkamaz");
            }
        }
        public List<CarInfo> GetObservables()
        {
            List<CarInfo> list = new List<CarInfo>();
            if (ObservableCars != null)
            {
                foreach (var item in ObservableCars)
                    list.Add(item);
            }
            return list;
        }
    }
}
