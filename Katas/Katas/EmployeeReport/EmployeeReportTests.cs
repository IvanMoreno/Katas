using FluentAssertions;
using static Katas.EmployeeReport.Employee;
using static Katas.EmployeeReport.EmployeeFilter;

namespace Katas.EmployeeReport;

// https://codingdojo.org/kata/Employee-Report/
// [x] See the employees who are 18 years or older
// [x] Sort employees by their names
// [x] Capitalize employees names
// [x] Sort employees by their names DESCENDING

public class EmployeeReportTests
{
    [Test]
    public void SelectEmployees_With18YearsOrOlder()
    {
        var underageEmployee = Hire(17, "Matias");
        
        Only18OrOlder
            .ApplyFor(StaffOf(underageEmployee, Hire(18, "John"), Hire(54, "John")))
            .Should().HaveCount(2).And
            .NotContain(underageEmployee);
    }

    [Test]
    public void SortEmployees_ByTheirNames_InDescendingOrder()
    {
        OrderByNamesDescending
            .ApplyFor(StaffOf(Hire(19, "Abigail"), Hire(18, "Ivan")))
            .First().Should().Be(Hire(18, "Ivan"));
    }

    [Test]
    public void Report_CanCompose_SeveralFilters()
    {
        new Report(Only18OrOlder, OrderByNames, CapitalizeNames)
            .EligibleFrom(StaffOf(Hire(18, "Ivan"), Hire(19, "Abigail")))
            .First().Should().Be(Hire(19, "ABIGAIL"));
    }

    static IEnumerable<Employee> StaffOf(params Employee[] allEmployees) => allEmployees;
}