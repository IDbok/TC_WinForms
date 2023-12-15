using Microsoft.EntityFrameworkCore;
using TcDbConnector;
using TcModels.Models;
using TcModels.Models.IntermediateTables;
using TcModels.Models.TcContent;

namespace TC_WinForms.DataProcessing
{
    public class DbConnector
    {
        //private MyDbContext context; //
        public DbConnector()
        {

        }
        public void UpdateCurrentTc(int id)
        {
            Program.CurrentTc = GetObject<TechnologicalCard>(id);
        }
        public void Update<T>(T updatingobj)
        {
            using (var context = new MyDbContext())
            {
                // todo add mecanism to increase version of object if it was version field

                context.Update(updatingobj);
                context.SaveChanges();
            }
        }
        public void Add<T>(T addingobj)
        {
            using (var context = new MyDbContext())
            {
                context.Add(addingobj);
                context.SaveChanges();
            }
        }

        public int GetLastId<T>() where T : class, IIdentifiable
        {
            using (var context = new MyDbContext())
            {
                int lastId;
                if (context.Set<T>().Count() == 0) lastId = 0;
                else lastId = context.Set<T>().OrderBy(a => a.Id).Last().Id;
                return lastId;
            }
        }
        public List<T> GetList<T>() where T : class, IIdentifiable
        {
            try
            {
                // todo - Db connection error holder 
                using (var context = new MyDbContext())
                {
                    if (typeof(T) == typeof(TechnologicalProcess))
                        return context.Set<TechnologicalProcess>()
                                        .Include(tp => tp.TechnologicalCards)
                                        .Cast<T>()
                                        .ToList();

                    else if (typeof(T) == typeof(TechnologicalCard))
                        return context.Set<TechnologicalCard>()
                                        .Include(tc => tc.Staffs)
                                        .Include(tc => tc.Components)
                                        .Include(tc => tc.Tools)
                                        .Include(tc => tc.Machines)
                                        .Include(tc => tc.Protections)
                                        //.Include(tc => tc.WorkSteps)
                                        .Cast<T>()
                                        .ToList();
                    else return context.Set<T>().ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public T? GetObject<T>(int id) where T : class, IIdentifiable
        {
            using (var context = new MyDbContext())
            {
                if (typeof(T) == typeof(TechnologicalProcess))
                    return context.Set<TechnologicalProcess>()
                                    .Where(tp => tp.Id == id)
                                    .Include(tp => tp.TechnologicalCards)
                                        .ThenInclude(tc => tc.Staffs)
                                    .Include(tp => tp.TechnologicalCards)
                                        .ThenInclude(tc => tc.Components)
                                    .Include(tp => tp.TechnologicalCards)
                                        .ThenInclude(tc => tc.Tools)
                                    .Include(tp => tp.TechnologicalCards)
                                        .ThenInclude(tc => tc.Machines)
                                    .Include(tp => tp.TechnologicalCards)
                                        .ThenInclude(tc => tc.Protections)
                                    //.Include(tp => tp.TechnologicalCards)
                                    //    .ThenInclude(tc => tc.WorkSteps)
                                    .Cast<T>()
                                    .FirstOrDefault();

                else if (typeof(T) == typeof(TechnologicalCard))
                    return context.Set<TechnologicalCard>()
                                    .Where(tc => tc.Id == id)
                                    .Include(tc => tc.Staffs)
                                    .Include(tc => tc.Components)
                                    .Include(tc => tc.Tools)
                                    .Include(tc => tc.Machines)
                                    .Include(tc => tc.Protections)
                                    //.Include(tc => tc.WorkSteps)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else return context.Set<T>().Where(tc => tc.Id == id).FirstOrDefault();
            }


        }
        public T? GetObject<T, C>(int TC_id, int obj_id) where T : class, IIntermediateTable<TechnologicalCard, C>
            where C : class, IIdentifiable
        {
            using (var context = new MyDbContext())
            {
                if (typeof(T) == typeof(Staff_TC))
                    return context.Set<Staff_TC>()
                                    .Where(sttc => sttc.ParentId == TC_id && sttc.ChildId == obj_id)
                                    .Include(sttc => sttc.Parent)
                                    .Include(sttc => sttc.Child)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else if (typeof(T) == typeof(Component_TC))
                    return context.Set<Component_TC>()
                                    .Where(ctc => ctc.ParentId == TC_id && ctc.ChildId == obj_id)
                                    .Include(ctc => ctc.Parent)
                                    .Include(ctc => ctc.Child)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else if (typeof(T) == typeof(Tool_TC))
                    return context.Set<Tool_TC>()
                                    .Where(ttc => ttc.ParentId == TC_id && ttc.ChildId == obj_id)
                                    .Include(ttc => ttc.Parent)
                                    .Include(ttc => ttc.Child)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else if (typeof(T) == typeof(Machine_TC))
                    return context.Set<Machine_TC>()
                                    .Where(mtc => mtc.ParentId == TC_id && mtc.ChildId == obj_id)
                                    .Include(mtc => mtc.Parent)
                                    .Include(mtc => mtc.Child)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else if (typeof(T) == typeof(Protection_TC))
                    return context.Set<Protection_TC>()
                                    .Where(ptc => ptc.ParentId == TC_id && ptc.ChildId == obj_id)
                                    .Include(ptc => ptc.Parent)
                                    .Include(ptc => ptc.Child)
                                    .Cast<T>()
                                    .FirstOrDefault();
                else return null;
            }
        }
        //public Staff_TC? GetObject(int TC_id, int obj_id)
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        return context.Set<Staff_TC>()
        //                        .Where(sttc => sttc.ParentId == TC_id && sttc.ChildId == obj_id)
        //                        .Include(sttc => sttc.Parent)
        //                        .Include(sttc => sttc.Child)
        //                        .Cast<Staff_TC>()
        //                        .FirstOrDefault();
        //    }
        //}
    }
}
