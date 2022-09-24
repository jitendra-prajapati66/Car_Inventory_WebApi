using Car_WebApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car_WebApi.DataAccess.Repository.IRepository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync(string userid);

        Task Add(Car car);
        Task Remove(int id);
        Task update(int id, Car car);

        Task<Car> FindById(int id);

    }
}
