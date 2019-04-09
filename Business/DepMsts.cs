using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DepMsts
    {

        private EmpOrgEntities db = new EmpOrgEntities();

        public DepMst Details(int? id)
        {
            try
            {
                DepMst depMst  = db.DepMsts.Find(id);
                return depMst;
            }
            catch (Exception ex)
            {
                DepMst depMst = null;
                return depMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<DepMst> FullDetails()
        {
            try
            {
                return db.DepMsts.ToList();
            }
            catch (Exception ex)
            {
                List<DepMst> msts = null;
                return msts;
            }
            finally
            {
                db.Dispose();
            }
        }

        public String CreateDep(DepMst objMst)
        {
            try
            {
                db.DepMsts.Add(objMst);
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

        public String EditDep(DepMst objMst)
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

        public String DeleteDep(int id)
        {
            try
            {
                DepMst depMst = db.DepMsts.Find(id);
                db.DepMsts.Remove(depMst);
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
