namespace Katas.EmployeeReport;

public class Report(params EmployeeFilter[] filters)
{
    public IEnumerable<Employee> EligibleFrom(IEnumerable<Employee> staff) 
        => filters.Aggregate(staff, (current, filter) => filter.ApplyFor(current));
}