# Component Name
## WebAwesomeBlazor.Components.WARichTextEditor

```HTML+Razor
<WARichTextEditor @bind-Value="value" />
```

### Description
Rich text editors let users write and format content with a toolbar and keyboard shortcuts, and submit the result as HTML like a textarea.

[Web Awesome docs](https://webawesome.com/docs/components/rich-text-editor)

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Value` | `string` | `null` | The HTML/content value of the editor. Supports two-way binding via `@bind-Value`. |
| `PlainTextValue` | `string` | `null` | The plain text representation of the editor content. Supports two-way binding via `@bind-PlainTextValue`. |
| `Changed` | `EventCallback<string>` | - | Invoked when the editor value has been committed by the user. |
| `Appearance` | `InputAppearance` | `Outlined` | Controls the visual appearance of the editor. |
| `AutoCapitalize` | `InputAutoCapitalize?` | `null` | Controls whether and how text is automatically capitalised while typing. |
| `AutoCorrect` | `bool` | `true` | Enables or disables the browser's autocorrect functionality. |
| `Disabled` | `bool` | `false` | Disables user interaction with the editor. |
| `EnterKeyHint` | `InputEnterKeyHint?` | `Enter` | Customises the label or icon displayed for the Enter key on supported virtual keyboards. |
| `Size` | `InputSize` | `Inherit` | Controls the overall size of the editor. |
| `Label` | `string?` | `null` | Label displayed for the editor. |
| `Hint` | `string?` | `null` | Additional hint text displayed below the editor. |
| `Placeholder` | `string?` | `null` | Placeholder text displayed when the editor is empty. |
| `ReadOnly` | `bool` | `false` | Makes the editor read-only while still allowing content selection and interaction with the content. |
| `Required` | `bool` | `false` | Indicates that a value is required for validation. |
| `InputMode` | `InputInputMode` | `Text` | Provides a hint to the browser about the type of data being entered, allowing it to display an appropriate virtual keyboard on supported devices. |
| `Spellcheck` | `bool` | `false` | Enables browser spell checking within the editor. |
| `Focused` | `EventCallback` | - | Invoked when the editor receives focus. |
| `Blurred` | `EventCallback` | - | Invoked when the editor loses focus. |
| `SuggestionError` | `EventCallback<RichTextEditorSuggestionError>` | - | Invoked when an error occurs while retrieving suggestions. Provides the `ErrorMessage`, the `Trigger` used, and the `Query` entered by the user. |
| `SelectionChanged` | `EventCallback` | - | Invoked when the current text selection within the editor changes. |

### Methods

| Method | Parameters | Description |
|----------|----------|-------------|
| `SetValueAsync` | `value: string` | Sets the editor value and updates both the HTML and plain text representations. Triggers value binding and form validation updates. |
| `SetFocusAsync` | None | Sets keyboard focus to the editor. |
| `AddSuggestionAsync` | `suggestion: RichTextEditorSuggestion` | Registers a new suggestion trigger and callback source for features such as mentions, tags, or custom autocomplete providers. See usage in examples below.  |
| `InsertTextAsync` | `text: string` | Replaces the current selection with plain text. |
| `InsertHtmlAsync` | `html: string` | Replaces the current selection with HTML content. Unsupported markup is automatically removed. |
| `UndoAsync` | None | Undoes the most recent edit and returns whether an undo operation was available. |
| `RedoAsync` | None | Redoes the most recently undone edit and returns whether a redo operation was available. |
| `SelectAllAsync` | None | Selects all content within the editor. Has no effect when the editor is disabled. |
| `GetSelectedTextAsync` | None | Returns the currently selected text. |
| `DeleteSelectedTextAsync` | None | Removes the currently selected text from the editor. |
| `CanRedoAsync` | None | Returns whether a redo operation is currently available. |
| `CanUndoAsync` | None | Returns whether an undo operation is currently available. |
| `SetOptionsAsync` | `options: RichTextEditorOptions` | Sets the display and editing options for the editor. |

#### RichTextEditorOptions
| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `DisabledFeatures` | `RichTextEditorFeatures` | `new()` | Features to remove from the editor. Disabled features have their toolbar buttons, keyboard shortcuts, input rules, and pasted content support removed. Content using disabled features is automatically stripped from the editor value. Provided as a list of `RichTextEditorFeatureOptions` |
| `UseMarkdown` | `bool` | `false` | Stores the editor value in Markdown format instead of HTML. |
| `HeadingLevels` | `RichTextEditorHeadingLevel[]` | `RichTextEditorHeadingLevel.H1`, `RichTextEditorHeadingLevel.H2`, `RichTextEditorHeadingLevel.H3` | Determines which heading levels users can apply. Unsupported heading levels are converted to the nearest permitted level. Set all levels to false or provide an empty collection to remove heading support. Provided as a list of `RichTextEditorHeadingLevel` |
| `HighlightColors` | `RichTextEditorColorOptions?` | `null` | Defines the highlight colours available in the colour picker.  Provide as either a semicolon-separated list of CSS colors, a string array, or `List<EditorColor>{ new EditorColor(CSSStringValue, DisplayLabel), ...}` |
| `IconLibrary` | `string` | `"system"` | Specifies the icon library used for toolbar and popover icons. Use a registered icon library to integrate custom icon sets such as Font Awesome. |
| `LinkRel` | `string` | `""` | Specifies the `rel` attribute applied to links created within the editor. Overrides the default value applied by the target setting. |
| `LinkTarget` | `string` | `""` | Specifies the `target` attribute applied to links created within the editor. When set to `_blank`, `noopener noreferrer` is automatically added. |
| `MaxLength` | `int?` | `null` | The maximum number of plain text characters allowed for validation. Users can continue typing beyond this limit, but the editor becomes invalid. |
| `MinLength` | `int?` | `null` | The minimum number of plain text characters required for validation. |
| `TextColors` | `RichTextEditorColorOptions?` | `null` | Defines the text colours available in the colour picker. Provide as either a semicolon-separated list of CSS colors, a string array, or `List<EditorColor>{ new EditorColor(CSSStringValue, DisplayLabel), ...}` |
| `Toolbar` | `RichTextEditorToolbarOptions` | `[]` | Defines which tools are displayed in the editor toolbar and the order in which they appear. Provided as a list of `RichTextEditorToolbarItem` |
| `ToolbarPlacement` | `RichTextEditorToolbarPlacement` | `Top` | Determines where the toolbar is displayed relative to the editor, top or bottom. |
| `AutoLink` | `bool` | `true` | Automatically converts recognised URLs into links as users type. |
| `ShowCount` | `bool` | `false` | Displays a character count below the editor. When `MaxLength` is set, displays the remaining character count instead. |
| `DisableMarkdownShortcuts` | `bool` | `false` | Disables Markdown-style input shortcuts such as headings (`#`), lists (`-`), and highlights (`==text==`). Keyboard shortcuts remain available. |
| `DisableSmartPunctuation` | `bool` | `false` | Disables smart punctuation features such as automatic quotation marks and replacement of `...` and `--` with typographic equivalents. |

### Examples

#### Basic Usage
```HTML+Razor
<WARichTextEditor @bind-Value="value" />
```

#### Setting editor options
```HTML+Razor
<WARichTextEditor @ref="richTextEditor" />

@code
{
	WARichTextEditor richTextEditor = default!;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var editorOptions = new RichTextEditorOptions()
            {
                TextColors =
                    new List<EditorColor>
                             {
                                new EditorColor("#FF0000", "Red"),
                                new EditorColor("#00FF00", "Green"),
                                new EditorColor("#0000FF", "Blue")
                             },
                HighlightColors = "rgb(248 113 113 / 40%); rgb(251 146 60 / 40%); rgb(250 204 21 / 40%); ",
                DisabledFeatures =
                    [
                       RichTextEditorFeatureOption.Bold,
                       RichTextEditorFeatureOption.BulletList
                    ],
                HeadingLevels = 
                    [
                        RichTextEditorHeadingLevel.H1,
                        RichTextEditorHeadingLevel.H2,
                        RichTextEditorHeadingLevel.H3,
                        RichTextEditorHeadingLevel.H4,
                    ],
                Toolbar =
                    [
                        RichTextEditorToolbarItem.Align,
                        RichTextEditorToolbarItem.Divider,
                        RichTextEditorToolbarItem.Bold,
                        RichTextEditorToolbarItem.Italic,
                        RichTextEditorToolbarItem.Underline,
                        RichTextEditorToolbarItem.Divider,
                        RichTextEditorToolbarItem.Color,
                        RichTextEditorToolbarItem.Divider,
                        RichTextEditorToolbarItem.Undo,
                        RichTextEditorToolbarItem.Redo
                    ],
                UseMarkdown = true
            };
            await richTextEditor.SetOptionsAsync(editorOptions);
        }

    }
```

#### Providing a suggestion list
```HTML+Razor
<WARichTextEditor @ref="richTextEditor" />

@code
{
	WARichTextEditor richTextEditor = default!;
	List<RichTextEditorSuggestionItem> suggestions = new()
    {
        new RichTextEditorSuggestionItem(){ Label = "John", Description = "IT Manager", Value="1"},
        new RichTextEditorSuggestionItem(){ Label = "Jerry", Description = "CEO", Value="2"},
        new RichTextEditorSuggestionItem(){ Label = "Kerry", Description = "Customer Service Agent", Value="3"},
        new RichTextEditorSuggestionItem(){ Label = "Kat", Description = "Customer Service Agent", Value="4"},
        new RichTextEditorSuggestionItem(){ Label = "Kate", Description = "CS Lead", Value="5"},
        new RichTextEditorSuggestionItem(){ Label = "Kath", Description = "Customer Service Agent", Value="6"},
        new RichTextEditorSuggestionItem(){ Label = "Kathryn", Description = "Customer Service Agent", Value="7"},
        new RichTextEditorSuggestionItem(){ Label = "Katlyn", Description = "Customer Service Agent", Value="8"},
        new RichTextEditorSuggestionItem(){ Label = "Alex", Description = "Customer Service Manager", Value="9"},
    };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender) await richTextEditor.AddSuggestionAsync(new(trigger: "@", function: (async query => await GetSuggestions(query))));
    }

    async Task<List<RichTextEditorSuggestionItem>> GetSuggestions(string query)
    {
        return suggestions
            .OrderBy(name => name.Label)
            .Where(name => name.Label.Contains(query, StringComparison.InvariantCultureIgnoreCase))
            .Take(5)
            .ToList();
    }
}

```