# WAFileInput
## WebAwesomeBlazor.Components.WAFileInput

```HTML+Razor
<WAFileInput />
```

### Description
File inputs allow users to select files from their device.

File inputs allow users to select one or more files from their device using a dropzone that supports both click and drag-and-drop interactions.

[WebAwesome docs](https://webawesome.com/docs/components/file-input)

> [!IMPORTANT]
> WAFileInput requires access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| FilesChanged | EventCallback |  | Called when the file input's value changes. |
| Size | FileInputSize | FileInputSize.Inherit | The file input's size. |
| Label | string |  | The file input's label |
| Hint | string |  | The file input's hint text. |
| Disabled | bool | false | Maked the input disabled. |
| Required | bool | false | Makes the input a required field. |
| Accept | string |  | A comma-separated list of acceptable file types. Must be a list of [unique file type specifiers](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/input/file#unique_file_type_specifiers). |
| AllowMultiple | bool | false | Allows more than one file to be selected. |
| DropZone | RenderFragment |  | Custom content to display in the drop zone. If not provided, a default drop zone will be rendered. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetFocus |  | Sets focus to the file input element. |
| SetFocusAsync |  | Sets focus to the file input element. |
| GetFilesAsync | | Get a list of files selected in the file input. Each file is represented as a JsFileInfo object, which contains metadata about the file and a method to open a read stream for the file's contents. |

### JsFileInfo
| Property | Type   | Description                              |
|----------|--------|------------------------------------------|
| Name | string | The name of the file. |
| Size | long | The size of the file in bytes. |
| Type | string | The MIME type of the file. |
| LastModified | DateTime | The date and time the file was last modified. |

| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| OpenReadStreamAsync | chunkSize: int  | Returns a stream which can be used by a StreamReader to read the file contents. Default chunkSize is `64 * 1024`. When reading the stream, you must use an Asynchornous read method e.g. `StreamReader.ReadToEndAsync`  |

### Examples

#### Basic Usage
```HTML+Razor
<WAFileInput 
	Label="Upload file" 
	Hint="Only .txt files allowed" 
	Accept=".txt" 
	@ref="TextFileInput" 
	FilesChanged="FilesChanged" 
	AllowMultiple="true" />

	@code {
		private WAFileInput TextFileInput;
		private async Task FilesChanged()
		{
			var files = await TextFileInput.GetFilesAsync();
			foreach (var file in files)
			{
				Console.WriteLine($"File name: {file.Name}, size: {file.Size}, type: {file.Type}");
				using var stream = await file.OpenReadStreamAsync();
				using var reader = new StreamReader(stream);
				var contents = await reader.ReadToEndAsync();
				Console.WriteLine($"Contents: {contents}");
			}
		}
	}
```

![WAFileInput](https://github.com/user-attachments/assets/eadfaafe-3204-4916-ac41-511176a53d87)