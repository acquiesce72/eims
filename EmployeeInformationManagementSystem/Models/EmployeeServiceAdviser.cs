namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceAdviser")]
    public partial class EmployeeServiceAdviser
    {
        [Key]
        public int sadvi_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide name of student")]
        [StringLength(50)]
        [Display(Name = "Name of Student")]
        public string name_student { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide category")]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide institution")]
        [StringLength(50)]
        [Display(Name = "Institution")]
        public string institution { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date")]
        [Display(Name ="Inclusive Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime inclusive_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
