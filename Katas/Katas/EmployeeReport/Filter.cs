using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

public class Filter
{
    readonly Func<IEnumerable<Employee>, IEnumerable<Employee>> filter;
    Filter(Func<IEnumerable<Employee>, IEnumerable<Employee>> filter) => this.filter = filter;

    public IEnumerable<Employee> ApplyFor(IEnumerable<Employee> staff) => filter(staff);
    
    public static Filter OrderByNamesDescending => new(staff => staff.OrderByDescending(x => x.Name));
    public static Filter OrderByNames => new(staff => staff.OrderBy(x => x.Name));
    public static Filter Only18OrOlder => new(staff => staff.Where(x => x.Years >= 18));
    public static Filter CapitalizeNames => new(staff => staff.Select(x => Hire(x.Years, x.Name.ToUpper())));
}