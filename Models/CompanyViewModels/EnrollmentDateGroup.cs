using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models.CompanyViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int CompanyCount { get; set; }
    }
}
