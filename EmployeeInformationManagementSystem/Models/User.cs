namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    [Table("User")]
    public partial class User
    {
        [Key]
        public int user_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Created By")]
        public string created_by { get; set; }

        [Display(Name = "Updated On")]
        public DateTime? updated_on { get; set; }

        [StringLength(50)]
        [Display(Name = "Updated By")]
        public string updated_by { get; set; }

        [Display(Name = "Last Login")]             
        public DateTime? last_login { get; set; }

        [Display(Name = "Deleted?")]
        public bool deleted { get; set; }

        [StringLength(50)]
        [Display(Name = "Record ID")]
        public string my_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide username")]
        [StringLength(50, MinimumLength = 5)]
        [Remote("IsUsernameExist", "Validation", ErrorMessage = "Username is already taken")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide password")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Password")]
        public string password { get; set; }

        /*[NotMapped]
        [Required(ErrorMessage = "Confirm password required")]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirmpassword { get; set; }*/

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide gender")]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide role")]
        [StringLength(50)]
        [Display(Name = "Role")]
        public string role { get; set; }

        [Display(Name = "Date Joined")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? datejoined { get; set; }

        [Display(Name = "Is Active?")]
        public bool is_active { get; set; }

        [Display(Name = "Image")]
        public byte[] userimage { get; set; }
    }
}
