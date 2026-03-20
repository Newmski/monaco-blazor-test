using MonacoBlazorWasmSample.Client.Models;

namespace MonacoBlazorWasmSample.Client.Services;

public sealed class FakeScriptValidationService : IScriptValidationService
{
    public Task<ScriptValidationResultModel> ValidateAsync(string seam, string code)
    {
        var diagnostics = new List<ScriptDiagnosticModel>();

        if (!code.Contains("return result;", StringComparison.Ordinal))
        {
            diagnostics.Add(new ScriptDiagnosticModel
            {
                Severity = "Error",
                Line = FindLine(code, "return"),
                Column = 1,
                Message = "Script should return result."
            });
        }

        if (string.Equals(seam, "BeforeEmployeeSaved", StringComparison.Ordinal) &&
            !code.Contains("BeforeEmployeeSavedResult.Success()", StringComparison.Ordinal))
        {
            diagnostics.Add(new ScriptDiagnosticModel
            {
                Severity = "Warning",
                Line = 1,
                Column = 1,
                Message = "The starter convention is to initialise with BeforeEmployeeSavedResult.Success()."
            });
        }

        return Task.FromResult(new ScriptValidationResultModel
        {
            Success = diagnostics.All(x => !string.Equals(x.Severity, "Error", StringComparison.OrdinalIgnoreCase)),
            Diagnostics = diagnostics
        });
    }

    private static int FindLine(string code, string token)
    {
        var lines = code.Replace("\r\n", "\n").Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(token, StringComparison.Ordinal))
                return i + 1;
        }

        return 1;
    }
}
