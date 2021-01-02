using MyWebSite.Data;
using MyWebSite.Models;
using System;
using System.Linq;

namespace MyWebSite.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Company.Any())
            {
                return;   // DB has been seeded
            }

            var company = new Company[]
            {
                new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
                new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
                new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
            };

            context.Company.AddRange(company);
            context.SaveChanges();

            var ads = new Ads[]
            {
                new Ads{AdsID=1050,Title="Chemistry",Tags="AC"},
                new Ads{AdsID=4022,Title="Microeconomics",Tags="AC"},
                new Ads{AdsID=4041,Title="Macroeconomics",Tags="AC"},
            };

            context.Ads.AddRange(ads);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{CompanyID=1,AdsID=1050,Grade=Grade.A},
                new Enrollment{CompanyID=1,AdsID=4022,Grade=Grade.C},
                new Enrollment{CompanyID=1,AdsID=4041,Grade=Grade.B},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
