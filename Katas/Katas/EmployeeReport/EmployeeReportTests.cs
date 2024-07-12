using FluentAssertions;
using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [x] See the employees who are 18 years or older
// [x] Sort employees by their names
// [x] Capitalize employees names
// [] Sort employees by their names DESCENDING

public class EmployeeReportTests
{
    [Test]
    public void SelectEmployees_With18YearsOrOlder()
    {
        new Report().EligibleFrom(StaffOf(Hire(17, "John"), Hire(18, "John"), Hire(54, "John")))
            .Should().HaveCount(2).And
            .NotContain(Hire(17, "JOHN"));
    }

    [Test]
    public void SortEmployees_ByTheirNames()
    {
        new Report().EligibleFrom(StaffOf(Hire(18, "Ivan"), Hire(19, "Abigail")))
            .First().Should().Be(Hire(19, "ABIGAIL"));
    }

    static IEnumerable<Employee> StaffOf(params Employee[] allEmployees) => allEmployees;
}