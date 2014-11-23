using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperExample.Dapper
{
    public class EmployeeDashBoard : IEmployeeDashBoard
    {
        private IDbConnection _db = new SqlConnection("Server=a1e475e1-89c5-4d63-987d-a3e00181b23d.sqlserver.sequelizer.com;Database=dba1e475e189c54d63987da3e00181b23d;User ID=kdfklobzpdolmlem;Password=5K6bZqAwQju5Lp4fnQRRbyZRyp6iPXDwrsjg7GpiNYQqngswnBoVRABETnKJssPZ;");
        public List<Employee> GetAll()
        {
            List < Employee > empList= this._db.Query<Employee>("SELECT * FROM tblEmployee").ToList();
            return empList;
        }

        public List<Employee> Find(String name)
        {
            string query = String.Format("SELECT * FROM tblEmployee WHERE Empname LIKE '%{0}%'",name);
            return this._db.Query<Employee>(query).ToList();
        }

        public Employee Find(int? id)
        {
            string query = "SELECT * FROM tblEmployee WHERE EmpID = " + id + "";
            return this._db.Query<Employee>(query).SingleOrDefault();
        }
        public Employee Add(Employee employee)
        {
            var sqlQuery = "INSERT INTO tblEmployee (EmpName, EmpScore) VALUES(@EmpName, @EmpScore); " + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var employeeId = this._db.Query<int>(sqlQuery, employee).Single();
            employee.EmpID = employeeId;
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var sqlQuery =
            "UPDATE tblEmployee " +
            "SET EmpName = @EmpName, " +
            " EmpScore = @EmpScore " +
            "WHERE EmpID = @EmpID";
            this._db.Execute(sqlQuery, employee);
            return employee;
        }

        public void Remove(int id)
        {
            var sqlQuery =("Delete From tblEmployee Where EmpID = " + id + "");
            this._db.Execute(sqlQuery);
        }
    }
}