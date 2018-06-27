namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeMembershipProfessionalOrganization")]
    public partial class EmployeeMembershipProfessionalOrganization
    {
        [Key]
        public int mpo_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide name of the organization")]
        [StringLength(50)]
        [Display(Name = "Name of the Organization")]
        public string name_organization { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide nature/category")]
        [StringLength(50)]
        [Display(Name = "Nature/Category")]
        public string nature_category { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide date of membership")]
        [Display(Name = "Date of Membership")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime date_of_membership { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
