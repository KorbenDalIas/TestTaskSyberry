using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Methods
    {
        //To convert date to US format we can use date.ToString(""MM/dd/yyyy"");
        public void ShowResults()
        {
            using (var employeesInfoEntities = new EmployeesInfoEntities())
            {
                foreach (DayOfWeek daysOfWeek in Enum.GetValues(typeof(DayOfWeek)))
                {
                    var employeeInfo = employeesInfoEntities.employees.ToList()
                            .Join(employeesInfoEntities.time_reports,
                                  ei => ei.id,
                                  tr => tr.employee_id,
                                  (ei, tr) => new
                                  {
                                      Name = ei.name,
                                      Date = tr.date,
                                      Hours = tr.hours
                                  }).Where(t => t.Date.DayOfWeek == daysOfWeek /*&& u.Hours != null (Необходимо для обработки случая, когда не указано кол-во часов отработки)*/)
                                  .OrderByDescending(t => t.Hours)
                                  .Take(3);
                    Console.Write(" {0, -9} |", daysOfWeek);
                    if (employeeInfo != null && employeeInfo.GetEnumerator().MoveNext())
                    {
                        foreach (var empInfo in employeeInfo)
                        {
                            Console.Write(" {0} ({1:f2} hours), ", empInfo.Name, empInfo.Hours);
                        }
                        Console.Write("|\n");
                    }
                    else
                    {
                        Console.WriteLine("Nobody worked this day \n");
                    }
                }
            }

        }
    }
}
