using FluentAssertions;
using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [x] See the employees who are 18 years or older
// [x] Sort employees names by their names
// [] Capitalize employees names

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

    [Test]
    public void SortEmployees_ByTheirNames()
    {
        var doc = new List<Employee> { Hire(18, "Ivan"), Hire(19, "Abigail") };

        new Report().ShowEligibleFrom(doc)
            .First().Should().Be(Hire(19, "Abigail"));
    }
}