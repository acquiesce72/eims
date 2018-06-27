namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Applicant")]
    public partial class Applicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applicant()
        {
            ApplicantEducationalBackgrounds = new HashSet<ApplicantEducationalBackground>();
            ApplicantExperiences = new HashSet<ApplicantExperience>();
            ApplicantTrainings = new HashSet<ApplicantTraining>();
        }

        [Key]
        public int applicant_id { get; set; }

        [Display(Name = "Date Created")]
        public DateTime date_created { get; set; }

        [StringLength(50)]
        [Display(Name = "Created By")]
        public string created_by { get; set; }

        [Display(Name = "Updated On")]
        public DateTime? updated_on { get; set; }

        [Display(Name = "Updated By")]
        [StringLength(50)]
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide birth place")]
        [StringLength(50)]
        [Display(Name = "Birth Place")]
        public string birth_place { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide gender")]
        [StringLength(6)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide civil status")]
        [StringLength(7)]
        [Display(Name = "Civil Status")]
        public string civil_status { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide contact number")]
        [StringLength(50)]
        [Display(Name = "Contact Number")]
        public string contact_number { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide address")]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide blood type")]
        [StringLength(3)]
        [Display(Name = "Blood Type")]
        public string blood_type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide religion")]
        [StringLength(50)]
        [Display(Name = "Religion")]
        public string religion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide objectives")]
        [StringLength(200)]
        [Display(Name = "Objectives")]
        public string objectives { get; set; }

        [Display(Name = "Applicant Image")]
        public byte[] applicant_image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantEducationalBackground> ApplicantEducationalBackgrounds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantExperience> ApplicantExperiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantTraining> ApplicantTrainings { get; set; }
    }
}
