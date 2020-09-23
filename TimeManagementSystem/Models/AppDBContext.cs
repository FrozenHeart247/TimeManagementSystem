using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TimeManagementSystem.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<User>Users { get; set; }//Свойство DbSet представляет собой коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных.

        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options) //Через параметр options в конструктор контекста данных будут передаваться настройки контекста.
        {
           // Database.EnsureCreated(); //В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных (если она отсутствует).
        }
    }
}
