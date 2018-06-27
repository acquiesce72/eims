namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServicePRCExaminer")]
    public partial class EmployeeServicePRCExaminer
    {
        [Key]
        public int prc_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide name of examination")]
        [StringLength(50)]
        [Display(Name = "Name of Examination")]
        public string name_examination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide venue")]
        [StringLength(50)]
        [Display(Name = "Venue")]
        public string venue { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date")]
        [Display(Name ="Inclusive Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime inclusive_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
