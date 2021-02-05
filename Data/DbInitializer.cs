using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebSite.Models;

namespace MyWebSite.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Company.Any())
            {
                return;
            }

            var company = new Company[]
            {
                new Company { Title="Carson",Rating=4,EnrollmentDate=DateTime.Parse("2019-09-03"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=500, Tags="#AC" },
                new Company { Title="Carson",Rating=4,EnrollmentDate=DateTime.Parse("2020-08-07"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=700, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2020-07-09"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=950, Tags="#AC" },
                new Company { Title="Carson",Rating=3,EnrollmentDate=DateTime.Parse("2019-10-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=540, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2020-11-02"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=300, Tags="#AC" },
                new Company { Title="Carson",Rating=4,EnrollmentDate=DateTime.Parse("2019-12-10"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=450, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2020-03-15"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=250, Tags="#AC" },
                new Company { Title="Carson",Rating=3,EnrollmentDate=DateTime.Parse("2021-01-20"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=150, Tags="#AC" }
            };

            context.Company.AddRange(company);
            context.SaveChanges();

            var owner = new Owner[]
            {
                new Owner {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID
                },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID
                    },
                    new Owner {
                        CompanyID = company.Single(s => s.Title == "Alonso").ID
                    },
                    new Owner {
                        CompanyID = company.Single(s => s.Title == "Alonso").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Alonso").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Anand").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Anand").ID
                    },
                new Owner {
                    CompanyID = company.Single(s => s.Title == "Barzdukas").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Li").ID
                    },
                    new Owner {
                    CompanyID = company.Single(s => s.Title == "Justice").ID
                    }
            };

            foreach (Owner e in owner)
            {
                var ownerInDataBase = context.Owner.Where(
                    s =>
                            s.Company.ID == e.CompanyID).SingleOrDefault();
                if (ownerInDataBase == null)
                {
                    context.Owner.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
