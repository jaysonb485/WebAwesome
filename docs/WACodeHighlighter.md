# WACodeHighlighter
## WebAwesomeBlazor.Components.WACodeHighlighter

```HTML+Razor
<WACodeHighlighter Code="@code" />
```

### Description
Code highlighters display syntax-highlighted code with a copy button. Use them for code samples, install commands, and configuration snippets.

[Web Awesome docs](https://webawesome.com/docs/components/code-highlighter)

### Properties
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Code` | `string?` | `null` | The code to display. When provided, it takes precedence over `ChildContent` and is rendered exactly as supplied without dedenting. Useful for dynamic code or content that would otherwise require extensive escaping. |
| `Label` | `string?` | `null` | Accessible label used to describe the code region. When omitted, a localized "Code" label is used. |
| `CodeLanguage` | `string?` | `null` | Specifies the language used for syntax highlighting, such as `html`, `css`, `js`, or `python`. Leave empty to display plain text without highlighting. |
| `ShowCopyButton` | `bool` | `true` | Shows a button that allows users to copy the displayed code to the clipboard. |
| `Dedent` | `bool` | `true` | Removes common leading indentation from `ChildContent` before rendering. Disable to preserve the content exactly as written. |
| `Wrap` | `bool` | `false` | Wraps long lines instead of displaying a horizontal scrollbar. |
| `GrammarError` | `EventCallback` | - | Invoked when no syntax grammar is available for the specified language. The code is rendered as plain text. |
| `Loaded` | `EventCallback` | - | Invoked after the language grammar has loaded and syntax highlighting has been applied. |

### Examples

#### Basic Usage
```HTML+Razor
<WACodeHighlighter CodeLanguage="html">
    &lt;wa-button variant="brand"&gt;
    &lt;wa-icon slot="start" name="rocket"&gt;&lt;/wa-icon&gt;
    Launch
    &lt;/wa-button&gt;
</WACodeHighlighter>
```

```HTML+Razor
<WACodeHighlighter CodeLanguage="rust" Code="@RustCode" ShowCopyButton="false" />

@code
{
    string RustCode = """ 
        fn main()
        {
            let crabs = ["Ferris", "Sebastian", "Mr. Krabs"];

            for crab in crabs.iter() {
                println!("Hello, {crab}!");
            }
        }
    """;
}
```