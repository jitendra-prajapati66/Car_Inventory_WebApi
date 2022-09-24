using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car_WebApi.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarRepository carRepository { get; }

        Task<bool> SaveAsync();
    }
}
