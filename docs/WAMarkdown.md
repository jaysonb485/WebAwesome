# WAMarkdown
## WebAwesomeBlazor.Components.WAMarkdown

```HTML+Razor
<WAMarkdown Markdown="@Content" />
```

### Description
The markdown component turns raw markdown into rendered HTML using the Marked library. Indentation is handled automatically. You can nest your markdown at any depth to match the surrounding HTML structure and the common leading whitespace will be stripped before parsing.

[WebAwesome docs](https://webawesome.com/docs/components/markdown)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Markdown | string |  | The markdown content to display when initially rendering the component. |
| TabSize | int | 4 | The tab stop width used when converting leading tabs to spaces during whitespace normalization. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetMarkdownAsync  | Markdown: string   | Updates the markdown content of the component. This method can be used to dynamically change the displayed markdown after the component has been rendered.      |


### Examples

#### Basic Usage
```HTML+Razor
<WAMarkdown Markdown="# Header \n\n Markdown content" />
```

#### Advanced Usage - Retrieve content from a file
```HTML+Razor
   <WAMarkdown @ref="Markdown">

   @code
   {
       WAMarkdown Markdown { get; set; } = default!;

       protected override async Task OnAfterRenderAsync(bool firstRender)
       {
           if (firstRender)
           {
               string content = File.ReadAllText("Example.md");
               await Markdown.SetMarkdownAsync(content);
           }
       }
   }
```