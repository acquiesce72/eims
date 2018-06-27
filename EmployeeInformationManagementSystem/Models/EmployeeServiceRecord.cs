namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceRecord")]
    public partial class EmployeeServiceRecord
    {
        [Key]
        public int sr_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide years in organization")]
        [StringLength(4)]
        [Display(Name = "Years in Organization")]
        public string years_in_organization { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide years in probationary")]
        [StringLength(4)]
        [Display(Name = "Years in Probationary")]
        public string years_in_probationary { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide years of permanent")]
        [StringLength(4)]
        [Display(Name = "Years of Permanent")]
        public string years_of_permanent { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
