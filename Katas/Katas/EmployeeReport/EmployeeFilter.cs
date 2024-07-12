using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

public class EmployeeFilter
{
    readonly Func<IEnumerable<Employee>, IEnumerable<Employee>> filter;
    EmployeeFilter(Func<IEnumerable<Employee>, IEnumerable<Employee>> filter) => this.filter = filter;

    public IEnumerable<Employee> ApplyFor(IEnumerable<Employee> staff) => filter(staff);
    public static EmployeeFilter OrderByNamesDescending => new(staff => staff.OrderByDescending(x => x.Name));
    public static EmployeeFilter OrderByNames => new(staff => staff.OrderBy(x => x.Name));
    public static EmployeeFilter Only18OrOlder => new(staff => staff.Where(x => x.Years >= 18));
    public static EmployeeFilter CapitalizeNames => new(staff => staff.Select(x => Hire(x.Years, x.Name.ToUpper())));
}