# WAInclude
## WebAwesomeBlazor.Components.WAInclude

```HTML+Razor
<WAInclude SourceUrl="" />
```

### Description
Includes give you the power to embed external HTML files into the page

[Web Awesome docs](https://webawesome.com/docs/components/include/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| AllowScripts | bool | false | Allows included scripts to be executed. Be sure you trust the content you are including as it will be executed as code and can result in XSS |
| Mode | IncludeMode | IncludeMode.CORS | The fetch mode to use (CORS, NoCORS, SameOrigin). |
| SourceUrl | string |  | The location of the content to include. This can be a URL to an HTML file, a same-page reference to an element's id (e.g. #my-id), or a URL with a fragment that targets an element's id within the fetched file (e.g. /partials.html#my-id). When targeting an element by id, its content is cloned. If the target is a <template>, its child nodes are cloned. Be sure you trust the content you are including as it will be executed as code and can result in XSS attacks. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| Loaded   | Emitted when the included file is loaded. |
| LoadError (string) | Emitted when the included file fails to load due to an error. Provides HTTP error code or `-1` if error unknown. |

### Examples

#### Basic Usage
```HTML+Razor
<WAInclude SourceUrl="https://shoelace.style/assets/examples/include.html" />
```

#### Listen for events
```HTML+Razor
<WAInclude SourceUrl="https://shoelace.style/assets/examples/include.html" Loaded="includeLoaded" LoadError="includeError" />
@code {
	void includeLoaded() 
	{
		Console.WriteLine("Page loaded");
	}

	void includeError(string errorNumber)
	{
		Console.WriteLine($"Error loading page: {errorNumber}");
	}
}
```