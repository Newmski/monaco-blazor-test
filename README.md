# Monaco + Blazor WASM sample (GitHub Pages ready)

This sample is prepared for deployment to GitHub Pages.

## What is included

- Blazor WebAssembly client app
- Monaco Editor loaded from CDN
- Reusable `MonacoEditor.razor` component
- Sample script editor page for `BeforeEmployeeSaved`
- Fake client-side validation service
- GitHub Actions workflow for Pages deployment

## Publish to GitHub Pages

1. Create a new GitHub repository.
2. Upload the contents of this ZIP to the repository root.
3. Push to the `main` branch.
4. In GitHub, open **Settings → Pages**.
5. Ensure **Source** is set to **GitHub Actions**.
6. Open the **Actions** tab and wait for the workflow named **Deploy Blazor WASM to GitHub Pages** to finish.
7. Your app will be available at:
   - `https://<your-user>.github.io/<your-repo>/`

## Notes

- The workflow automatically rewrites the Blazor `<base href>` using the repository name.
- It also copies `index.html` to `404.html` so client-side routing works on GitHub Pages.
- Monaco is loaded from a CDN in `wwwroot/index.html`.
- Replace `FakeScriptValidationService` with a real API call when you integrate Roslyn validation.

## Local development

Run the app locally with the normal Blazor workflow:

```bash
dotnet restore
dotnet run --project MonacoBlazorWasmSample.Client
```
