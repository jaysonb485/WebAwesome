# WATabGroup
## WebAwesomeBlazor.Components.WATabGroup

```HTML+Razor
<WATabGroup>
	<WATabPanel>
	
	</WATabPanel>
<WATabGroup>
```

### Description
Tab groups organize content into a container that shows one section at a time. See [WATabPanel](/docs/WATabPanel).

[WebAwesome docs](https://webawesome.com/docs/components/tab-group/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| ShowScrollControls | bool | true | Enables the scroll arrows that appear when tabs overflow. Defaults to true. |
| ActiveTab | string |  | Sets the active tab. Set to the `name` of the tab to make active. |
| TabPlacement | TabGroupTabPlacement | TabGroupTabPlacement.Top |  |


### Events
| Event Name  | Description                              |
|-------------|------------------------------------------|
| ActiveTabChanged   | Triggered when the active tab has changed. Provides tab name of the new tab. |


### Examples

#### Basic Usage, ActiveTab set.
```HTML+Razor
<WATabGroup ActiveTab="tab2">
    <WATabPanel Name="tab1" Label="Tab One">
        First tab
    </WATabPanel>
    <WATabPanel Name="tab2" Label="Tab two">
        Second tab
    </WATabPanel>
</WATabGroup>
```

![WATabGroup](https://github.com/user-attachments/assets/7709ba8e-6032-4f4c-8f81-8e5c819d7720)