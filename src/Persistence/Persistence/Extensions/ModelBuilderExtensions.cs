namespace Persistence.Extensions;

internal static class ModelBuilderExtensions : object
{
	#region Static Constructor
	static ModelBuilderExtensions()
	{
	}
	#endregion /Static Constructor

	#region Methods

	#region Seed()
	public static void Seed(this Microsoft
		.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		// **************************************************
		// *** Employees ************************************
		// **************************************************
		Domain.Features.Payroll.Employees.Employee employee;

		for (int index = 1; index <= 9; index++)
		{
			var lastName = $"Last Name {index}";
			var firstName = $"First Name {index}";

			employee =
				new Domain.Features.Payroll.Employees
				.Employee(firstName: firstName, lastName: lastName)
				{
					Allowance = index * 3,
					BasicSalary = index * 10,
					Transportation = index * 2,
					Date = System.DateTime.Now,
				};

			modelBuilder.Entity<Domain.Features
				.Payroll.Employees.Employee>().HasData(data: employee);
		}
		// **************************************************
		// *** /Employees ***********************************
		// **************************************************
	}
	#endregion /Seed()

	#endregion /Methods
}
