namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Semester")]
    public partial class Semester
    {
        [Key]
        public int semester_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide description")]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide school year")]
        [StringLength(9)]
        [Display(Name = "School Year")]
        public string school_year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide semester")]
        [StringLength(50)]
        [Display(Name = "Semester")]
        public string school_semester { get; set; }

        [Display(Name = "Is Active?")]
        public bool is_active { get; set; }
    }
}
