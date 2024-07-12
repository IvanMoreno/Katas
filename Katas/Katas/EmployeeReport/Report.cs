namespace Katas.EmployeeReport;

public class Report
{
    public IEnumerable<Employee> ShowEligibleFrom(IEnumerable<Employee> allEmployees)
    {
        return allEmployees
            .Where(x => x.Years >= 18)
            .OrderBy(x => x.Name)
            .Select(Capitalize);
    }

    Employee Capitalize(Employee who)
    {
        return Employee.Hire(who.Years, who.Name.ToUpper());
    }
}