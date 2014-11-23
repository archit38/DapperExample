using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Dapper
{
   public interface IEmployeeDashBoard
    {
        List<Employee> GetAll();
        List<Employee> Find(string name = "");
        Employee Find(int? id);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        void Remove(int id);
    }
}
