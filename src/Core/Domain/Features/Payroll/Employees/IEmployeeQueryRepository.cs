namespace Domain.Features.Payroll.Employees;

public interface IEmployeeQueryRepository
{
	//Employee GetById(System.Guid id);
	//System.Collections.Generic.IEnumerable<Employee> GetAll();

	System.Threading.Tasks.Task<Employee> GetByIdAsync(System.Guid id,
		System.Threading.CancellationToken cancellationToken = default);

	System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Employee>>
		GetAllAsync(System.Threading.CancellationToken cancellationToken = default);
}
