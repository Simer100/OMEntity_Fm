using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Business
{
    public class EmpAddressDets
    {
        private EmpOrgEntities db = new EmpOrgEntities();

        public EmpAddressDet Details(int? id)
        {
            try
            {
                EmpAddressDet objMst = db.EmpAddressDets.Find(id);
                return objMst;
            }
            catch (Exception ex)
            {
                EmpAddressDet objMst = null;
                return objMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<EmpAddressDet> FullDetails()
        {
            try
            {
                List<EmpAddressDet> empAddressDets = db.EmpAddressDets.Include(e => e.EmployeeMst).Include(e => e.StateMst).ToList();
                return empAddressDets;
            }
            catch (Exception ex)
            {
                List<EmpAddressDet> empAddressDets = null;
                return empAddressDets;
            }
            finally
            {
                db.Dispose();
            }
        }

        public String CreateEmpAdd(EmpAddressDet objMst)
        {
            try
            {
                db.EmpAddressDets.Add(objMst);
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

        public String EditEmpAdd(EmpAddressDet objMst)
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

        public String DeleteEmpAdd(int id)
        {
            try
            {
                EmpAddressDet objMst = db.EmpAddressDets.Find(id);
                db.EmpAddressDets.Remove(objMst);
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
