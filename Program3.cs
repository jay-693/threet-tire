using spm;
using isalary;
class Program
{
    public static void Main(string[] args)
    {
        // Create instances of dependencies
        var employeeRepository = new EmployeeRepository();
        var salaryCalculator = new BasicSalaryCalculator();

        // Inject dependencies into PayrollService
        var payrollService = new PayrollService(employeeRepository, salaryCalculator);

        // Add employees
        employeeRepository.AddEmployee(new Employee { Name = "Alice", Salary = 50000 });
        employeeRepository.AddEmployee(new Employee { Name = "Bob", Salary = 60000 });

        // Calculate salary
        Console.WriteLine($"Alice's salary: {payrollService.GetSalary("Alice")}");
        Console.WriteLine($"Bob's salary: {payrollService.GetSalary("Bob")}");
    }
}
