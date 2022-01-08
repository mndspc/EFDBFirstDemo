using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class EmpProfileBLL
    {
        EmpProfileDALRepository empProfileDAL=new EmpProfileDALRepository();

        public bool SaveEmployee(EmpProfile empProfile)
        {
            //  Your business logic goes here
            int maxEmpCode = empProfileDAL.MaxEmpCode();
            maxEmpCode++;
            empProfile.EmpCode = maxEmpCode;
            return empProfileDAL.SaveEmployee(empProfile);
        }

        public bool SaveEmployeeUsingSP(EmpProfile empProfile)
        {
            int maxEmpCode = empProfileDAL.MaxEmpCode();
            maxEmpCode++;
            empProfile.EmpCode = maxEmpCode;
            return empProfileDAL.SaveEmployeeUsingSP(empProfile);
        }
        public bool DeleteEmployee(EmpProfile empProfile)
        {
            return empProfileDAL.DeleteEmployee(empProfile);
        }
        
        public bool UpdateEmployee(EmpProfile empProfile)
        {
            return empProfileDAL.UpdateEmployee(empProfile);
        }

        public EmpProfile SelectEmpByCode(int empCode)
        {
           var emp= empProfileDAL.GetEmployee(empCode);
            return emp; 
        }

        public ICollection<EmpProfile> SelectAllEmployee()
        {
            return empProfileDAL.GetAll();
        }
    }
}
