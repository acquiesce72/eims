namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceConsultant")]
    public partial class EmployeeServiceConsultant
    {
        [Key]
        public int sca_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature")]
        [StringLength(50)]
        [Display(Name = "Nature")]
        public string nature { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide sponsor and location")]
        [StringLength(50)]
        [Display(Name = "Sponsor and Location")]
        public string sponsor_location { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide level")]
        [StringLength(50)]
        [Display(Name = "Level")]
        public string sca_level { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date")]
        [Display(Name ="Inclusive Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime inclusive_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
