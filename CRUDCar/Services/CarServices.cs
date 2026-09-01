using CRUDCar.Model;
using CRUDCar.RepoitoryCar;

namespace CRUDCar.Services
{
    public class CarService
    {
        private readonly CarRepository _repo;

        public CarService(CarRepository repo)
        {
            _repo = repo;
        }

        public List<Car> Search(Func<Car, bool> filter)
        {
            List<Car> result = new List<Car>();

            foreach (Car car in _repo.ReadAll())
            {
                if (filter(car))
                {
                    result.Add(car);
                }
            }

            return result;
        }
    }
}