using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int salary  { get; set; }
    }
    public class EmployeeBL
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                if (i > 5)
                {
                    empList.Add(new Employee()
                    {
                        Id = i,
                        Name = "Name"+i,
                        salary = 100+i,
                        Gender="Male"
                    });
                }
                else
                {
                    empList.Add(new Employee()
                    {
                        Id = i,
                        Name = "Name" + i,
                        salary = 100 + i,
                        Gender = "FeMale"
                    });
                }
            }
            
            return empList;
        }
    }
}