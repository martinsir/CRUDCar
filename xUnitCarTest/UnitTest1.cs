using CRUDCar.Model;
using CRUDCar.RepoitoryCar;
using CRUDCar.Services;

namespace xUnitCarTest
{
    public class UnitTestCar
    {
        // Check that Create gives cars unique IDs
        //Create
        [Fact]
        public void CreateCarTest_OK()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car car1 = new Car();
            Car car2 = new Car();

            // Act
            Car actualCar1 = repositoryCar.Create(car1);
            Car actualCar2 = repositoryCar.Create(car2);

            // Assert
            Assert.Equal(1, actualCar1.Id);
            Assert.Equal(2, actualCar2.Id);
            Assert.NotEqual(actualCar1.Id, actualCar2.Id);
        }

        //Read
        [Fact]
        public void ReadAllCarTest_OK()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car car1 = new Car();
            Car car2 = new Car();

            repositoryCar.Create(car1);
            repositoryCar.Create(car2);

            int expectedCount = 2;

            // Act
            List<Car> actualCars = repositoryCar.ReadAll();

            // Assert - check that ReadAll returned both cars
            Assert.Equal(expectedCount, actualCars.Count);

            // Clear the returned list
            actualCars.Clear();

            // Check that the repository still has the original cars
            Assert.Equal(2, repositoryCar.ReadAll().Count);
        }

        [Fact]
        public void ReadByIdCarTest_OK()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car car = new Car();
            //Instead of assuming 1 we use createdCar.Id
            Car createdCar = repositoryCar.Create(car);

            // Act
            Car actualCar = repositoryCar.ReadById(createdCar.Id);

            // Assert
            Assert.Equal(createdCar.Id, actualCar.Id);
        }

        //Update
        // Test that all Car properties are updated
        [Fact]
        public void UpdateCarTest_OK()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car car = new Car();
            car.Vendor = "Toyota";
            car.Model = "Yaris";
            car.Color = "Red";
            car.KmDriven = 100000;
            car.EngineKind = "Benzin";
            car.EnginePower = 90;
            car.Doors = 5;
            car.TowBar = false;
            car.Year = 2018;

            Car createdCar = repositoryCar.Create(car);

            Car updatedCar = new Car();
            updatedCar.Vendor = "Ford";
            updatedCar.Model = "Focus";
            updatedCar.Color = "Blue";
            updatedCar.KmDriven = 75000;
            updatedCar.EngineKind = "Diesel";
            updatedCar.EnginePower = 120;
            updatedCar.Doors = 5;
            updatedCar.TowBar = true;
            updatedCar.Year = 2020;

            // Act
            Car actualCar = repositoryCar.Update(createdCar.Id, updatedCar);

            // Assert
            Assert.Equal("Ford", actualCar.Vendor);
            Assert.Equal("Focus", actualCar.Model);
            Assert.Equal("Blue", actualCar.Color);
            Assert.Equal(75000, actualCar.KmDriven);
            Assert.Equal("Diesel", actualCar.EngineKind);
            Assert.Equal(120, actualCar.EnginePower);
            Assert.Equal(5, actualCar.Doors);
            Assert.True(actualCar.TowBar);
            Assert.Equal(2020, actualCar.Year);

            // Make sure the Id did not change
            Assert.Equal(createdCar.Id, actualCar.Id);
        }


        //Delete
        [Fact]
        public void DeleteCarTest_OK()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car car = new Car();

            Car createdCar = repositoryCar.Create(car);

            // Act
            Car deletedCar = repositoryCar.Delete(createdCar.Id);

            // Assert
            Assert.Equal(createdCar.Id, deletedCar.Id);
            //Check if it actually deleted 
            Assert.Empty(repositoryCar.ReadAll());
        }

        [Fact]
        public void ReadByIdCarTest_NotFound()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() => repositoryCar.ReadById(99));
        }

        [Fact]
        public void UpdateCarTest_NotFound()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            Car updatedCar = new Car();

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() => repositoryCar.Update(99, updatedCar));
        }

        [Fact]
        public void DeleteCarTest_NotFound()
        {
            // Arrange
            ICarRepository repositoryCar = new CarRepository();

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() => repositoryCar.Delete(99));
        }

        [Fact]
        public void Search_RedCars_OK()
        {
            // Arrange
            CarRepository repository = new CarRepository();

            repository.Create(new Car { Color = "Red" });
            repository.Create(new Car { Color = "Blue" });
            repository.Create(new Car { Color = "Red" });

            CarService service = new CarService(repository);

            // Act
            List<Car> result = service.Search(car => car.Color == "Red");

            // Assert
            Assert.Equal(2, result.Count);
        }
    }
}