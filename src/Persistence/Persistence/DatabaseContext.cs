using Persistence.Extensions;

namespace Persistence;

public class DatabaseContext :
	Microsoft.EntityFrameworkCore.DbContext
{
	#region Constructor
	public DatabaseContext(Microsoft.EntityFrameworkCore
		.DbContextOptions<DatabaseContext> options) : base(options: options)
	{
		Database.EnsureCreated();
	}
	#endregion /Constructor

	#region Properties

	#region Payroll Feature

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Features.Payroll.Employees.Employee> Employees { get; set; }

	#endregion /Payroll Feature

	#endregion /Properties

	#region Methods

	#region OnModelCreating()
	protected override void OnModelCreating
		(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(DatabaseContext).Assembly);

		modelBuilder.Seed();
	}
	#endregion /OnModelCreating()

	#endregion /Methods
}
