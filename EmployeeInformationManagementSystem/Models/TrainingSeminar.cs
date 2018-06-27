namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingSeminar")]
    public partial class TrainingSeminar
    {
        [Key]
        public int ts_id { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide sponsor")]
        [StringLength(50)]
        [Display(Name = "Sponsor")]
        public string sponsor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide location")]
        [StringLength(50)]
        [Display(Name = "Location")]
        public string location { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide inclusive date start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Inclusive Date Start")]
        public DateTime date_start { get; set; }

        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide date end")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Date End")]
        public DateTime date_end { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide level")]
        [StringLength(13)]
        [Display(Name = "Level")]
        public string ts_level { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide number of hours")]
        [StringLength(50)]
        [Display(Name = "Number of Hours")]
        public string number_of_hours { get; set; }
    }
}
