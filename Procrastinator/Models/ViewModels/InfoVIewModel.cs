using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinator.Models.ViewModels
{
    public class InfoVIewModel
    {
        public IEnumerable<GymVisitor> GymVisitors { get; set; }
        public IEnumerable<GymCoach> GymCoaches { get; set; }
        public SelectList Coaches { get; set; }
        public string SecondName { get; set; }

        
    }
}
