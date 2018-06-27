namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeInnovation")]
    public partial class EmployeeInnovation
    {
        [Key]
        public int i_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide innovation name")]
        [StringLength(50)]
        [Display(Name = "Innovation Name")]
        public string innovation_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide patent no.")]
        [StringLength(50)]
        [Display(Name = "Patent No.")]
        public string patent_no { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide year patented")]
        [StringLength(4)]
        [Display(Name = "Year Patented")]
        public string year_patented { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
