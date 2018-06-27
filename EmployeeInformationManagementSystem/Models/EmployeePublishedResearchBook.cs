namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeePublishedResearchBook")]
    public partial class EmployeePublishedResearchBook
    {
        [Key]
        public int pbr_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide title")]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature")]
        [StringLength(50)]
        [Display(Name = "Nature")]
        public string nature { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide role")]
        [StringLength(50)]
        [Display(Name = "Role")]
        public string role { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide level")]
        [StringLength(50)]
        [Display(Name = "Level")]
        public string pbr_level { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide publisher")]
        [StringLength(50)]
        [Display(Name = "Publisher")]
        public string publisher { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide date of publication")]
        [Display(Name ="Date of Publication")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime date_publication { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
