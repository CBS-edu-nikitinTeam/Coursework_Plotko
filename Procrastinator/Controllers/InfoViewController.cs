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
        public ActionResult Index(int? coach, string name, SortState sortOrder = SortState.NameAsc)
        {
            ViewBag.Title = "Visitors info";
            //IQueryable<GymVisitor> users = db.GymVisitors.Include(p => p.CoachId);
            IQueryable<GymVisitor> users = db.GymVisitors.Where(p => p.CoachId != null);
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.LastName),
                SortState.CompanyAsc => users.OrderBy(s => s.LastName),
                SortState.CompanyDesc => users.OrderByDescending(s => s.LastName),
                _ => users.OrderBy(s => s.LastName),
            };

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
        public async Task<IActionResult> Sort(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<GymVisitor> users = db.GymVisitors.Where(x => x.CoachId!=null);

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            

            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.LastName),
                SortState.CompanyAsc => users.OrderBy(s => s.LastName),
                SortState.CompanyDesc => users.OrderByDescending(s => s.LastName),
                _ => users.OrderBy(s => s.LastName),
            };
            return View(await users.AsNoTracking().ToListAsync());
        }
        public IActionResult Pie()
        {
            ViewBag.Title = "Coaches and their clients";
            Random rnd = new Random();
            IQueryable<GymCoach> coaches = db.GymCoaches.Where(p => p.LastName != null);


            var lstModel = new List<SimpleReportViewModel>();
            foreach(GymCoach coach in coaches)
            {
                lstModel.Add(new SimpleReportViewModel
                {
                    DimensionOne = coach.LastName,
                    Quantity = db.GymVisitors.Where(a => a.CoachId == coach.Id).Count()
                }); 
            }
            
            return View(lstModel);
        }
        
    }
}

