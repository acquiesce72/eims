namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ApplicantTraining")]
    public partial class ApplicantTraining
    {
        [Key]
        public int t_id { get; set; }

        public int applicant_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide sponsor")]
        [StringLength(50)]
        [Display(Name = "Sponsor")]
        public string sponsor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide date start")]
        [Column(TypeName = "date")]
        [Display(Name = "Date Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime date_start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide date end")]
        [Column(TypeName = "date")]
        [Display(Name = "Date End")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime date_end { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide number hours")]
        [StringLength(50)]
        [Display(Name = "# of hours")]
        public string number_of_hours { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
