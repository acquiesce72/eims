namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicantEducationalBackground")]
    public partial class ApplicantEducationalBackground
    {
        [Key]
        public int eb_id { get; set; }

        public int applicant_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide school")]
        [StringLength(50)]
        [Display(Name = "School")]
        public string school { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide level")]
        [StringLength(50)]
        [Display(Name = "Level")]
        public string school_level { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide year graduated")]
        [StringLength(4)]
        [Display(Name = "Year Graduated")]
        public string year_graduated { get; set; }

        [StringLength(50)]
        [Display(Name = "Honors")]
        public string honors { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
