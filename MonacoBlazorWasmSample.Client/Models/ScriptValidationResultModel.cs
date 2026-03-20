namespace MonacoBlazorWasmSample.Client.Models;

public sealed class ScriptValidationResultModel
{
    public bool Success { get; set; }
    public IReadOnlyList<ScriptDiagnosticModel> Diagnostics { get; set; } = Array.Empty<ScriptDiagnosticModel>();
}
