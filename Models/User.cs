﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebSite.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Display(Name = "Age")]
        [StringLength(50)]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "AboutMe")]
        [StringLength(50)]
        public string AboutMe { get; set; }

        [Required]
        [Display(Name = "Comments")]
        [StringLength(50)]
        public string Comments { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        public ICollection<AdsAssignment> AdsAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
