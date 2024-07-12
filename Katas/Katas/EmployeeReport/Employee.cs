namespace Katas.EmployeeReport;

public struct Employee
{
    public readonly int Years;
    public readonly string Name;

    Employee(int years, string name)
    {
        Years = years;
        Name = name;
    }

    public static Employee Hire(int years, string name) => new(years, name);
}