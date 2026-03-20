const editors = {};
let monacoReadyPromise;

function ensureMonacoLoaded() {
    if (window.monaco && window.monaco.editor) return Promise.resolve();
    if (!monacoReadyPromise) {
        monacoReadyPromise = new Promise((resolve) => {
            window.require.config({ paths: { vs: 'https://cdn.jsdelivr.net/npm/monaco-editor@0.52.2/min/vs' } });
            window.require(['vs/editor/editor.main'], () => resolve());
        });
    }
    return monacoReadyPromise;
}

export async function createMonacoEditor(elementId, options) {
    await ensureMonacoLoaded();
    const host = document.getElementById(elementId);
    if (!host) return;

    const editor = monaco.editor.create(host, {
        value: options.value ?? '',
        language: options.language ?? 'csharp',
        theme: options.theme ?? 'vs',
        automaticLayout: true,
        minimap: { enabled: false },
        fontSize: 14,
        roundedSelection: true,
        scrollBeyondLastLine: false
    });

    editor.onDidChangeModelContent(() => {
        options.dotNetRef.invokeMethodAsync('NotifyValueChanged', editor.getValue());
    });

    editors[elementId] = editor;
}

export function getValue(elementId) { return editors[elementId]?.getValue() ?? ''; }
export function setValue(elementId, value) {
    const editor = editors[elementId];
    if (editor && editor.getValue() !== value) editor.setValue(value ?? '');
}
export function disposeEditor(elementId) {
    const editor = editors[elementId];
    if (!editor) return;
    editor.dispose();
    delete editors[elementId];
}
