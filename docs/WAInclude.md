# WAInclude
## WebAwesomeBlazor.Components.WAInclude

```HTML+Razor
<WAInclude SourceUrl="" />
```

### Description
Includes give you the power to embed external HTML files into the page

[WebAwesome docs](https://webawesome.com/docs/components/include/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| SourceUrl | string |  | The location of the HTML file to include. Be sure you trust the content you are including as it will be executed as code and can result in XSS |
| Mode | IncludeMode | IncludeMode.CORS | The fetch mode to use (CORS, NoCORS, SameOrigin). |
| AllowScripts | bool | false | Allows included scripts to be executed. Be sure you trust the content you are including as it will be executed as code and can result in XSS |


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| methodName  | param1: string   | Description of what methodName does      |
| anotherMethod | param1: number, param2: boolean | Description of what anotherMethod does |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| Loaded   | Emitted when the included file is loaded. |
| LoadError| Emitted when the included file fails to load due to an error. Provides HTTP error code or `-1` if error unknown. |

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

	void includeError(int errorNumber)
	{
		Console.WriteLine($"Error loading page: {errorNumber}");
	}
}
```