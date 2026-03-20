namespace MonacoBlazorWasmSample.Client.Models;

public sealed class ScriptDiagnosticModel
{
    public string Severity { get; set; } = string.Empty;
    public int Line { get; set; }
    public int Column { get; set; }
    public string Message { get; set; } = string.Empty;
}
