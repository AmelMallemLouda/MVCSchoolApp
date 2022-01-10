using School.data;
using School.Models.TeacherModel;
using ShoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service
{
    public class TeacherService
    {

        private readonly Guid _UserId;


        public TeacherService(Guid userId)
        {
            _UserId = userId;
        }

        //Create an instance of Classroom

        public bool CreateTeacher(TeacherCreate model)
        {
            Teacher teach = new Teacher()
            {
                OwnerID = _UserId,//We want the user who creates the Classroom to be the user who is logged in
                TeacherName = model.TeacherName,
                SchoolId=model.SchoolId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(teach);
                return ctx.SaveChanges() == 1;

            }
        }

        //Get Classes

        public IEnumerable<TeacherListItem> GetAllTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Teachers.Where(e => e.OwnerID == _UserId).Select(e => new TeacherListItem
                {
                    TeacherId = e.TeacherId,
                    TeacherName = e.TeacherName,
                    
                }
                    ).ToList();
                return query.OrderBy(e => e.TeacherId);
            }
        }

        public TeacherDetails GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);
                return
                    new TeacherDetails
                    {
                        TeacherId = entity.TeacherId,
                        TeacherName = entity.TeacherName,
                        SchoolId=entity.SchoolId

                    };
            }
        }



        public bool UpdateTeacher(TeacherEdit teach)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Teachers.Single(e => e.TeacherId == teach.TeacherId);
                entity.TeacherName = teach.TeacherName;
                entity.SchoolId = teach.SchoolId;
                return ctx.SaveChanges() == 1;
            }


        }

        public bool DeleteTeacher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teachers
                        .Single(e => e.TeacherId == id);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
