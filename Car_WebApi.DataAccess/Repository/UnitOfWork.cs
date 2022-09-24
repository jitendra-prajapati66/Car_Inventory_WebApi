using Car_WebApi.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Car_WebApi.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDBContext _db;
        public ICarRepository carRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            carRepository = new CarRepository(_db);
        }
        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync()>0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
