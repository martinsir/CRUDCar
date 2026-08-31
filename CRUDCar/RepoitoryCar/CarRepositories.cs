using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDCar.RepoitoryCar
{
    public class CarRepositories : ICarRepositories
    {
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}