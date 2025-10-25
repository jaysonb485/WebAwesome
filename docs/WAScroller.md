# WAScroller
## Vengage.WebAwesome.Components.WAScroller

```HTML+Razor
<WAScroller>
    @ChildContent
</WAScroller>
```

### Description
Scrollers create an accessible container while providing visual cues that help users identify and navigate through content that scrolls.

[WebAwesome docs](https://webawesome.com/docs/components/scroller/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| ShowShadow | bool | true | Shows the shadows.  |
| ShowScrollbar | bool | true | Shows the visible scrollbar. |
| Orientation | ScrollerOrientation | ScrollerOrientation.Horizontal | The scroller's orientation. |

### Examples

#### Basic Usage
```HTML+Razor
    <div style="max-width:480px;border: 1px solid; padding: 1rem;">
        <WAScroller>
            <div style="width: 1000px;">
                <p>
                    Thank god I found you. Listen, can you meet me at Twin Pines Mall tonight at 1:15? I've made a major breakthrough, I'll need your assistance. Yeah, yeah what are you wearing, Dave. That's a great idea. I'd love to park. Ah. Well, Biff.
                </p>
                <p>
                    Doc, Doc. Oh, no. You're alive. Bullet proof vest, how did you know, I never got a chance to tell you. About all that talk about screwing up future events, the space time continuum. Please, Marty, don't tell me, no man should know too much about their own destiny. Yeah, who are you? Calvin. Doc, you gotta help-
                </p>
                <p>
                    Doc, you gotta help- I still don't understand, how am I supposed to go to the dance with her, if she's already going to the dance with you. Yeah, I'm- mayor. Now that's a good idea. I could run for mayor. Marty, such a nice name. Are those my clocks I hear?
                </p>
            </div>
        </WAScroller>
    </div>
```

#### Vertical, no scrollbar, no shadow
```HTML+Razor
    <div style="width:480px; border: 1px solid; padding: 1rem;">
        <WAScroller Orientation="ScrollerOrientation.Vertical" ShowScrollbar="false" ShowShadow="false" Style="max-height:240px;">
                <p>
                    Thank god I found you. Listen, can you meet me at Twin Pines Mall tonight at 1:15? I've made a major breakthrough, I'll need your assistance. Yeah, yeah what are you wearing, Dave. That's a great idea. I'd love to park. Ah. Well, Biff.
                </p>
                <p>
                    Doc, Doc. Oh, no. You're alive. Bullet proof vest, how did you know, I never got a chance to tell you. About all that talk about screwing up future events, the space time continuum. Please, Marty, don't tell me, no man should know too much about their own destiny. Yeah, who are you? Calvin. Doc, you gotta help-
                </p>
                <p>
                    Doc, you gotta help- I still don't understand, how am I supposed to go to the dance with her, if she's already going to the dance with you. Yeah, I'm- mayor. Now that's a good idea. I could run for mayor. Marty, such a nice name. Are those my clocks I hear?
                </p>
        </WAScroller>
    </div>
```

![WAScroller](https://github.com/user-attachments/assets/237cc2c0-abf9-4107-bd69-d5d6b9a82dfd)