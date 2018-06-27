namespace EmployeeInformationManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=connectionstring")
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<ApplicantEducationalBackground> ApplicantEducationalBackgrounds { get; set; }
        public virtual DbSet<ApplicantExperience> ApplicantExperiences { get; set; }
        public virtual DbSet<ApplicantTraining> ApplicantTrainings { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAcademicHonor> EmployeeAcademicHonors { get; set; }
        public virtual DbSet<EmployeeAdministrativeExperience> EmployeeAdministrativeExperiences { get; set; }
        public virtual DbSet<EmployeeChildren> EmployeeChildrens { get; set; }
        public virtual DbSet<EmployeeContinuingProfessionalEducation> EmployeeContinuingProfessionalEducations { get; set; }
        public virtual DbSet<EmployeeDateOrganization> EmployeeDateOrganizations { get; set; }
        public virtual DbSet<EmployeeEducationalBackground> EmployeeEducationalBackgrounds { get; set; }
        public virtual DbSet<EmployeeInnovation> EmployeeInnovations { get; set; }
        public virtual DbSet<EmployeeLicensureExamination> EmployeeLicensureExaminations { get; set; }
        public virtual DbSet<EmployeeMembershipProfessionalOrganization> EmployeeMembershipProfessionalOrganizations { get; set; }
        public virtual DbSet<EmployeePerformance> EmployeePerformances { get; set; }
        public virtual DbSet<EmployeePublishedResearchBook> EmployeePublishedResearchBooks { get; set; }
        public virtual DbSet<EmployeeRecipient> EmployeeRecipients { get; set; }
        public virtual DbSet<EmployeeScholarship> EmployeeScholarships { get; set; }
        public virtual DbSet<EmployeeServiceAccreditation> EmployeeServiceAccreditations { get; set; }
        public virtual DbSet<EmployeeServiceAdviser> EmployeeServiceAdvisers { get; set; }
        public virtual DbSet<EmployeeServiceAward> EmployeeServiceAwards { get; set; }
        public virtual DbSet<EmployeeServiceCoach> EmployeeServiceCoaches { get; set; }
        public virtual DbSet<EmployeeServiceConsultant> EmployeeServiceConsultants { get; set; }
        public virtual DbSet<EmployeeServicePRCExaminer> EmployeeServicePRCExaminers { get; set; }
        public virtual DbSet<EmployeeServiceRecord> EmployeeServiceRecords { get; set; }
        public virtual DbSet<EmployeeTeachingExperience> EmployeeTeachingExperiences { get; set; }
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual DbSet<EmployeeUploadedFile> EmployeeUploadedFiles { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TrainingSeminar> TrainingSeminars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.civil_status)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.blood_type)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.religion)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.objectives)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.school)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.school_level)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.year_graduated)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantEducationalBackground>()
                .Property(e => e.honors)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.job_title)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.reference)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantExperience>()
                .Property(e => e.number_of_hours)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantTraining>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantTraining>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantTraining>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantTraining>()
                .Property(e => e.sponsor)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicantTraining>()
                .Property(e => e.number_of_hours)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_number)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.civil_status)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.height)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.weight)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.citizenship)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.blood_type)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.contact_person)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.marriage_place)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.spouse_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.spouse_occupation)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.father_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.father_occupation)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.mother_occupation)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.confirmation_place)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.sss)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.tin)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.pagibig)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.philhealth)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.department)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.educational_attainment)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.appointment_status)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employment_type)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.working_status)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.semester)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.honors)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.institution_location)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.degree)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAcademicHonor>()
                .Property(e => e.year_obtained)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.institution_location)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.appointment_status)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeAdministrativeExperience>()
                .Property(e => e.working_status)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeChildren>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeChildren>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeChildren>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeChildren>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeChildren>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeContinuingProfessionalEducation>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeContinuingProfessionalEducation>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeContinuingProfessionalEducation>()
                .Property(e => e.area_topic)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeContinuingProfessionalEducation>()
                .Property(e => e.venue)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeContinuingProfessionalEducation>()
                .Property(e => e.number_of_hours)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDateOrganization>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDateOrganization>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDateOrganization>()
                .Property(e => e.activity)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDateOrganization>()
                .Property(e => e.number_of_days)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.school)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.school_level)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.year_graduated)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeEducationalBackground>()
                .Property(e => e.honors)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInnovation>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInnovation>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInnovation>()
                .Property(e => e.innovation_name)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInnovation>()
                .Property(e => e.patent_no)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInnovation>()
                .Property(e => e.year_patented)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLicensureExamination>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLicensureExamination>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLicensureExamination>()
                .Property(e => e.examination)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLicensureExamination>()
                .Property(e => e.rating)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLicensureExamination>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeMembershipProfessionalOrganization>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeMembershipProfessionalOrganization>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeMembershipProfessionalOrganization>()
                .Property(e => e.name_organization)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeMembershipProfessionalOrganization>()
                .Property(e => e.nature_category)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.evaluation_period)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.semester)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.evaluator)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.evaluation_score)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePerformance>()
                .Property(e => e.rating)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.pbr_level)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePublishedResearchBook>()
                .Property(e => e.publisher)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRecipient>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRecipient>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRecipient>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRecipient>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeRecipient>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeScholarship>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeScholarship>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeScholarship>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeScholarship>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeScholarship>()
                .Property(e => e.sponsor)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAccreditation>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAccreditation>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAccreditation>()
                .Property(e => e.accrediting_group)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAccreditation>()
                .Property(e => e.nature_participation)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.name_student)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAdviser>()
                .Property(e => e.institution)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.field)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.organization)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceAward>()
                .Property(e => e.year_obtained)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceCoach>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceCoach>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceCoach>()
                .Property(e => e.nature_activity)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceCoach>()
                .Property(e => e.nature_service_rendered)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceCoach>()
                .Property(e => e.level_participation_competition)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceConsultant>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceConsultant>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceConsultant>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceConsultant>()
                .Property(e => e.sponsor_location)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceConsultant>()
                .Property(e => e.sca_level)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServicePRCExaminer>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServicePRCExaminer>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServicePRCExaminer>()
                .Property(e => e.name_examination)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServicePRCExaminer>()
                .Property(e => e.venue)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceRecord>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceRecord>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceRecord>()
                .Property(e => e.years_in_organization)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceRecord>()
                .Property(e => e.years_in_probationary)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeServiceRecord>()
                .Property(e => e.years_of_permanent)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.designation)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.institution_location)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.appointment_status)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTeachingExperience>()
                .Property(e => e.working_status)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTraining>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTraining>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTraining>()
                .Property(e => e.training)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeTraining>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeUploadedFile>()
                .Property(e => e.uploaded_by)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeUploadedFile>()
                .Property(e => e.filename)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.school_year)
                .IsUnicode(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.school_semester)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.nature)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.sponsor)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.ts_level)
                .IsUnicode(false);

            modelBuilder.Entity<TrainingSeminar>()
                .Property(e => e.number_of_hours)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.updated_by)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
