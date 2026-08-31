using CRUDCar.Model;
using CRUDCar.RepoitoryCar;
using Newtonsoft.Json.Linq;

namespace xUnitCarTest
{
    public class UnitTestCar
    {
        //CRUD testing
        //Create
        [Fact]
        public void CreatCarTest_OK()
        {
            //Arange
            RepoitoryCar repoitoryCar = new RepoitoryCar();
            Car car = new Car();
            car.Id = 10;
            int expectedCarId = 10;

            //Act
            repoitoryCar.Create(car);
            Car actualCar = repoitoryCar.GetById(10);

            //assert
            Assert.Equal(expectedCarId, actualCar.Id);
        }

        //Read
        [Fact]
        public void ReadCarTest_ID_OK()
        {
            int value = 10;

            //Arrange
            Car car = new Car();
            car.Id = value;

            //Act
            //expected
            int expectedCarId = value;

            //Assert
            int actualCarId = car.Id;
            Assert.Equal(expectedCarId, actualCarId);
        }

        //Update
        [Fact]
        public void UpdateCatTest_OK()
        {
            // check update method?
        }

        //Delete
        [Fact]
        public void Delete()
        {
            //Arrange
            Car car = new Car();
            int carId = 10;
            car.Id = carId;

            //Act
            int expetedCarID = 10;

            //Arrange
        }
    }
}