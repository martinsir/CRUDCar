using CRUDCar.Model;
using CRUDCar.RepoitoryCar;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

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

        //NewestCar() der returnerer den nyeste bil, ved flere biler så den første.
        public Car NewestCar()
        {
            //Get all cars from the repository.
            List<Car> cars = _repo.ReadAll();
            //Assume the first car is currently the newest.
            Car newestCar = cars[0];
            //Compare every car against it.
            foreach (Car car in cars)
            {
                //If you find a newer one, replace newestCar
                //OBS: Using >= would replace the first car with a later car from the same year.
                if (car.Year > newestCar.Year)
                {
                    newestCar = car;
                }
            }
            //Return that one car.
            return newestCar;
        }

        //ShortestDriven() der returnerer den bil der har kørt kortest, ved flere biler så den første
        public Car ShortestDriven()
        {
            List<Car> cars = _repo.ReadAll();
            Car shortestDriven = cars[0];

            foreach (Car car in cars)
            {
                if (car.KmDriven < shortestDriven.KmDriven)
                {
                    shortestDriven = car;
                }
            }
            return shortestDriven;
        }

        //AvarageDriven() angiver gennemsnittet af hvad bilerne har kørt i km

        public int AvarageDriven()
        {
            List<Car> cars = _repo.ReadAll();
            int totalKm = 0;

            foreach (Car car in cars)
            {
                totalKm += car.KmDriven;
            }
            int averageKm = totalKm / cars.Count;
            return averageKm;
        }

        public Car MostDrivenCar()
        {
            List<Car> cars = _repo.ReadAll();
            Car mostDrivenCar = cars[0];

            foreach (Car car in cars)
            {
                if (car.KmDriven > mostDrivenCar.KmDriven)
                {
                    mostDrivenCar = car;
                }
            }
            return mostDrivenCar;
        }

        //If i truly wanted the actual Car whose driven cloeset to the average.
        /*Calculate the average KmDriven.
         * Loop through the cars again and find the car
         * with the smallest difference from that average.*/

        public Car ClosestToAverageDriven()
        {
            List<Car> cars = new List<Car>();
            int totalKm = 0;
            foreach (Car car in cars)
            {
                totalKm += car.KmDriven;
            }
            int averageKm = totalKm / cars.Count;

            //Assuming the first car is the cloesest
            Car closestCar = cars[0];

            int smallestDifferance = Math.Abs(closestCar.KmDriven - averageKm);

            //check all cars
            foreach (Car car in cars)
            {
                int difference =
                   Math.Abs(car.KmDriven - averageKm);

                if (difference < smallestDifferance)
                {
                    smallestDifferance = difference;
                    closestCar = car;
                }
            }
            return closestCar;
        }
    }
}