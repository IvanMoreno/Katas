namespace Katas.EmployeeReport;

public class Report
{
    public IEnumerable<Employee> ShowEligibleFrom(IEnumerable<Employee> allEmployees)
    {
        return allEmployees.Where(x => x.Years >= 18).OrderBy(x => x.Name);
    }
}