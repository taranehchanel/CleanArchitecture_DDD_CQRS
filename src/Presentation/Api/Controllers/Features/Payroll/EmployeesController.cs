// **************************************************
//using System.Linq;
//using Microsoft.EntityFrameworkCore;

//namespace Api.Controllers.Features.Payroll.Employees;

//[Microsoft.AspNetCore.Mvc.Route
//	(template: "api/features/payroll/[controller]")]
//public class EmployeesController : Infrastructure.ControllerBaseWithDatabaseContext
//{
//	#region Constructor
//	public EmployeesController(Persistence.DatabaseContext
//		databaseContext) : base(databaseContext: databaseContext)
//	{
//	}
//	#endregion /Constructor

//	#region Action: GetEmployeeAsync()
//	[Microsoft.AspNetCore.Mvc.HttpGet]

//	[Microsoft.AspNetCore.Mvc.Consumes
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.Produces
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(type: typeof(System.Collections.Generic.IEnumerable
//		<Domain.Features.Payroll.Employees.Employee>),
//		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<Microsoft.AspNetCore.Mvc.IActionResult> GetEmployeesAsync()
//	{
//		var result =
//			await
//			DatabaseContext.Employees
//			.OrderBy(current => current.FirstName)
//			.ThenBy(current => current.LastName)
//			.ToListAsync()
//			;

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeAsync()
//}
// **************************************************

// **************************************************
//namespace Api.Controllers.Features.Payroll;

//[Microsoft.AspNetCore.Mvc.Route
//	(template: "api/features/payroll/[controller]")]
//public class EmployeesController : Infrastructure.ControllerBase
//{
//	#region Constructor
//	public EmployeesController(MediatR.IMediator mediator) : base()
//	{
//		Mediator = mediator;
//	}
//	#endregion /Constructor

//	protected MediatR.IMediator Mediator { get; init; }

//	#region Action: GetEmployeeAsync()
//	[Microsoft.AspNetCore.Mvc.HttpGet]

//	[Microsoft.AspNetCore.Mvc.Consumes
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.Produces
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(type: typeof(System.Collections.Generic.IEnumerable
//		<Domain.Features.Payroll.Employees.Employee>),
//		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<Microsoft.AspNetCore.Mvc.IActionResult> GetEmployeesAsync()
//	{
//		var request = new Api.Features
//			.Payroll.Employees.Queries.GetEmployeesQuery();

//		var result =
//			await
//			Mediator.Send(request: request);

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeAsync()

//	#region Action: GetEmployeeByIdAsync()
//	[Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")]

//	[Microsoft.AspNetCore.Mvc.Consumes
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.Produces
//		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(type: typeof(Domain.Features.Payroll.Employees.Employee),
//		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

//	[Microsoft.AspNetCore.Mvc.ProducesResponseType
//		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

//	public async System.Threading.Tasks.Task
//		<Microsoft.AspNetCore.Mvc.IActionResult> GetEmployeeByIdAsync(System.Guid id)
//	{
//		var request = new Api.Features
//			.Payroll.Employees.Queries.GetEmployeeByIdQuery(Id: id);

//		var result =
//			await
//			Mediator.Send(request: request);

//		return Ok(value: result);
//	}
//	#endregion /Action: GetEmployeeByIdAsync()
//}
// **************************************************

// **************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using System.Linq;

namespace Api.Controllers.Features.Payroll;

[Microsoft.AspNetCore.Mvc.Route
	(template: "api/features/payroll/[controller]")]
public class EmployeesController :
	Infrastructure.ControllerBaseWithDatabaseContext
{
	#region Constructor
	public EmployeesController
		(Persistence.DatabaseContext databaseContext, MediatR.IMediator mediator,
		OverTimePolicies.ICalculator calculator) : base(databaseContext: databaseContext)
	{
		Mediator = mediator;
		Calculator = calculator;
	}
	#endregion /Constructor

	#region Properties
	protected MediatR.IMediator Mediator { get; init; }
	protected OverTimePolicies.ICalculator Calculator { get; init; }
	#endregion /Properties

	#region Action: GetEmployeeAsync()
	[Microsoft.AspNetCore.Mvc.HttpGet]

	[Microsoft.AspNetCore.Mvc.Consumes
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.Produces
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(type: typeof(System.Collections.Generic.IEnumerable
		<Domain.Features.Payroll.Employees.Employee>),
		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> GetEmployeesAsync()
	{
		var request = new Api.Features
			.Payroll.Employees.Queries.GetEmployeesQuery();

		var result =
			await
			Mediator.Send(request: request);

		return Ok(value: result);
	}
	#endregion /Action: GetEmployeeAsync()

	#region Action: GetEmployeeByIdAsync()
	[Microsoft.AspNetCore.Mvc.HttpGet(template: "{id}")]

	[Microsoft.AspNetCore.Mvc.Consumes
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.Produces
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(type: typeof(Domain.Features.Payroll.Employees.Employee),
		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> GetEmployeeByIdAsync(System.Guid id)
	{
		var request = new Api.Features
			.Payroll.Employees.Queries.GetEmployeeByIdQuery(Id: id);

		var result =
			await
			Mediator.Send(request: request);

		return Ok(value: result);
	}
	#endregion /Action: GetEmployeeByIdAsync()

	#region Action: CreateEmployeeAsync()
	[Microsoft.AspNetCore.Mvc.HttpPost]

	[Microsoft.AspNetCore.Mvc.Consumes
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.Produces
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(type: typeof(Domain.Features.Payroll.Employees.Employee),
		statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status201Created)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status415UnsupportedMediaType)]

	//public async System.Threading.Tasks.Task
	//	<Microsoft.AspNetCore.Mvc.IActionResult>
	//	CreateEmployeesAsync(Dtos.Features.Payroll.Employees.CreateDto employeeDto)
	//{
	//	var employee =
	//		new Domain.Features.Payroll.Employees.Employee
	//		(firstName: employeeDto.FirstName, lastName: employeeDto.LastName)
	//		{
	//			Date = System.DateTime.Now,
	//			Allowance = employeeDto.Allowance,
	//			BasicSalary = employeeDto.BasicSalary,
	//			Transportation = employeeDto.Transportation,
	//		};

	//	employee.CalculateSalary(calculator: Calculator);

	//	await DatabaseContext.AddAsync(entity: employee);

	//	await DatabaseContext
	//		.SaveChangesAsync();

	//	return CreatedAtAction
	//		(actionName: "GetEmployeeById",
	//		routeValues: new { id = employee.Id }, value: employee);
	//}

	// Create with CQRS!
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> CreateEmployeesAsync
		(Dtos.Features.Payroll.Employees.CreateEmployeeRequestDto dto)
	{
		var request = new Api.Features
			.Payroll.Employees.Commands.CreateEmployeeCommand
			(LastName: dto.LastName, FirstName: dto.FirstName,
			Allowance: dto.Allowance, BasicSalary: dto.BasicSalary,
			Transportation: dto.Transportation, Date: dto.Date);

		var result =
			await
			Mediator.Send(request: request);

		return CreatedAtAction
			(actionName: "GetEmployeeById",
			routeValues: new { id = result.Id }, value: result);
	}
	#endregion /Action: CreateEmployeeAsync()

	#region Action: UpdateEmployeesAsync()
	[Microsoft.AspNetCore.Mvc.HttpPut(template: "{id}")]

	[Microsoft.AspNetCore.Mvc.Consumes
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.Produces
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status405MethodNotAllowed)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status415UnsupportedMediaType)]

    // Update without CQRS!
    //public async System.Threading.Tasks.Task
    //	<Microsoft.AspNetCore.Mvc.IActionResult> UpdateEmployeesAsync
    //	(System.Guid id, Dtos.Features.Payroll.Employees.UpdateDto employeeDto)
    //{
    //	var foundedEmployee =
    //		await
    //		DatabaseContext.Employees
    //		.Where(current => current.Id == id)
    //		.FirstOrDefaultAsync();

    //	if(foundedEmployee == null)
    //	{
    //		return NotFound();
    //	}

    //	foundedEmployee.Date = System.DateTime.Now;

    //	foundedEmployee.LastName = employeeDto.LastName;
    //	foundedEmployee.FirstName = employeeDto.FirstName;
    //	foundedEmployee.Allowance = employeeDto.Allowance;
    //	foundedEmployee.BasicSalary = employeeDto.BasicSalary;
    //	foundedEmployee.Transportation = employeeDto.Transportation;

    //	foundedEmployee.CalculateSalary(calculator: Calculator);

    //	await DatabaseContext
    //		.SaveChangesAsync();

    //	return NoContent();
    //}
    //----------------------------------------------------------------------
    // Update with CQRS!
    public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> UpdateEmployeesAsync
		(Dtos.Features.Payroll.Employees.UpdateEmployeeRequestDto dto)
	{
		var request = new Api.Features
			.Payroll.Employees.Commands.UpdateEmployeeCommand
			(Id: dto.Id,
			LastName: dto.LastName, FirstName: dto.FirstName,
			Allowance: dto.Allowance, BasicSalary: dto.BasicSalary,
			Transportation: dto.Transportation, Date: dto.Date);

		var result =
			await
			Mediator.Send(request: request);

		if(result == null)
		{
			return NotFound();
		}

		return NoContent();
	}
	#endregion /Action: CreateEmployeeAsync()

	#region Action: DeleteEmployeesAsync
	[Microsoft.AspNetCore.Mvc.HttpDelete(template: "{id}")]

	[Microsoft.AspNetCore.Mvc.Consumes
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.Produces
		(contentType: System.Net.Mime.MediaTypeNames.Application.Json)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status405MethodNotAllowed)]

	[Microsoft.AspNetCore.Mvc.ProducesResponseType
		(statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError)]

	//public async System.Threading.Tasks.Task
	//	<Microsoft.AspNetCore.Mvc.IActionResult> DeleteEmployeesAsync(System.Guid id)
	//{
	//	var foundedEmployees =
	//		await
	//		DatabaseContext.Employees
	//		.Where(current => current.Id == id)
	//		.FirstOrDefaultAsync();

	//	if (foundedEmployees == null)
	//	{
	//		return NotFound();
	//	}

	//	DatabaseContext.Remove(entity: foundedEmployees);

	//	await DatabaseContext
	//		.SaveChangesAsync();

	//	return NoContent();
	//}

	// Delete with CQRS!
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> DeleteEmployeesAsync(System.Guid id)
	{
		var request = new Api.Features
			.Payroll.Employees.Commands.DeleteEmployeeCommand(Id: id);

		var result =
			await
			Mediator.Send(request: request);

		if (result == false)
		{
			return NotFound();
		}

		return NoContent();
	}
	#endregion /Action: DeleteCustomerAsync
}
// **************************************************
