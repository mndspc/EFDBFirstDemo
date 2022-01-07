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
                return true;
            }
        }
        public bool DeleteEmployee(EmpProfile empProfile)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(EmpProfile empProfile)
        {
            throw new NotImplementedException();
        }
      
        public EmpProfile GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EmpProfile> GetAll()
        {
            throw new NotImplementedException();
        }



    }
}
