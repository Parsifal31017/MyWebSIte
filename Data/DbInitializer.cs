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
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Company.Any())
            {
                return;   // DB has been seeded
            }

            var company = new Company[]
            {
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" },
                new Company { Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC" }
            };

            context.Company.AddRange(company);
            context.SaveChanges();

            var users = new Users[]
            {
                new Users { FirstMidName = "Kim",     LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11"), Age= 20, Country="Belarus", City="Minsk",Email="viki@gmail.com", AboutMe="Programmer" },
                new Users { FirstMidName = "Fadi",    LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06"), Age= 20, Country="Belarus", City="Minsk",Email="viki@gmail.com", AboutMe="Programmer" },
                new Users { FirstMidName = "Roger",   LastName = "Harui", HireDate = DateTime.Parse("1998-07-01"), Age= 20, Country="Belarus", City="Minsk",Email="viki@gmail.com", AboutMe="Programmer" },
                new Users { FirstMidName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("2001-01-15"), Age= 20, Country="Belarus", City="Minsk",Email="viki@gmail.com", AboutMe="Programmer" },
                new Users { FirstMidName = "Roger",   LastName = "Zheng", HireDate = DateTime.Parse("2004-02-12"), Age= 20, Country="Belarus", City="Minsk",Email="viki@gmail.com", AboutMe="Programmer" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    UsersID  = users.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    UsersID  = users.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    UsersID  = users.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    UsersID  = users.Single( i => i.LastName == "Kapoor").ID }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var ads = new Ads[]
            {
                new Ads {AdsID = 1050, Title = "Chemistry",      Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Ads {AdsID = 4022, Title = "Microeconomics", Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Ads {AdsID = 4041, Title = "Macroeconomics", Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Ads {AdsID = 1045, Title = "Calculus",       Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Ads {AdsID = 3141, Title = "Trigonometry",   Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Ads {AdsID = 2021, Title = "Composition",    Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Ads {AdsID = 2042, Title = "Literature",     Tags = "AC",
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };

            context.Ads.AddRange(ads);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    UserID = users.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    UserID = users.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    UserID = users.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            context.OfficeAssignments.AddRange(officeAssignments);
            context.SaveChanges();

            var adsInstructors = new AdsAssignment[]
            {
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Chemistry" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Kapoor").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Chemistry" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Harui").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Microeconomics" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Zheng").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Macroeconomics" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Zheng").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Calculus" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Fakhouri").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Trigonometry" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Harui").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Composition" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Abercrombie").ID
                    },
                new AdsAssignment {
                    AdsID = ads.Single(c => c.Title == "Literature" ).AdsID,
                    UsersID = users.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            context.AdsAssignments.AddRange(adsInstructors);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID,
                    AdsID = ads.Single(c => c.Title == "Chemistry" ).AdsID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID,
                    AdsID = ads.Single(c => c.Title == "Microeconomics" ).AdsID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Alexander").ID,
                    AdsID = ads.Single(c => c.Title == "Macroeconomics" ).AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        CompanyID = company.Single(s => s.Title == "Alonso").ID,
                    AdsID = ads.Single(c => c.Title == "Calculus" ).AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        CompanyID = company.Single(s => s.Title == "Alonso").ID,
                    AdsID = ads.Single(c => c.Title == "Trigonometry" ).AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Alonso").ID,
                    AdsID = ads.Single(c => c.Title == "Composition" ).AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Anand").ID,
                    AdsID = ads.Single(c => c.Title == "Chemistry" ).AdsID
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Anand").ID,
                    AdsID = ads.Single(c => c.Title == "Microeconomics").AdsID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Barzdukas").ID,
                    AdsID = ads.Single(c => c.Title == "Chemistry").AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Li").ID,
                    AdsID = ads.Single(c => c.Title == "Composition").AdsID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    CompanyID = company.Single(s => s.Title == "Justice").ID,
                    AdsID = ads.Single(c => c.Title == "Literature").AdsID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Company.ID == e.CompanyID &&
                            s.Ads.AdsID == e.AdsID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }

    //    public static void Initialize(ApplicationDbContext context)
    //    {
    //        context.Database.EnsureCreated();

    //        // Look for any students.
    //        if (context.Company.Any())
    //        {
    //            return;   // DB has been seeded
    //        }

    //        var company = new Company[]
    //        {
    //            new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
    //            new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
    //            new Company{Title="Carson",Rating=5,EnrollmentDate=DateTime.Parse("2019-09-01"), Bonus="figurca", Description="", Topic="Game", News="games 5", Price=5, Tags="#AC"},
    //        };

    //        context.Company.AddRange(company);
    //        context.SaveChanges();

    //        var ads = new Ads[]
    //        {
    //            new Ads{AdsID=1050,Title="Chemistry",Tags="AC"},
    //            new Ads{AdsID=4022,Title="Microeconomics",Tags="AC"},
    //            new Ads{AdsID=4041,Title="Macroeconomics",Tags="AC"},
    //        };

    //        context.Ads.AddRange(ads);
    //        context.SaveChanges();

    //        var enrollments = new Enrollment[]
    //        {
    //            new Enrollment{CompanyID=1,AdsID=1050,Grade=Grade.A},
    //            new Enrollment{CompanyID=1,AdsID=4022,Grade=Grade.C},
    //            new Enrollment{CompanyID=1,AdsID=4041,Grade=Grade.B},
    //        };

    //        context.Enrollments.AddRange(enrollments);
    //        context.SaveChanges();
    //    }
    //}
}
