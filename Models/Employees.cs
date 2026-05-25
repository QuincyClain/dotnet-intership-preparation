using System.Security.Cryptography.X509Certificates;

namespace OopPractice;

public class Employee
{
    public string Name { get; private set; }
    public decimal BaseSalary { get; private set; }

    public Employee(string name, decimal baseSalary)
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

    public virtual decimal CalculateSalary()
    {
        return BaseSalary;
    }

    public virtual string PrintInfo()
    {
        return $"Employee: {Name}, Salary: {CalculateSalary()}";
    }
}

public class Manager: Employee
{
    public decimal Bonus { get; private set; }

    public Manager(string name, decimal baseSalary, decimal bonus) : base(name, baseSalary)
    {
        if (bonus < 0)
        {
            throw new ArgumentException("Bonus can not be negative");
        }
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + Bonus;
    }

    public override string PrintInfo()
    {
        return $"Manager: {Name}, Salary: {CalculateSalary()}, Bonus: {Bonus}";
    }
}

public class Developer: Employee
{
    public decimal OvertimePayment { get; private set; }

    public Developer (string name, decimal baseSalary, decimal overtimePayment) : base(name, baseSalary)
    {
        if (overtimePayment < 0)
        {
            throw new ArgumentException("Overtime Payment can not be negative!");
        }

        OvertimePayment = overtimePayment;
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + OvertimePayment;
    }

    public override string PrintInfo()
    {
        return $"Developer: {Name}, Salary: {CalculateSalary()}, Overtime Payment: {OvertimePayment}";
    }
}