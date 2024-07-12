using static Katas.EmployeeReport.Employee;
using static Katas.EmployeeReport.EmployeeFilter;

namespace Katas.EmployeeReport;

public class Report
{
    readonly IEnumerable<EmployeeFilter> filters;
    public Report(IEnumerable<EmployeeFilter> filters) => this.filters = filters;

    public static Report WithInitialFilters()
    {
        return new Report(new[] { Only18OrOlder, OrderByNames, CapitalizeNames, });
    }

    public IEnumerable<Employee> EligibleFrom(IEnumerable<Employee> staff) 
        => filters.Aggregate(staff, (current, filter) => filter.ApplyFor(current));
}