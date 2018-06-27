namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeServiceAward")]
    public partial class EmployeeServiceAward
    {
        [Key]
        public int sa_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide field")]
        [StringLength(50)]
        [Display(Name = "Field")]
        public string field { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide organization")]
        [StringLength(50)]
        [Display(Name = "Organization")]
        public string organization { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide year obtained")]
        [StringLength(4)]
        [Display(Name = "Year Obtained")]
        public string year_obtained { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
