# WAAvatar
## WebAwesomeBlazor.Components.WAAvatar

```HTML+Razor
<WAAvatar />
```

### Description
Avatars are used to represent a person or object.

[WebAwesome docs](https://webawesome.com/docs/avatar)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Icon    | [Icon](/docs/IconClass) |  | The default icon to use when no image or initials are present. Alternatively, use the IconName parameter to specify an icon by name.                     |
| IconName    | string |        | The name of the default icon to use when no image or initials are present. Available names depend on the icon library being used.                     |
| ImageSource    | string |    | The image source URL to use for the avatar.                     |
| LazyLoading | bool | false | Indicates how the browser should load the image. |
| Name    | string |        | Set the name to use as initials if an image is not provided. <br/> The initials will use first letter of first name and last name (if provided). <br /> he name also provides a label to use to describe the avatar to assistive devices.                  |
| Shape	| AvatarShape | AvatarShape.Circle | The shape of the avatar (Circle, Square, Rounded)                  |

### Examples

#### Basic Usage
```HTML+Razor
<WAAvatar Name="Joanna Smith" Shape="AvatarShape.Square" />
```

#### Using an icon definition
```HTML+Razor
<WAAvatar Name="Joanna Smith" Icon="@(new(){ Name = "github", Family = "brands" })" />
```

#### Using an image source
```HTML+Razor
<WAAvatar Name="Joanna Smith" ImageSource="https://randomuser.me/api/portraits/lego/1.jpg" />
```
<img width="235" height="80" alt="image" src="https://github.com/user-attachments/assets/3b6fb103-0347-4071-8727-445d18a3d098" />
