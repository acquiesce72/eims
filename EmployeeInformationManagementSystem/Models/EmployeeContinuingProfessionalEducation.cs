namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeContinuingProfessionalEducation")]
    public partial class EmployeeContinuingProfessionalEducation
    {
        [Key]
        public int cpe_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide area/topic")]
        [StringLength(50)]
        [Display(Name = "Area/Topic")]
        public string area_topic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide venue")]
        [StringLength(50)]
        [Display(Name = "Venue")]
        public string venue { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Inclusive Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive dates")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime inclusive_date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide number of hours")]
        [StringLength(50)]
        [Display(Name = "# of hours")]
        public string number_of_hours { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
