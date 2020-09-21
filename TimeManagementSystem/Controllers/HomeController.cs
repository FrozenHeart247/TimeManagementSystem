using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeManagementSystem.Models;

namespace TimeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        #region HZ
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

//Для взаимодействия с базой данных, в контроллере определяется 
//переменная контекст данных ApplicationContext db. Причем поскольку в классе Startup в методе 
//ConfigureServices контекст данных устанавливается как сервис, 
//то в конструкторе контроллера мы можем получить переданный контекст данных.
        private AppDBContext db;
        public HomeController(AppDBContext context)  //?Типа связываем конекст с конструктором?
        {
            db = context;
        }
        //Теперь добавим в контроллер три метода, которые будут добавлять новый объект в базу данных и выводить из нее все объекты:
        public async Task<IActionResult> Index()
        {
 //С помощью метода db.Users.ToListAsnc() мы будем получать объекты из бд, создавать из них список и передавать в представление.
            return View(await db.Users.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        //При помощи метода db.Users.Add() для данных из объекта user формируется sql-выражение INSERT, 
        //а метод db.SaveChangesAsync() выполняет это выражение, тем самым добавляя данные в базу данных.
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
