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
    {
        var result = staff;
        foreach (var filter in filters)
        {
            result = filter.ApplyFor(result);
        }

        return result;
    }

    static Employee Capitalize(Employee who) => Hire(who.Years, who.Name.ToUpper());
}