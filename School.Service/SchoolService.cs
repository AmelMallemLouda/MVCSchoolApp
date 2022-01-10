using School.data;
using School.Models.ClassRoomModel;
using School.Models.SchoolModel;
using School.Models.TeacherModel;
using ShoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service
{
   public class SchoolService
    {
        private readonly Guid _userId;

        public SchoolService(Guid userId)
        {
            _userId = userId;
        }


        //Create School

        public bool CreateSchool(SchoolCreate model)
        {
            var entity = new Schools
            {
                OwnerID = _userId,
                SchoolName = model.SchoolName

            };

            using(var ctx =new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
               return  ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SchoolListItem> GetAllSchools()
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx.Schools.Where(e => e.OwnerID == _userId).Select(e => new SchoolListItem

                {
                    SchoolName = e.SchoolName,
                    SchoolId = e.SchoolId
                }).ToList();
                return query;
            }
        }

        public SchoolDetails GetSchoolById(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var query = ctx.Schools.Single(e => e.SchoolId == id && e.OwnerID == _userId);

                return new SchoolDetails
                {
                    SchoolId= query.SchoolId,
                    SchoolName = query.SchoolName,
                    ClassRooms = query.ClassRooms.Select(x => new ClassRoomListItem
                    {
                        ClassRomName = x.ClassRoomName,
                        ClassRoomId = x.ClassRoomId

                    }).ToList(),
                    Teachers=query.Teachers.Select(z => new TeacherListItem
                    {
                        TeacherId=z.TeacherId,
                        TeacherName=z.TeacherName
                    }).ToList()
                };
            }
        }


        public bool UpdateSchool(SchoolEdit model)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var entity = ctx.Schools.Single(e => e.SchoolId == model.SchoolId && e.OwnerID == _userId);
               
                
                    entity.SchoolName = model.SchoolName;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteSchool(int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var query = ctx.Schools.Single(e => e.SchoolId == id && e.OwnerID == _userId);

                ctx.Schools.Remove(query);
                return ctx.SaveChanges() == 1;
            }
        }





    }
}
