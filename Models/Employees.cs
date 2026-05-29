using System.Security.Cryptography.X509Certificates;

namespace OopPractice;

public interface IReportable
{
    string GenerateReport();
}

public interface ICodeReviewer
{
    string ReviewCode();
}

public class ReportGenerator
{
    public string GenerateFor(string employeeName, string position)
    {
        return $"{position} {employeeName} generated report using ReportGenerator";
    }
}

public abstract class Employee
{
    protected string Name { get; private set; }
    protected decimal BaseSalary { get; private set; }
    public abstract string Position { get; }

    protected Employee(string name, decimal baseSalary)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name can not be empty!");
        }

        if (baseSalary < 0)
        {
            throw new ArgumentException("Base salary can not be negative!");
        }

        Name = name;
        BaseSalary = baseSalary;
    }

    public abstract decimal CalculateSalary();

    public virtual string PrintInfo()
    {
        return $"{Position}: {Name}, Salary: {CalculateSalary()}";
    }
}

public class Manager: Employee, IReportable
{
    public decimal Bonus { get; private set; }
    public override string Position => "Manager";

    private readonly ReportGenerator _reportGenerator;

    public Manager(string name, decimal baseSalary, decimal bonus, ReportGenerator reportGenerator) : base(name, baseSalary)
    {
        if (bonus < 0)
        {
            throw new ArgumentException("Bonus can not be negative");
        }
        Bonus = bonus;
        _reportGenerator = reportGenerator;
    }

    public string GenerateReport()
    {
        return $"{Position} {Name} generated team performance report.";
    }

    public string GenerateReportUsingReportGenerator()
    {
        return _reportGenerator.GenerateFor(Name, Position);
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }

    public override string PrintInfo()
    {
        return $"{Position}: {Name}, Salary: {CalculateSalary()}, Bonus: {Bonus}";
    }
}

public class Developer: Employee, ICodeReviewer
{
    public decimal OvertimePayment { get; private set; }
    
    public override string Position => "Developer";

    public Developer (string name, decimal baseSalary, decimal overtimePayment) : base(name, baseSalary)
    {
        if (overtimePayment < 0)
        {
            throw new ArgumentException("Overtime Payment can not be negative!");
        }

        OvertimePayment = overtimePayment;
    }

    public string ReviewCode()
    {
        return $"{Position} {Name} reviewed Pull Request.";
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + OvertimePayment;
    }

    public override string PrintInfo()
    {
        return $"{Position}: {Name}, Salary: {CalculateSalary()}, Overtime Payment: {OvertimePayment}";
    }
}