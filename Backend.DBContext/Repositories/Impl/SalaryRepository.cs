using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(IDbContextFactory contextFactory) : base(contextFactory)
        {
        }

        public Salary Insert(User user)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                if (user == null)
                    return null;

                var salary = new Salary(user);
                salary.Created = DateTime.UtcNow;
                salary.Modified = DateTime.UtcNow;

                var currentMonth = DateTime.UtcNow.Month;
                var currentYear = DateTime.UtcNow.Year;

                var overTimes = context.Set<OverTime>().Where(o => o.UserId == user.Id && currentMonth.Equals(o.Month.Month)
                    && currentYear.Equals(o.Month.Year)).ToList();

                if (overTimes.Any())
                {
                    long total = 0;

                    foreach (var overTime in overTimes)
                    {
                        total += (long)(overTime.WorkTime * user.HourSalary);
                    }

                    salary.OTSalary = total;
                }

                context.Set<Salary>().Add(salary);
                if (context.SaveChanges() > 0)
                    return salary;

                return null;
            }
        }
    }
}
