using static Katas.EmployeeReport.Employee;

namespace Katas.EmployeeReport;

public class Report
{
    public static Report WithInitialFilters()
    {
        return new Report();
    }

    public IEnumerable<Employee> EligibleFrom(IEnumerable<Employee> staff)
    {
        return staff
            .Where(x => x.Years >= 18)
            .OrderBy(x => x.Name)
            .Select(Capitalize);
    }

    static Employee Capitalize(Employee who) => Hire(who.Years, who.Name.ToUpper());
}