using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StateMsts
    {
        private EmpOrgEntities db = new EmpOrgEntities();

        public StateMst Details(int? id)
        {
            try
            {
                StateMst objMst = db.StateMsts.Find(id);
                return objMst;
            }
            catch (Exception ex)
            {
                StateMst objMst = null;
                return objMst;
            }
            finally
            {
                db.Dispose();
            }
        }

        public List<StateMst> FullDetails()
        {
            try
            {
                return db.StateMsts.ToList();
            }
            catch (Exception ex)
            {
                List<StateMst> empAddressDets = null;
                return empAddressDets;
            }
            finally
            {
                db.Dispose();
            }
        }

        public String CreateState(StateMst objMst)
        {
            try
            {
                db.StateMsts.Add(objMst);
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

        public String EditState(StateMst objMst)
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

        public String DeleteState(int id)
        {
            try
            {
                StateMst objMst = db.StateMsts.Find(id);
                db.StateMsts.Remove(objMst);
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
