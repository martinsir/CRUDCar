using CRUDCar.Model;
using CRUDCar.RepoitoryCar;
using CRUDCar.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDCar.Services
{
    public class CarServices
    {
        private readonly CarRepositories _repo;
        private List<Car> carList;

        public Func<Car, bool> filter;

        public CarServices(CarRepositories repo)
        {
            _repo = repo;

            foreach (var item in carList)
            {
                //
            }
        }

        //skal den ikke
        public void Search()
        {
            //
        }
    }
}