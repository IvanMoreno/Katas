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

    [Test]
    public void SortEmployees_ByTheirNames_InDescendingOrder()
    {
        EmployeeFilter.OrderByNamesDescending
            .ApplyFor(StaffOf(Hire(19, "Abigail"), Hire(18, "Ivan")))
            .First().Should().Be(Hire(18, "Ivan"));
    }

    static IEnumerable<Employee> StaffOf(params Employee[] allEmployees) => allEmployees;
}

public class EmployeeFilter
{
    readonly Func<IEnumerable<Employee>, IEnumerable<Employee>> filter;
    EmployeeFilter(Func<IEnumerable<Employee>, IEnumerable<Employee>> filter) => this.filter = filter;

    public IEnumerable<Employee> ApplyFor(IEnumerable<Employee> staff) => filter(staff);
    public static EmployeeFilter OrderByNamesDescending => new(staff => staff.OrderByDescending(x => x.Name));
}