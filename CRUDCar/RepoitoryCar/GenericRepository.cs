using CRUDCar.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDCar.RepoitoryCar
{
    public class GenericRepository<T> where T : IModelWithId
    {
        private List<T> items = new List<T>();

        //CRUD - C
        // Asks for null check because in IModelWithId has only get id
        public T Create(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            items.Add(item);
            return item;
        }

        // CRUD - R
        public List<T> ReadAll()
        {
            return new List<T>(items);
        }

        public T ReadById(int id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id.Equals(id))
                {
                    return items[i];
                }
            }
            throw new KeyNotFoundException();
        }

        //CRUD - U
        public T Update(int id, T updatedItem)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id.Equals(id))
                {
                    items[i] = updatedItem;
                    return items[i];
                }
            }
            throw new KeyNotFoundException();
        }

        //CRUD - D
        public T Delete(int id)
        {
            T item = ReadById(id);
            items.Remove(item);
            return item;
        }
    }
}