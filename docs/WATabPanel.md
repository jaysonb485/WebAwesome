# WATabPanel
## WebAwesomeBlazor.Components.WATabPanel

```HTML+Razor
<WATabGroup>
	<WATabPanel Name="" Label="">
	
	</WATabPanel>
<WATabGroup>
```

### Description
Tab panels are used inside [WATabGroup](/docs/WATabGroup) to display tabbed content. This implementation combines `<wa-tab>` and `<wa-tab-panel>` components.

[WebAwesome docs - Tab Panel](https://webawesome.com/docs/components/tab-panel/)
[WebAwesome docs - Tab](https://webawesome.com/docs/components/tab/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| PanelContent | RenderFragment |  | The content of the panel |
| TabContent | RenderFragment |  | The content of the tab. Use this property for full control of the tab display. Otherwise, use `Label` for basic text tab. |
| Label | string |  | Label to display on the tab. Use this to display simple text label. Otherwise, use `TabContent` |
| Name | string |  | Required. The name of the tab panel. |
| Disabled | bool | false |  Disables the tab and prevents selection. |


### Examples

#### Basic Usage
```HTML+Razor
<WATabGroup>
    <WATabPanel Name="tab1" Label="Tab One">
        First tab
    </WATabPanel>
    <WATabPanel Name="tab2" Label="Tab two">
        Second tab
    </WATabPanel>
</WATabGroup>
```

#### Custom tab content
```HTML+Razor
<WATabGroup>
    <WATabPanel Name="tab1">
        <TabContent>
            <div class="wa-stack" style="align-items: center;">
                <WAIcon IconName="user" Label="User" />
                <span>User</span>
            </div>
        </TabContent>
        <PanelContent>
            User content
        </PanelContent>
    </WATabPanel>
    <WATabPanel Name="tab2" >
        <TabContent>
            <div class="wa-stack" style="align-items: center;">
                <WAIcon IconName="house-user" Label="Address" />
                <span>Addresses</span>
            </div>
        </TabContent>
        <PanelContent>
            User address list
        </PanelContent>
    </WATabPanel>
</WATabGroup>
```

![WATabPanel](https://github.com/user-attachments/assets/8dbfb19d-1ba5-4d46-8715-f74953480bae)