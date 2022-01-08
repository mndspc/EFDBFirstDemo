using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
namespace AppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmpProfileBLL empProfileBLL = new EmpProfileBLL();
            //EmpProfile empProfile = new EmpProfile {EmpName="Sandeep",DateOfBirth=DateTime.Parse("05-07-2000"),Email="sandeep@gmail.com",DeptCode=102 };
            ////var result=empProfileBLL.SaveEmployee(empProfile);
            //var result = empProfileBLL.SaveEmployeeUsingSP(empProfile);
            //Console.WriteLine(result?"Employee Saved":"Error");

           var empProfile= empProfileBLL.SelectEmpByCode(107);
            Console.WriteLine($"{empProfile.EmpCode}\t{empProfile.EmpName}\t{empProfile.DateOfBirth}\t{empProfile.Email}\t{empProfile.DeptCode}");
            Console.ReadLine();
        }
    }
}
