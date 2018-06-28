namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            EmployeeAcademicHonors = new HashSet<EmployeeAcademicHonor>();
            EmployeeAdministrativeExperiences = new HashSet<EmployeeAdministrativeExperience>();
            EmployeeChildrens = new HashSet<EmployeeChildren>();
            EmployeeContinuingProfessionalEducations = new HashSet<EmployeeContinuingProfessionalEducation>();
            EmployeeDateOrganizations = new HashSet<EmployeeDateOrganization>();
            EmployeeEducationalBackgrounds = new HashSet<EmployeeEducationalBackground>();
            EmployeeInnovations = new HashSet<EmployeeInnovation>();
            EmployeeLicensureExaminations = new HashSet<EmployeeLicensureExamination>();
            EmployeeMembershipProfessionalOrganizations = new HashSet<EmployeeMembershipProfessionalOrganization>();
            EmployeePerformances = new HashSet<EmployeePerformance>();
            EmployeePublishedResearchBooks = new HashSet<EmployeePublishedResearchBook>();
            EmployeeRecipients = new HashSet<EmployeeRecipient>();
            EmployeeScholarships = new HashSet<EmployeeScholarship>();
            EmployeeServiceAccreditations = new HashSet<EmployeeServiceAccreditation>();
            EmployeeServiceAdvisers = new HashSet<EmployeeServiceAdviser>();
            EmployeeServiceAwards = new HashSet<EmployeeServiceAward>();
            EmployeeServiceCoaches = new HashSet<EmployeeServiceCoach>();
            EmployeeServiceConsultants = new HashSet<EmployeeServiceConsultant>();
            EmployeeServicePRCExaminers = new HashSet<EmployeeServicePRCExaminer>();
            EmployeeServiceRecords = new HashSet<EmployeeServiceRecord>();
            EmployeeTeachingExperiences = new HashSet<EmployeeTeachingExperience>();
            EmployeeTrainings = new HashSet<EmployeeTraining>();
            EmployeeUploadedFiles = new HashSet<EmployeeUploadedFile>();
        }

        [Key]
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide employee number")]
        [StringLength(50)]
        [Display(Name = "Employee Number")]
        [Remote("IsEmployeeNumberExist", "Validation", ErrorMessage = "Employee Number already exist")]
        public string employee_number { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide height")]
        [StringLength(10)]
        [Display(Name = "Height")]
        public string height { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide weight")]
        [StringLength(10)]
        [Display(Name = "Weight")]
        public string weight { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide citizenship")]
        [StringLength(50)]
        [Display(Name = "Citizenship")]
        public string citizenship { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide blood type")]
        [StringLength(3)]
        [Display(Name = "Blood Type")]
        public string blood_type { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide contact person")]
        [StringLength(50)]
        [Display(Name = "Contact Person")]
        public string contact_person { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Marriage Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? marriage_date { get; set; }

        [StringLength(50)]
        [Display(Name = "Marriage Place")]
        public string marriage_place { get; set; }

        [StringLength(50)]
        [Display(Name = "Spouse Name")]
        public string spouse_name { get; set; }

        [StringLength(50)]
        [Display(Name = "Spouse Occupation")]
        public string spouse_occupation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide fathers name")]
        [StringLength(50)]
        [Display(Name = "Father's Name")]
        public string father_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide fathers occupation")]
        [StringLength(50)]
        [Display(Name = "Father's Occupation")]
        public string father_occupation { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide mothers name")]
        [StringLength(50)]
        [Display(Name = "Mother's Name")]
        public string mother_name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide mothers occupation")]
        [StringLength(50)]
        [Display(Name = "Mother's Occupation")]
        public string mother_occupation { get; set; }

        [Column(TypeName = "date")]
        // [Required(AllowEmptyStrings = true, ErrorMessage = "Please provide confirmation date")]
        [Required(AllowEmptyStrings = true )]
        [Display(Name = "Confirmation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime confirmation_date { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please provide confirmation place")]
        [StringLength(50)]
        [Display(Name = "Confirmation Place")]
        public string confirmation_place { get; set; }

        [Display(Name = "Is Active?")]
        public bool is_active { get; set; }

        [Display(Name = "Employee Image")]
        public byte[] employee_image { get; set; }

        [StringLength(20)]
        [Display(Name = "SSS")]
        public string sss { get; set; }

        [StringLength(20)]
        [Display(Name = "Tin")]
        public string tin { get; set; }

        [StringLength(20)]
        [Display(Name = "Pag-Ibig #")]
        public string pagibig { get; set; }

        [StringLength(20)]
        [Display(Name = "PhilHealth #")]
        public string philhealth { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Employment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? employment_date { get; set; }

        [StringLength(50)]
        [Display(Name = "Department")]
        public string department { get; set; }

        [StringLength(13)]
        [Display(Name = "Educational Attainment")]
        public string educational_attainment { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Permanent")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? date_permanent { get; set; }

        [StringLength(12)]
        [Display(Name = "Appointment Status")]
        public string appointment_status { get; set; }

        [StringLength(50)]
        [Display(Name = "Employment Type")]
        public string employment_type { get; set; }

        [StringLength(50)]
        [Display(Name = "Position")]
        public string position { get; set; }

        [StringLength(9)]
        [Display(Name = "Working Status")]
        public string working_status { get; set; }

        [StringLength(50)]
        [Display(Name = "Semester")]
        public string semester { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeAcademicHonor> EmployeeAcademicHonors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeAdministrativeExperience> EmployeeAdministrativeExperiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeChildren> EmployeeChildrens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeContinuingProfessionalEducation> EmployeeContinuingProfessionalEducations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeDateOrganization> EmployeeDateOrganizations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeEducationalBackground> EmployeeEducationalBackgrounds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeInnovation> EmployeeInnovations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeLicensureExamination> EmployeeLicensureExaminations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeMembershipProfessionalOrganization> EmployeeMembershipProfessionalOrganizations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeePerformance> EmployeePerformances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeePublishedResearchBook> EmployeePublishedResearchBooks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeRecipient> EmployeeRecipients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeScholarship> EmployeeScholarships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceAccreditation> EmployeeServiceAccreditations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceAdviser> EmployeeServiceAdvisers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceAward> EmployeeServiceAwards { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceCoach> EmployeeServiceCoaches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceConsultant> EmployeeServiceConsultants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServicePRCExaminer> EmployeeServicePRCExaminers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeServiceRecord> EmployeeServiceRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTeachingExperience> EmployeeTeachingExperiences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeUploadedFile> EmployeeUploadedFiles { get; set; }
    }
}
