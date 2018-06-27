namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeUploadedFile")]
    public partial class EmployeeUploadedFile
    {
        [Key]
        public int file_id { get; set; }

        public int employee_id { get; set; }

        [Display(Name = "Date Uploaded")]
        public DateTime date_uploaded { get; set; }

        [StringLength(50)]
        [Display(Name = "Uploaded By")]
        public string uploaded_by { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "File name")]
        public string filename { get; set; }

        [Required]
        [StringLength(200)]
        public string contenttype { get; set; }

        [Required]
        public byte[] data { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
