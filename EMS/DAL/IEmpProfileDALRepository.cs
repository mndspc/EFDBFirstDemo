using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IEmpProfileDALRepository<EmpProfile>
    {
        bool SaveEmployee(EmpProfile empProfile);

        bool DeleteEmployee(EmpProfile empProfile);

        bool UpdateEmployee(EmpProfile empProfile);

        EmpProfile GetEmployee(int id);

        ICollection<EmpProfile> GetAll();
    }
}
