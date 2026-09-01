using CRUDCar.Model;

namespace CRUDCar.RepoitoryCar
{
    public interface ICarRepository
    {
        Car Create(Car car);

        List<Car> ReadAll();

        Car ReadById(int id);

        Car Update(int id, Car updatedCar);

        Car Delete(int id);
    }
}