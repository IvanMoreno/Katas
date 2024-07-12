using static Katas.EmployeeReport.EmployeeFilter;

namespace Katas.EmployeeReport;

public class Report(params EmployeeFilter[] filters)
{
    public static Report WithInitialFilters() => new(Only18OrOlder, OrderByNames, CapitalizeNames);

    public IEnumerable<Employee> EligibleFrom(IEnumerable<Employee> staff) 
        => filters.Aggregate(staff, (current, filter) => filter.ApplyFor(current));
}