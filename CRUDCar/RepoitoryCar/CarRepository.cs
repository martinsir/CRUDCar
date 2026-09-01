using CRUDCar.Model;

//ups glemte folder *ClassLibeerary*
namespace CRUDCar.RepoitoryCar
{
    public class CarRepository : ICarRepository
    {

        private int _nextId = 1;
        private List<Car> carsList = new List<Car>();

        //CRUD - C
        public Car Create(Car car)
        {
            car.Id = _nextId;
            _nextId++;

            carsList.Add(car);

            return car;
        }

        // CRUD - R
        public List<Car> ReadAll()
        {
            return new List<Car>(carsList);
        }

        public Car ReadById(int id)
        {
            for (int i = 0; i < carsList.Count; i++)
            {
                if (carsList[i].Id == id)
                {
                    return carsList[i];
                }
            }
            throw new KeyNotFoundException();
        }

        //CRUD - U
        public Car Update(int id, Car updatedCar)
        {
            for (int i = 0; i < carsList.Count; i++)
            {
                if (carsList[i].Id == id)
                {
                    carsList[i].Vendor = updatedCar.Vendor;
                    carsList[i].Model = updatedCar.Model;
                    carsList[i].Color = updatedCar.Color;
                    carsList[i].KmDriven = updatedCar.KmDriven;
                    carsList[i].EngineKind = updatedCar.EngineKind;
                    carsList[i].EnginePower = updatedCar.EnginePower;
                    carsList[i].Doors = updatedCar.Doors;
                    carsList[i].TowBar = updatedCar.TowBar;
                    carsList[i].Year = updatedCar.Year;
                    return carsList[i];
                }
            }
            throw new KeyNotFoundException();
        }

        //CRUD - D
        public Car Delete(int id)
        {
            Car car = ReadById(id);
            carsList.Remove(car);
            return car;
        }
    }
}