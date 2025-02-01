using Contracts.StorageContract.dbModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseImplement
{
	public class DataBaseImplement : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=WIN-0IL5NARLEQ9\SQLEXPRESS;Initial Catalog=CoursWorkIgor;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
			}
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<AppointmentHeadman> Appointments { get; set; }
		public DbSet<Curriculum> Curriculums { get; set; }
		public DbSet<GPHAgreement> GPHAgreements { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<OfficialNote> OfficialNotes { get; set; }
		public DbSet<ProgressControl> ProgressControls { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Tutor> Tutors { get; set; }
		public DbSet<UniversityEmployee> UniversityEmployees { get; set; }
		public DbSet<WorkTutor> WorkTutors { get; set; }

	}
}
