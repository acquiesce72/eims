namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceCoach")]
    public partial class EmployeeServiceCoach
    {
        [Key]
        public int sc_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature of activity")]
        [StringLength(50)]
        [Display(Name = "Nature of Activity")]
        public string nature_activity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature of service rendered")]
        [StringLength(50)]
        [Display(Name = "Nature of Service Rendered")]
        public string nature_service_rendered { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide level of participation in competition")]
        [StringLength(50)]
        [Display(Name = "Level of Participation in Competition")]
        public string level_participation_competition { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Inclusive Date")]
        public DateTime inclusive_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
