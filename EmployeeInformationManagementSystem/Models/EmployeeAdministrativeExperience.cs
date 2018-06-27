namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeAdministrativeExperience")]
    public partial class EmployeeAdministrativeExperience
    {
        [Key]
        public int ae_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide position")]
        [StringLength(50)]
        [Display(Name = "Position")]
        public string position { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide institution location")]
        [StringLength(50)]
        [Display(Name = "Institution Location")]
        public string institution_location { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide employment date")]
        [Display(Name = "Employment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime employment_date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide appointment status")]
        [StringLength(50)]
        [Display(Name = "Appointment Status")]
        public string appointment_status { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide working status")]
        [StringLength(50)]
        [Display(Name = "Working Status")]
        public string working_status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
