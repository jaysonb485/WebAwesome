

Currently supports WebAwesome 3.0.0-beta 6.

# Installation
Add as a project dependency, or build from source.

Nuget coming soon.

# Usage
Add the following to your `_Imports.razor` file:
```csharp
@using WebAwesome.Blazor
```

Add the following to your App.razor file:
```csharp
    <link rel="stylesheet" href="https://early.webawesome.com/webawesome@3.0.0-beta.6/dist/styles/webawesome.css" />
    <script type="module" src="https://early.webawesome.com/webawesome@3.0.0-beta.6/dist/webawesome.loader.js"></script>
    <link rel="stylesheet" href="@Assets["/_content/Vengage.WebAwesome/WebAwesome.css"]" />
    <script type="text/javascript" src="@Assets["/_content/Vengage.WebAwesome/JsInterop.js"]"></script>
```

Then you can use the components in your Blazor pages, for example:
```csharp
<WAButton OnClick="ButtonClicked" Appearance="ButtonAppearance.Outlined" Variant="ButtonVariant.Brand">Change value</WAButton>
```


Demo project coming soon.

# Credits
This project contains inspiration of elements from:
* Vikram - [Blazor Bootstrap Component Library](https://github.com/vikramlearning/blazorbootstrap)
