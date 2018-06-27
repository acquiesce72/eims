namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeAcademicHonor")]
    public partial class EmployeeAcademicHonor
    {
        [Key]
        public int ah_id { get; set; }

        public int employee_id { get; set; }

        [Display(Name = "Date Created")]
        public DateTime date_created { get; set; }

        [StringLength(50)]
        [Display(Name = "Created By")]
        public string created_by { get; set; }

        [Display(Name = "Updated On")]
        public DateTime? updated_on { get; set; }

        [StringLength(50)]
        [Display(Name = "Updated By")]
        public string updated_by { get; set; }

        [Display(Name = "Deleted?")]
        public bool deleted { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide honors")]
        [StringLength(50)]
        [Display(Name = "Honors")]
        public string honors { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide institution location")]
        [StringLength(50)]
        [Display(Name = "Institution Location")]
        public string institution_location { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide degree")]
        [StringLength(50)]
        [Display(Name = "Degree")]
        public string degree { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide year obtained")]
        [StringLength(50)]
        [Display(Name = "Year Obtained")]
        public string year_obtained { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
