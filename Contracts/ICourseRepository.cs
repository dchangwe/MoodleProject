using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
  public  interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);
        Course GetCourse(Guid courseId, bool trackChanges);
        void CreateCourse(Course course);
    }
}
