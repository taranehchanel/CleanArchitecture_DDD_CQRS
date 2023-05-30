namespace Domain.Features.Payroll.Employees;

public class Employee : object
{
	#region Constructor
	/// <summary>
	/// Because of Dapper!
	/// </summary>
	private Employee() : base()
	{
		LastName = string.Empty;
		FirstName = string.Empty;
	}

	public Employee(string firstName, string lastName) : base()
	{
		LastName = lastName;
		FirstName = firstName;

		Id = System.Guid.NewGuid();
	}
	#endregion /Constructor

	#region Properties

	#region public System.Guid Id { get; private set; }
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; private set; }
	#endregion /public System.Guid Id { get; private set; }

	#region public string LastName { get; set; }
	/// <summary>
	/// نام خانوادگی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastName))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 50,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string LastName { get; set; }
	#endregion /public string LastName { get; set; }

	#region public string FirstName { get; set; }
	/// <summary>
	/// نام
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.FirstName))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: 50,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string FirstName { get; set; }
	#endregion /public string FirstName { get; set; }

	#region public decimal BasicSalary { get; set; }
	/// <summary>
	/// حقوق پایه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.BasicSalary))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public decimal BasicSalary { get; set; }
	#endregion /public decimal BasicSalary { get; set; }

	#region public decimal Allowance { get; set; }
	/// <summary>
	/// فوق‌العاده حق جذب
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Allowance))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public decimal Allowance { get; set; }
	#endregion /public decimal Allowance { get; set; }

	#region public decimal Transportation { get; set; }
	/// <summary>
	/// حق ایاب و ذهاب
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Transportation))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public decimal Transportation { get; set; }
	#endregion /public decimal Transportation { get; set; }

	#region public decimal Salary { get; private set; }
	/// <summary>
	/// حقوق
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Salary))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
	public decimal Salary { get; private set; }
	#endregion /public decimal Salary { get; private set; }

	#region public System.DateTime Date { get; set; }
	/// <summary>
	/// تاریخ
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Date))]

	[System.ComponentModel.DataAnnotations.Required
		(AllowEmptyStrings = false,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTime Date { get; set; }
	#endregion /public System.DateTime Date { get; set; }

	#endregion /Properties

	#region Methods

	public void CalculateSalary
		(OverTimePolicies.ICalculator calculator)
	{
		var overTime = calculator.Calculate
			(basicSalary: BasicSalary, allowance: Allowance);

		var tax = (decimal)0.1;

		Salary =
			BasicSalary + Allowance + Transportation + overTime - tax;
	}

	#endregion /Methods
}
