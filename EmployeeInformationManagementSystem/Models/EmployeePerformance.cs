namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeePerformance")]
    public partial class EmployeePerformance
    {
        [Key]
        public int p_id { get; set; }

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

        [Column(TypeName = "date")]
        [Display(Name = "Evaluation Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide evaluation date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime evaluation_date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide evaluation period")]
        [StringLength(50)]
        [Display(Name = "Evaluation Period")]
        public string evaluation_period { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide semester")]
        [StringLength(50)]
        [Display(Name = "Semester")]
        public string semester { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide evaluator")]
        [StringLength(50)]
        [Display(Name = "Evaluator")]
        public string evaluator { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide evaluation score")]
        [StringLength(50)]
        [Display(Name = "Evaluation Score")]
        public string evaluation_score { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide rating")]
        [StringLength(17)]
        [Display(Name = "Rating")]
        public string rating { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
