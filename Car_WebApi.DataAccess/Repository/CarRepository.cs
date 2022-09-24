using Car_WebApi.DataAccess.Repository.IRepository;
using Car_WebApi.Model;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_WebApi.DataAccess.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly ILog logger;
        public CarRepository(ApplicationDBContext db)
        {
            _db = db;
            logger = LogManager.GetLogger(typeof(CarRepository));
        }
        public async Task Add(Car car)
        {
            try
            {
                await _db.Car.AddAsync(car);
                logger.Info($"car added succesfully {car}");
            }
            catch(Exception ex)
            {
                logger.Error($"Error in Add Method ${ex.Message}");
            }
        }

        public async Task<Car> FindById(int id)
        {
            try
            {
                if (id != 0)
                {
                    var carById = await _db.Car.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (carById != null)
                    {
                        logger.Info($"car removed succesfully {carById.Brand}");
                        return carById;
                        
                    }
                    return new Car();
                }
                return new Car();
            }
            catch (Exception ex)
            {
                logger.Error($"Error in findById Method ${ex.Message}");
                return new Car();
            }
        }

        public async Task<IEnumerable<Car>> GetAllAsync(string userId)
        {
           
            try
            {
                var Cars = await _db.Car.Where(x => x.UserId == userId).ToListAsync();
                return Cars;
            }
            catch (Exception ex)
            {
                logger.Error($"Error in getall Method ${ex.Message}");
                return new List<Car>();
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                if (id != 0)
                {
                    var carById = await _db.Car.FindAsync(id);
                    if(carById!=null)
                    {
                        _db.Car.Remove(carById);
                        logger.Info($"car removed succesfully {carById}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Error in remove Method ${ex.Message}");
            }

        }

        public async Task update(int id, Car car)
        {
         
            try
            {
                var newCar = await _db.Car.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (newCar != null)
                {

                    newCar.Brand = car.Brand;
                    newCar.Model = car.Model;
                    newCar.UserId = car.UserId;
                    newCar.Year = car.Year;
                    newCar.Price = car.Price;
                    newCar.isNew = car.isNew;

                }
                _db.Car.Update(newCar);
                logger.Info($"car updated succesfully with car: {newCar}");
            }
            catch (Exception ex)
            {
                logger.Error($"Error in remove Method ${ex.Message}");
            }

        }

      
    }
}
