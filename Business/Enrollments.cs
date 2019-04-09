using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Database;

namespace Business
{
    public class Enrollments
    {
        private EmpOrgEntities db = new EmpOrgEntities();

        public Enrollment Details(int? id)
        {
            try
            {
                Enrollment objMst = db.Enrollments.Find(id);
                return objMst;
            }
            catch (Exception ex)
            {
                Enrollment objMst = null;
                return objMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<Enrollment> FullDetails()
        {
            try
            {
                List<Enrollment> Dets = db.Enrollments.Include(e => e.DepMst).Include(e => e.EmployeeMst).Include(e => e.StateMst).ToList();
                return Dets;
            }
            catch (Exception ex)
            {
                List<Enrollment> Dets = null;
                return Dets;
            }
            finally
            {
                db.Dispose();
            }
        }

        public String CreateEnroll(Enrollment objMst)
        {
            try
            {
                db.Enrollments.Add(objMst);
                db.SaveChanges();
                return "0";
            }
            catch (Exception ex)
            {
                return "1";
            }
            finally
            {
                db.Dispose();
            }
        }

        public String EditEnroll(Enrollment objMst)
        {
            try
            {
                db.Entry(objMst).State = EntityState.Modified;
                db.SaveChanges();
                return "0";
            }
            catch (Exception ex)
            {
                return "1";
            }
            finally
            {
                db.Dispose();
            }
        }

        public String DeleteEnroll(int id)
        {
            try
            {
                Enrollment objMst = db.Enrollments.Find(id);
                db.Enrollments.Remove(objMst);
                db.SaveChanges();
                return "0";
            }
            catch (Exception ex)
            {
                return "1";
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
