namespace Katas.EmployeeReport;

public class EmployeeFilter
{
    readonly Func<IEnumerable<Employee>, IEnumerable<Employee>> filter;
    EmployeeFilter(Func<IEnumerable<Employee>, IEnumerable<Employee>> filter) => this.filter = filter;

    public IEnumerable<Employee> ApplyFor(IEnumerable<Employee> staff) => filter(staff);
    public static EmployeeFilter OrderByNamesDescending => new(staff => staff.OrderByDescending(x => x.Name));
}