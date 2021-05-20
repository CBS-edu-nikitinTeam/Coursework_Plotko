using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinator.Models
{
    public class DisplayedGymVisitor:GymVisitor
    {
        public GymCoach Coach { get; set; }
    }
}
