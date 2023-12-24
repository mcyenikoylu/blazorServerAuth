namespace BlazorServerAuthApp;

public class UserAccount
{
    // public string? EmployeeEmail { get; set; }
    // public string? LoginPassword { get; set; }
    // public string? Role { get; set; }
    // public string? EmployeeFullName { get; set; }
    // public string? categoryId { get; set; }
    // public string? id { get; set; }

    public Guid? id { get; set; }
    public string? categoryId { get; set; }
    public string? EmployeeFullName { get; set; }
    public string? EmployeeEmail { get; set; }
    public string? AgencyName { get; set; }
    public string? EmployeeCountryName { get; set; }
    public string? LoginPassword { get; set; }
    public string? Role { get; set; }
}