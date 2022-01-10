using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpProfileDALRepository : IEmpProfileDALRepository<EmpProfile>
    {

        public bool SaveEmployee(EmpProfile empProfile)
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {

                    dbContext.EmpProfiles.Add(empProfile);
                    dbContext.SaveChanges();
                    return true;
                }

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool SaveEmployeeUsingSP(EmpProfile empProfile)
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                    dbContext.SP_SAVE_EMPLOYEE(empProfile.EmpCode, empProfile.EmpName, empProfile.DateOfBirth, empProfile.Email, empProfile.DeptCode);
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteEmployee(EmpProfile empProfile)
        {
            try
            {
                using (NordicEMSEntities dbContext=new NordicEMSEntities())
                {
                    var emp = dbContext.EmpProfiles.Where(x => x.EmpCode == empProfile.EmpCode).FirstOrDefault();
                    if (emp != null)
                    {
                        dbContext.EmpProfiles.Remove(emp);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch(Exception)
            {
                return false;
            }
        }

        public bool UpdateEmployee(EmpProfile empProfile)
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                    var emp = dbContext.EmpProfiles.Where(x => x.EmpCode == empProfile.EmpCode).FirstOrDefault();
                    if (emp != null)
                    {
                        EmpProfile oldEmp = new EmpProfile();
                        oldEmp.EmpCode = empProfile.EmpCode;
                        oldEmp.EmpName = empProfile.EmpName;
                        oldEmp.DateOfBirth=empProfile.DateOfBirth;
                        oldEmp.Email = empProfile.Email;
                        oldEmp.DeptCode = empProfile.DeptCode;

                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
      
        public EmpProfile GetEmployee(int id)
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                    // var emp = dbContext.EmpProfiles.Where(x => x.EmpCode == id).FirstOrDefault();
                    var emp = dbContext.SELECT_EMP_BY_CODE(id).FirstOrDefault();
                    if (emp != null)
                    {
                        return emp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ICollection<EmpProfile> GetAll()
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                    var emp = dbContext.EmpProfiles.ToList();
                    if (emp != null)
                    {
                        return emp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int MaxEmpCode()
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                    var count = dbContext.EmpProfiles.Max(x => x.EmpCode);
                    return  count; 
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<SELECT_EMP_WITH_DEPT> GetEmpWithDept()
        {
            try
            {
                using (NordicEMSEntities dbContext = new NordicEMSEntities())
                {
                   var result= dbContext.SELECT_EMP_WITH_DEPT.ToList();
                    //var result = dbContext.SELECT_EMP_WITH_DEPT.Where(x=>x.DeptCode==100);
                    return result.ToList(); 
                }
            }catch(Exception ex)
            {
                return null;
            }
        }
       
    }
}
