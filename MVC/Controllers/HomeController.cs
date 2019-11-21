using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microservice.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ui.Contracts;
using ui.ViewModels;

namespace MVC.Controllers
{

    public class HomeController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IUserServices _userServices;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public HomeController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IUserServices userServices, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _userServices = userServices;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModelForPostDto model)
        {
            // return error
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Login failed.");
                return View();
            }

            var result = _userServices.ValidatePassword(model);
            // return error
            if (!result)
            {
                ModelState.AddModelError("", "Login failed.");
                return View();
            }

            //return token cookie
            Response.Cookies.Append("jwtToken", model.Token,
                new CookieOptions { Expires = DateTime.Now.AddDays(7) });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Append("jwtToken",
                "", new CookieOptions {Expires = DateTime.Now.AddDays(-1)});
            
            return RedirectToAction("Login", "Home");
        }


        [Authorize]
        [HttpGet]
        [Route("home/index")]
        [Route("Home")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();
            //get customers
            var usersApiUri = _configuration["CarsApiRul"] + "api/Customer";
            var httpClient = _httpClientFactory.CreateClient();

            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["jwtToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + cookie.ToString());

            //httpClient.DefaultRequestHeaders.Add("ApiKey", _configuration["ApiKey"]);

            var response = await httpClient.GetAsync(usersApiUri);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerForReturnDto>>(data);
                model.Customers = customers;
            }

            //get cars
            var carsApiUri = _configuration["CarsApiRul"] + "api/cars";
            var jsonModel = JsonConvert.SerializeObject(new { CustomerId = 0, StatusId = 0 }, Formatting.Indented);
            var postContent = new StringContent(jsonModel, System.Text.Encoding.UTF8, "application/json");
            httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + cookie.ToString());
            //httpClient.DefaultRequestHeaders.Add("ApiKey", _configuration["ApiKey"]);

            response = await httpClient.PostAsync(carsApiUri, postContent);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<CarForReturnDto>>(data);
                model.Cars = cars;
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("home/index")]
        [Route("Home")]
        [Route("")]
        public async Task<IActionResult> Index(IndexViewModel model)
        {

            //get customers
            var usersApiUri = _configuration["CarsApiRul"] + "api/Customer";
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(usersApiUri);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerForReturnDto>>(data);
                model.Customers = customers;
            }

            //get cars
            var carsApiUri = _configuration["CarsApiRul"] + "api/cars";
            var jsonModel = JsonConvert.SerializeObject(new { CustomerId = model.CustomerId, StatusId = model.StatusId }, Formatting.Indented);
            var postContent = new StringContent(jsonModel, System.Text.Encoding.UTF8, "application/json");
            httpClient = _httpClientFactory.CreateClient();
            response = await httpClient.PostAsync(carsApiUri, postContent);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<CarForReturnDto>>(data);
                model.Cars = cars;
            }

            return View(model);
        }
    }
}
