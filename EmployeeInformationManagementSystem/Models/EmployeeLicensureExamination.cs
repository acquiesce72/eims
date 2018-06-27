namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeLicensureExamination")]
    public partial class EmployeeLicensureExamination
    {
        [Key]
        public int le_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide examination")]
        [StringLength(50)]
        [Display(Name = "Examination")]
        public string examination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide rating")]
        [StringLength(50)]
        [Display(Name = "Rating")]
        public string rating { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide year")]
        [StringLength(4)]
        [Display(Name = "Year")]
        public string year { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
