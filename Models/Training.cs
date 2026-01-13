
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace benProj.Models
{
    class Training
    {
        public String Id { get; set; }
        public Course CourseRef { get; set; } // ריצה בטיילת
        public DateTime StartDate { get; set; } // יום ראשון ה5 למרס שעה 7:35
        public TimeSpan Duration { get; set; } // שעתיים


    }
}
