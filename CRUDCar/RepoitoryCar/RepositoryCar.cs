using CRUDCar.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

//ups glemte folder *ClassLibeerary*
namespace CRUDCar.RepoitoryCar
{
    public class RepoitoryCar()
    {
        private List<Car> carsList = new List<Car>();

        public Car Create(Car car)
        {
            carsList.Add(car);
            return car;
        }

        // get by id??
        public List<Car> Read()
        {
            return carsList;
        }

        public Car GetById(int id)
        {
            for (int i = 0; i < carsList.Count; i++)
            {
                if (carsList[i].Id == id)
                {
                    return carsList[i];
                }
            }
            return null;
        }

        public void Update(Car car)
        {
            for (int i = 0; i < carsList.Count; i++)
            {
                if (carsList[i].Id == car.Id)
                {
                    carsList[i].Vendor = car.Vendor;
                    carsList[i].Color = car.Color;

                    carsList[i].KmDriven = car.KmDriven;
                    carsList[i].EngineKind = car.EngineKind;

                    carsList[i].EnginePower = car.EnginePower;
                    carsList[i].Doors = car.Doors;

                    carsList[i].TowBar = car.TowBar;

                    carsList[i].Year = car.Year;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            carsList.Remove(GetById(id));
        }

        public void Add(Car car)
        {
            carsList.Add(car);
        }

        public List<Car> GetAll()
        {
            return carsList;
        }
    }
}