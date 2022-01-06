using School.data;
using School.Models.ClassRoomModel;
using ShoolApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service
{
    public class ClassRoomService
    {

        private readonly Guid _UserId;


        public ClassRoomService(Guid userId)
        {
            _UserId = userId;
        }

        //Create an instance of Classroom

        public bool CreateClassRoom(ClassRoomCreate classRoom)
        {
            ClassRoom classRoom1 = new ClassRoom()
            {
                OwnerID = _UserId,//We want the user who creates the Classroom to be the user who is logged in
                ClassRoomName = classRoom.ClassRomName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ClassRooms.Add(classRoom1);
              return   ctx.SaveChanges() == 1;

            }
        }

        //Get Classes

        public IEnumerable<ClassRoomListItem> GetClassrooms()
        {
            using( var ctx= new ApplicationDbContext())
            {
                var query = ctx.ClassRooms.Where(e => e.OwnerID == _UserId).Select(e => new ClassRoomListItem
                {
                    ClassRoomId = e.ClassRoomId,
                    ClassRomName = e.ClassRoomName
                }
                    ).ToList();
                return query.OrderBy(e => e.ClassRoomId);
            }
        }

        public ClassRoomDetails GetClassRoomById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ClassRooms
                        .Single(e => e.ClassRoomId == id);
                return
                    new ClassRoomDetails
                    {
                        ClassRoomId = entity.ClassRoomId,
                        ClassRomName = entity.ClassRoomName
                    };
            }
        }



        public bool UpdateClassRoom(ClassRoomEdit classRoom)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx.ClassRooms.Single(e => e.ClassRoomId == classRoom.ClassRoomId);
                entity.ClassRoomName = classRoom.ClassRomName;
                return ctx.SaveChanges() == 1;
            }


        }

        public bool DeleteClassRoom(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ClassRooms
                        .Single(e => e.ClassRoomId == id);

                ctx.ClassRooms.Remove(entity);

                return  ctx.SaveChanges() == 1;
            }
        }
    }
}
