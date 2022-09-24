using Car_WebApi.DataAccess.Repository.IRepository;
using Car_WebApi.Model;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Car_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILog log;
        public CarController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            log = LogManager.GetLogger(typeof(CarController));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> getAllCar(string userId)
        {
            log.Info($"startin of getall method with user {userId}");
            var cars = await unitOfWork.carRepository.GetAllAsync(userId);
            return Ok(cars);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            await unitOfWork.carRepository.Add(car);
            await unitOfWork.SaveAsync();
            return Accepted();
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> updateCar([FromBody] Car car, [FromRoute] int id)
        {
            await unitOfWork.carRepository.update(id, car);
            await unitOfWork.SaveAsync();
            return Accepted();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            await unitOfWork.carRepository.Remove(id);
            await unitOfWork.SaveAsync();
            return Ok();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> findById(int id)
        {
            log.Info($"startin of findByid method with user {id}");
            var car = await unitOfWork.carRepository.FindById(id);
            return Ok(car);
        }

    }
}
