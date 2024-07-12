using FluentAssertions;
using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [x] See the employees who are 18 years or older
// [] Sort employees names by their names

public class EmployeeReportTests
{
    [Test]
    public void SelectEmployees_With18YearsOrOlder()
    {
        var doc = new List<Employee> { Hire(17, "John"), Hire(18, "John"), Hire(54, "John") };

        new Report().ShowEligibleFrom(doc)
            .Should().HaveCount(2).And
            .NotContain(Hire(17, "John"));
    }
}

public class Report
{
    public IEnumerable<Employee> ShowEligibleFrom(IEnumerable<Employee> allEmployees)
    {
        return allEmployees.Where(x => x.Years >= 18);
    }
}

public struct Employee
{
    public readonly int Years;
    public readonly string Name;

    Employee(int years) => Years = years;
    Employee(int years, string name)
    {
        Years = years;
        this.Name = name;
    }

    public static Employee Hire(int years, string name) => new(years, name);
}