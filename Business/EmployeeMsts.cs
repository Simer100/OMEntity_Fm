using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeeMsts
    {
        private EmpOrgEntities db = new EmpOrgEntities();

        public EmployeeMst Details(int? id)
        {
            try
            {
                EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
                return employeeMst;
            }
            catch (Exception ex)
            {
                EmployeeMst employeeMst = null;
                return employeeMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<EmployeeMst> FullDetails()
        {
            try
            {
                return db.EmployeeMsts.ToList();
            }
            catch (Exception ex)
            {
                List<EmployeeMst> employeeMst = null;
                return employeeMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public String CreateEmployee(EmployeeMst employeeMst)
        {
            try
            {
                db.EmployeeMsts.Add(employeeMst);
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

        public String EditEmployee(EmployeeMst employeeMst)
        {
            try
            {
                db.Entry(employeeMst).State = EntityState.Modified;
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

        public String DeleteEmployee(int id)
        {
            try
            {
                EmployeeMst employeeMst = db.EmployeeMsts.Find(id);
                db.EmployeeMsts.Remove(employeeMst);
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
