namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeDateOrganization")]
    public partial class EmployeeDateOrganization
    {
        [Key]
        public int do_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide activity")]
        [StringLength(8)]
        [Display(Name = "Activity")]
        public string activity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide number of days")]
        [StringLength(50)]
        [Display(Name = "Number of Days")]
        public string number_of_days { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
