namespace WebAwesomeBlazor.Components
{

    public class RichTextEditorOptions
    {
        /// <summary>
        /// Features available in the editor. To remove from the editor entirely set their corresponding properties to false: their tools, shortcuts, and input rules are left out, and they're stripped from the value and from pasted content. Use lists to remove both list types.
        /// </summary>
        public RichTextEditorFeatures DisabledFeatures { get; set; } = new();

        /// <summary>
        /// The format of the editor's value; Default is HTML. If UseMarkdown is true, the format will be Markdown.
        /// </summary>
        public bool UseMarkdown { get; set; } = false;
        /// <summary>
        /// The heading levels users can apply. Other headings are converted to the nearest allowed level. Set all to false to remove headings.
        /// </summary>
        public RichTextEditorHeadingLevels HeadingLevels { get; set; } =
            [
            RichTextEditorHeadingLevel.H1,
            RichTextEditorHeadingLevel.H2,
            RichTextEditorHeadingLevel.H3,
            ];

        /// <summary>
        /// The highlight colors offered in the color menu
        /// </summary>
        public RichTextEditorColorOptions? HighlightColors { get; set; }
        /// <summary>
        /// The icon library used for the toolbar and popover icons. Defaults to system.  Set it to default (or any registered library) to draw the icons from that library instead, e.g. to use Font Awesome Pro icons with a kit code.
        /// </summary>
        public string IconLibrary { get; set; } = "system";

        /// <summary>
        /// The rel given to links created in the editor. Overrides the default rel that _blank adds.
        /// </summary>
        public string LinkRel { get; set; } = string.Empty;


        /// <summary>
        /// The target given to links created in the editor. _blank also sets rel="noopener noreferrer".
        /// </summary>
        public string LinkTarget { get; set; } = string.Empty;
        /// <summary>
        /// The maximum number of characters of text, not counting markup, that will be considered valid. Typing beyond it isn't blocked; the editor becomes invalid
        /// </summary>
        public int? MaxLength { get; set; }
        /// <summary>
        /// The minimum number of characters of text, not counting markup, that will be considered valid.
        /// </summary>
        public int? MinLength { get; set; }


        /// <summary>
        /// The text colors offered in the color menu
        /// </summary>
        public RichTextEditorColorOptions? TextColors { get; set; }

        /// <summary>
        /// The tools to show in the toolbar. Add items to the list to show them in the toolbar. 
        /// </summary>
        public RichTextEditorToolbarOptions Toolbar { get; set; } = [];
        /// <summary>
        /// Where the toolbar sits.
        /// </summary>
        public RichTextEditorToolbarPlacement ToolbarPlacement { get; set; } = RichTextEditorToolbarPlacement.Top;

        /// <summary>
        /// Set to false to turn off linking URLs as they're typed.
        /// </summary>
        public bool AutoLink { get; set; } = true;

        /// <summary>
        /// Shows a character count below the editor. When maxlength is set, shows remaining characters instead.
        /// </summary>
        public bool ShowCount { get; set; } = false;

        /// <summary>
        /// Turns off the Markdown-style shortcuts that format content as users type, such as # for a heading, - for a list, and ==text== for a highlight. Keyboard shortcuts still work.
        /// </summary>
        public bool DisableMarkdownShortcuts { get; set; } = false;
        /// <summary>
        /// Turns off smart quotes and the replacement of ... and -- with an ellipsis and an em dash as users type.
        /// </summary>
        public bool DisableSmartPunctuation { get; set; } = false;

    }

    public sealed class EditorColor
    {
        public string Color { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public EditorColor(string color, string label)
        {
            Color = color;
            Label = label;
        }
    }

    public sealed class RichTextEditorHeadingLevels : List<RichTextEditorHeadingLevel>
    {
        public override string ToString()
        {
            return string.Join(" ",
             this.Select(x => x.GetDescription()));
        }
    }

    public sealed class RichTextEditorToolbarOptions : List<RichTextEditorToolbarItem>
    {
        public override string ToString()
        {
            return string.Join(" ",
             this.Select(x => x.GetDescription()));
        }
    }

    public sealed class RichTextEditorFeatures : List<RichTextEditorFeatureOption>
    {
        public override string ToString()
        {
            return string.Join(" ",
             this.Select(x => x.GetDescription()));
        }
    }


    public sealed class RichTextEditorColorOptions
    {
        private readonly string? _stringValue;
        private readonly string[]? _stringArrayValue;
        private readonly List<EditorColor>? _editorColors;

        private RichTextEditorColorOptions(
            string? stringValue = null,
            string[]? stringArrayValue = null,
            List<EditorColor>? editorColors = null)
        {
            _stringValue = stringValue;
            _stringArrayValue = stringArrayValue;
            _editorColors = editorColors;
        }

        public static implicit operator RichTextEditorColorOptions(string value)
        {
            return new(stringValue: value);
        }

        public static implicit operator RichTextEditorColorOptions(string[] value)
        {
            return new(stringArrayValue: value);
        }

        public static implicit operator RichTextEditorColorOptions(List<EditorColor> value)
        {
            return new(editorColors: value);
        }

        public override string ToString()
        {
            if (_stringValue is not null)
                return _stringValue;

            return string.Empty;
        }

        public object GetValue()
        {
            if (_stringValue is not null) return _stringValue;
            if (_stringArrayValue is not null) return _stringArrayValue;
            if (_editorColors is not null) return _editorColors;

            return string.Empty;
        }
    }


    public sealed class RichTextEditorSuggestion
    {

        private readonly Func<string, ValueTask<List<RichTextEditorSuggestionItem>>>? _itemsFunc;

        public string Trigger { get; }

        public RichTextEditorSuggestion(
            string trigger,
            Func<string, ValueTask<List<RichTextEditorSuggestionItem>>> function)
        {
            Trigger = trigger;
            _itemsFunc = function;
        }

        public async Task<List<RichTextEditorSuggestionItem>> InvokeAsync(string query)
        {

            if (_itemsFunc is not null) return await _itemsFunc.Invoke(query);

            return default!;
        }


    }
    public sealed class RichTextEditorSuggestionItem
    {
        public string? Value { get; set; }
        public string Label { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
