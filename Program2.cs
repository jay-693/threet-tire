using isalary;
// Interface for employee repository
namespace spm
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        Employee GetEmployee(string name);
    }

    // Implementation of employee repository
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault(e => e.Name == name);
        }
    }

    // High-level module that depends on abstractions (interfaces)
    public class PayrollService 
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISalaryCalculator salaryCalculator;

        public PayrollService(IEmployeeRepository employeeRepository, ISalaryCalculator salaryCalculator)
        {
            this.employeeRepository = employeeRepository;
            this.salaryCalculator = salaryCalculator;
        }

        public double GetSalary(string employeeName)
        {
            var employee = employeeRepository.GetEmployee(employeeName);
            if (employee != null)
            {
                return salaryCalculator.CalculateSalary(employee);
            }
            else
            {
                throw new ArgumentException($"Employee '{employeeName}' not found.");
            }
        }
    }
}
