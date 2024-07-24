namespace isalary
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    public interface ISalaryCalculator
    {
        double CalculateSalary(Employee employee);
    }

    public class BasicSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee)
        {
            return employee.Salary;
        }
    }
}