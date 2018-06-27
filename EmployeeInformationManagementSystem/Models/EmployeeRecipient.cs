namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeRecipient")]
    public partial class EmployeeRecipient
    {
        [Key]
        public int r_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide first name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
       
        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string middlename { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide last name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide birth date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Birth Date")]
        public DateTime birth_date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
