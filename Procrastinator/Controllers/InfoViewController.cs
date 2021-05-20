using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Procrastinator.Models;
using Procrastinator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinator.Controllers
{
    public class InfoViewController : Controller
    {
        ProcrastinatorContext db;
        public InfoViewController(ProcrastinatorContext context)
        {
            db = context;
            //GymCoach sidorov = new GymCoach { Id = 4, LastName = "Abramovich" };
            //GymCoach sidorov1 = new GymCoach { Id = 5, LastName = "Gavrilov" };
            //GymCoach sidorov2 = new GymCoach { Id = 6, LastName = "Shtepa" };
            //GymCoach sidorov3 = new GymCoach { Id = 7, LastName = "Naumeko" };
            //GymCoach sidorov4 = new GymCoach { Id = 8, LastName = "Boyko" };
            //GymCoach sidorov5 = new GymCoach { Id = 9, LastName = "Nikolaev" };
            //GymCoach sidorov6 = new GymCoach { Id = 10, LastName = "Stepanov" };
            //db.GymCoaches.AddRange(sidorov, sidorov1, sidorov2, sidorov3, sidorov4, sidorov5, sidorov6);
            //db.SaveChanges();
            // добавляем начальные данные
            if (db.GymCoaches.Count() == 0)
            {
                GymCoach ivanov = new GymCoach { Id = 1, LastName="Ivanov" };
                GymCoach petrov = new GymCoach { Id = 2, LastName = "Petrov" };
                GymCoach sidorov = new GymCoach { Id = 3, LastName = "Sidorov" };
                                

                GymVisitor visitor1 = new GymVisitor { Id=1, FirstName="Alex", LastName="Saint", Phone="+380962213", CoachId=1 };
                GymVisitor visitor2 = new GymVisitor { Id=2, FirstName="Pavel", LastName="Rudenko", Phone="+380962213", CoachId=1 };
                GymVisitor visitor3 = new GymVisitor { Id = 3, FirstName = "Ivan", LastName = "Bolov", Phone = "+3805652213", CoachId = 2 };
                GymVisitor visitor4 = new GymVisitor { Id = 4, FirstName = "Dima", LastName = "Polov", Phone = "+3804542213", CoachId = 2 };
                GymVisitor visitor5 = new GymVisitor { Id = 5, FirstName = "Vlad", LastName = "Yhefe", Phone = "+3804842213", CoachId = 2 };
                GymVisitor visitor6 = new GymVisitor { Id = 6, FirstName = "Jacob", LastName = "Hvebw", Phone = "+3806762213", CoachId = 3 };
                GymVisitor visitor7 = new GymVisitor { Id = 7, FirstName = "Alex", LastName = "Bdheuw", Phone = "+3878782213", CoachId = 2 };

                db.GymCoaches.AddRange(ivanov, petrov, sidorov);
                db.GymVisitors.AddRange(visitor1, visitor2, visitor3, visitor4, visitor5, visitor6, visitor7);
                db.SaveChanges();
            }
        }
        public ActionResult Index(int? coach, string name)
        {
            //IQueryable<GymVisitor> users = db.GymVisitors.Include(p => p.CoachId);
            IQueryable<GymVisitor> users = db.GymVisitors.Where(p => p.CoachId != null);
            
            if (coach != null && coach != 0)
            {
                users = users.Where(p => p.CoachId == coach);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.LastName.Contains(name));
            }

            List<GymCoach> coaches = db.GymCoaches.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            coaches.Insert(0, new GymCoach { Id = 0, LastName = "All" });
            

            InfoVIewModel viewModel = new InfoVIewModel
            {
                GymVisitors = users.ToList(),
                Coaches = new SelectList(coaches, "Id", "LastName"),
                SecondName = name,
                GymCoaches = coaches
               
            };

            
            return View(viewModel);
        }
    }
}

///var balance = (from a in context.Accounts
///               join c in context.Clients on a.UserID equals c.UserID
///               where c.ClientID == yourDescriptionObject.ClientID
///               select a.Balance)
///              .SingleOrDefault();