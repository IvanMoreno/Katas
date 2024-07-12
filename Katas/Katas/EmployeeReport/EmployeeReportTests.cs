using FluentAssertions;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [] See the employees who are 18 years or older

public class EmployeeReportTests
{
    [Test]
    public void SelectEmployees_With18YearsOrOlder()
    {
        var doc = new List<Employee> { Employee.Of(years: 17), Employee.Of(years: 18), Employee.Of(years: 54) };

        new Report().ShowEligibleFrom(doc).Should().HaveCount(2);
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

    Employee(int years) => Years = years;
    public static Employee Of(int years) => new(years);
}