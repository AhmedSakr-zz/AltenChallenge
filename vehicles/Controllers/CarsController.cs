using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Controllers
{

    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarServices _carServices;
        private readonly IFakeSendCarStatusServices _fakeSendCarStatusServices;

        public CarsController(ICarServices carServices, IFakeSendCarStatusServices fakeSendCarStatusServices)
        {
            _carServices = carServices;
            _fakeSendCarStatusServices = fakeSendCarStatusServices;
        }

        [Authorize]
        [HttpPost]
        [Route("api/cars")]
        public async Task<IActionResult> GetCars([FromBody]CarQueryDto carQueryDto)
        {
            if (carQueryDto == null)
                return NoContent();

            return Json(await _carServices.GetCars(carQueryDto));
        }

        [Authorize]
        [HttpGet]
        [Route("api/Customer")]
        public async Task<IActionResult> GetCustomers()
        {
            // paging and listing
            var customerQueryDto=new CustomerQueryDto();
            return Json(await _carServices.GetCustomers(customerQueryDto));
        }


        [HttpGet]
        [Route("service/start")]
        public JsonResult StartTask()
        {
            BackgroundJob.Enqueue(() => _fakeSendCarStatusServices.Start());
            return new JsonResult(new { Service = "Started" });
        }


        [HttpGet]
        [Route("/home/index")]
        [Route("/home")]
        [Route("")]
        public JsonResult Index()
        {
            return new JsonResult(new { Alten_Challenge = "vehicle Microservice is working" });
        }


    }
}