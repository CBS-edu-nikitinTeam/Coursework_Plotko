using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Procrastinator.Models;
using Procrastinator.Models.ViewModels;
using Procrastinator.Settings;
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
            Config.SidebarVisible = false;
            db = context;
            
            // An exemple of adding initial data
            //if (db.GymCoaches.Count() == 0)
            //{
            //    GymCoach ivanov = new GymCoach { Id = 1, LastName="Ivanov" };
            //    GymCoach petrov = new GymCoach { Id = 2, LastName = "Petrov" };
            //    GymCoach sidorov = new GymCoach { Id = 3, LastName = "Sidorov" };
            //                    
            //
            //    GymVisitor visitor1 = new GymVisitor { Id=1, FirstName="Alex", LastName="Saint", Phone="+380962213", CoachId=1 };
            //    GymVisitor visitor2 = new GymVisitor { Id=2, FirstName="Pavel", LastName="Rudenko", Phone="+380962213", CoachId=1 };
            //    
            //
            //    db.GymCoaches.AddRange(ivanov, petrov, sidorov);
            //    db.GymVisitors.AddRange(visitor1, visitor2);
            //    db.SaveChanges();
            //}
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