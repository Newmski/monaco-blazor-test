using MonacoBlazorWasmSample.Client.Models;

namespace MonacoBlazorWasmSample.Client.Services;

public interface IScriptValidationService
{
    Task<ScriptValidationResultModel> ValidateAsync(string seam, string code);
}
