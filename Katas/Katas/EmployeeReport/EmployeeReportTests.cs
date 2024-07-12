using FluentAssertions;
using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [x] See the employees who are 18 years or older
// [x] Sort employees names by their names
// [x] Capitalize employees names

public class EmployeeReportTests
{
    [Test]
    public void SelectEmployees_With18YearsOrOlder()
    {
        new Report().ShowEligibleFrom(StaffOf(Hire(17, "John"), Hire(18, "John"), Hire(54, "John")))
            .Should().HaveCount(2).And
            .NotContain(Hire(17, "JOHN"));
    }

    [Test]
    public void SortEmployees_ByTheirNames()
    {
        new Report().ShowEligibleFrom(StaffOf(Hire(18, "Ivan"), Hire(19, "Abigail")))
            .First().Should().Be(Hire(19, "ABIGAIL"));
    }

    static IEnumerable<Employee> StaffOf(params Employee[] allEmployees) => allEmployees;
}