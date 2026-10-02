# WAFileInput
## WebAwesomeBlazor.Components.WAFileInput

```HTML+Razor
<WAFileInput />
```

### Description
File inputs allow users to select files from their device.

File inputs allow users to select one or more files from their device using a dropzone that supports both click and drag-and-drop interactions.

[Web Awesome docs](https://webawesome.com/docs/components/file-input)

> [!IMPORTANT]
> WAFileInput requires access to WebAwesome Pro.

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Accept | string |  | A comma-separated list of acceptable file types. Must be a list of [unique file type specifiers](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/input/file#unique_file_type_specifiers). |
| AllowMultiple | bool | false | Allows more than one file to be selected. |
| Capture | FileInputCapture |  | On mobile devices, specifies which camera or microphone to use for capturing media. Use user for the front-facing camera/microphone or environment for the rear-facing one. This attribute is only used when accept includes an image, video, or audio type and may be ignored on devices that lack the corresponding hardware. |
| Disabled | bool | false | Maked the input disabled. |
| DropZone | RenderFragment |  | Custom content to display in the drop zone. If not provided, a default drop zone will be rendered. |
| Hint | string |  | The file input's hint text. |
| Label | string |  | The file input's label |
| Required | bool | false | Makes the input a required field. |
| Size | FileInputSize | FileInputSize.Inherit | The file input's size. |

### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| FilesChanged | Called when the file input's value changes. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| GetFilesAsync | | Get a list of files selected in the file input. Each file is represented as a JsFileInfo object, which contains metadata about the file and a method to open a read stream for the file's contents. |
| OpenReadStreamAsync | file: jsFileInfo, chunkSize: int  | Returns a stream which can be used by a StreamReader to read the file contents. Provide the file from `GetFilesAsync()` Default chunkSize is `64 * 1024`. When reading the stream, you must use an Asynchornous read method e.g. `StreamReader.ReadToEndAsync`  |
| SetFocusAsync |  | Sets focus to the file input element. |

### JsFileInfo
| Property | Type   | Description                              |
|----------|--------|------------------------------------------|
| LastModified | DateTime | The date and time the file was last modified. |
| Name | string | The name of the file. |
| Size | long | The size of the file in bytes. |
| Type | string | The MIME type of the file. |


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
				using var stream = await TextFileInput.OpenReadStreamAsync(file);
				using var reader = new StreamReader(stream);
				var contents = await reader.ReadToEndAsync();
				Console.WriteLine($"Contents: {contents}");
			}
		}
	}
```

![WAFileInput](https://github.com/user-attachments/assets/eadfaafe-3204-4916-ac41-511176a53d87)