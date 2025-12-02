# DarkModeToggle
## WebAwesomeBlazor.Extended.DarkModeToggle

```HTML+Razor
<DarkModeToggle />
```

### Description
A simple helper component to toggle between light and dark mode themes.


### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetDarkMode  | DarkMode: bool   | Sets the theme to dark mode if true, light mode if false. |
| SetDarkModeAsync  | DarkMode: bool   | Sets the theme to dark mode if true, light mode if false. |

### Examples

#### Basic Usage
```HTML+Razor
<DarkModeToggle @ref="DarkModeToggle" />

@code {
	private DarkModeToggle DarkModeToggle;
	private void EnableDarkMode()
	{
		DarkModeToggle.SetDarkMode(true);
	}
	private void EnableLightMode()
	{
		DarkModeToggle.SetDarkMode(false);
	}
}
```