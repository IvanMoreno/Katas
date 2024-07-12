using FluentAssertions;
using static Katas.EmployeeReport.Employee;
using static Katas.EmployeeReport.EmployeeFilter;

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
        Report.WithInitialFilters().EligibleFrom(StaffOf(Hire(17, "John"), Hire(18, "John"), Hire(54, "John")))
            .Should().HaveCount(2).And
            .NotContain(Hire(17, "JOHN"));
    }

    [Test]
    public void SortEmployees_ByTheirNames()
    {
        Report.WithInitialFilters().EligibleFrom(StaffOf(Hire(18, "Ivan"), Hire(19, "Abigail")))
            .First().Should().Be(Hire(19, "ABIGAIL"));
    }

    [Test]
    public void SortEmployees_ByTheirNames_InDescendingOrder()
    {
        OrderByNamesDescending
            .ApplyFor(StaffOf(Hire(19, "Abigail"), Hire(18, "Ivan")))
            .First().Should().Be(Hire(18, "Ivan"));
    }

    static IEnumerable<Employee> StaffOf(params Employee[] allEmployees) => allEmployees;
}