using MyWebSite.Models.CompanyViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }

        public int CompanyID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Column("FirstName")]
        [Display(Name = "Rating")]
        public decimal Rating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        [Display(Name = "Thematics")]
        public string Thematics { get; set; }
        [Required]
        [Display(Name = "Bonus")]
        public string Bonus { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Images")]
        public string Images { get; set; }
        [Required]
        [Display(Name = "Video ")]
        public string Video { get; set; }
        [Required]
        [Display(Name = "Topic")]
        public string Topic { get; set; }
        [Required]
        [Display(Name = "News")]
        public string News { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Tags")]
        public string Tags { get; set; }
        public double Rank { get; set; }
        public DateTime Update { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Title + ", " + Rating;
            }
        }

        public ICollection<Owner> Owner { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
        public IEnumerable<AdminIndexData> AdminIndexData { get; set; }
    }
}
