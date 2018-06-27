namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeTraining")]
    public partial class EmployeeTraining
    {
        [Key]
        public int et_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide training")]
        [StringLength(50)]
        [Display(Name = "Training")]
        public string training { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide title")]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string title { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
