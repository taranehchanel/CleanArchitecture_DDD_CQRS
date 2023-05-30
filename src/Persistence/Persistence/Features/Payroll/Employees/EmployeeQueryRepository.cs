using Dapper;
using Microsoft.Extensions.Configuration;

namespace Persistence.Features.Payroll.Employees;

public class EmployeeQueryRepository : object,
	Domain.Features.Payroll.Employees.IEmployeeQueryRepository
{
	public EmployeeQueryRepository
		(Microsoft.Extensions.Configuration.IConfiguration configuration) : base()
	{
		// using Microsoft.Extensions.Configuration;
		ConnectionString =
			configuration.GetConnectionString(name: "DatabaseContext");
	}

	protected string? ConnectionString { get; init; }

	public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable
		<Domain.Features.Payroll.Employees.Employee>> GetAllAsync
		(System.Threading.CancellationToken cancellationToken = default)
	{
		if (string.IsNullOrWhiteSpace(value: ConnectionString))
		{
			throw new System.ArgumentNullException
				(paramName: nameof(ConnectionString));
		}

		using var connection = new Microsoft.Data.SqlClient
			.SqlConnection(connectionString: ConnectionString);

		var query =
			"SELECT * FROM Employees";

		// using Dapper;
		var result =
			await
			connection.QueryAsync<Domain.Features.Payroll.Employees.Employee>(sql: query)
			;

		return result;
	}

	public async System.Threading.Tasks.Task<Domain.Features.Payroll.Employees.Employee>
		GetByIdAsync(System.Guid id, System.Threading.CancellationToken cancellationToken = default)
	{
		if (string.IsNullOrWhiteSpace(value: ConnectionString))
		{
			throw new System.ArgumentNullException
				(paramName: nameof(ConnectionString));
		}

		using var connection = new Microsoft.Data.SqlClient
			.SqlConnection(connectionString: ConnectionString);

		var query =
			"SELECT * FROM Employees WHERE Id = @Id";

		//var parameters =
		//	new { Id = id };

		var parameters = new { id };

		// using Dapper;
		var result =
			await
			connection.QueryFirstOrDefaultAsync<Domain.Features.Payroll.Employees.Employee>
			(sql: query, param: parameters);

		return result;
	}
}
