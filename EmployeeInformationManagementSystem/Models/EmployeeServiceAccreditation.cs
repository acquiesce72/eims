namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceAccreditation")]
    public partial class EmployeeServiceAccreditation
    {
        [Key]
        public int saccr_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide accrediting group")]
        [StringLength(50)]
        [Display(Name = "Accrediting Group")]
        public string accrediting_group { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature of participation")]
        [StringLength(50)]
        [Display(Name = "Nature of Participation")]
        public string nature_participation { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date")]
        [Display(Name ="Inclusive Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime inclusive_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
