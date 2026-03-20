namespace MonacoBlazorWasmSample.Client.Models;

public static class SeamTemplates
{
    public static readonly SeamTemplateModel BeforeEmployeeSaved = new()
    {
        Key = "BeforeEmployeeSaved",
        Name = "Before Employee Saved",
        Template = """
var result = BeforeEmployeeSavedResult.Success();

if (string.IsNullOrWhiteSpace(Employee.EmployeeNumber))
{
    result.AddError("Employee number is required.");
}

if (!Employee.IsActive && Employee.EndDate is null)
{
    result.AddError("Inactive employees must have an end date.");
}

return result;
"""
    };

    public static readonly IReadOnlyList<SeamTemplateModel> All = new[]
    {
        BeforeEmployeeSaved
    };
}
