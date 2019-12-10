using System;
using System.Collections.Generic;

namespace TargetProject
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
