# WACard
## Vengage.WebAwesome.Components.WACard

```HTML+Razor
<WACard>
    <CardHeader>
        @CardHeader
    </CardHeader>
    <CardMedia>
        @CardMedia
    </CardMedia>
    <CardBody>
        @CardBody
    </CardBody>
    <CardFooter>
        @CardFooter
    </CardFooter>
</WACard>
```

### Description
Cards can be used to group related subjects in a container.

[WebAwesome docs](https://webawesome.com/docs/components/card/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| CardFooter    | RenderFragment | | An optional footer for the card.                     |
| CardMedia    | RenderFragment |        | An optional media section to render at the start of the card.                    |
| CardHeader    | RenderFragment |    | An optional header for the card.                     |
| CardBody | RenderFragment | | The card's main content |
| HorizontalActions | RenderFragment | | An optional actions section to render at the end for the horizontal card. |
| HeaderActions | RenderFragment | | An optional actions section to render in the header of the vertical card. |
| FooterActions | RenderFragment | | An optional actions section to render in the footer of the vertical card. |
| FooterCSSClass | string | | CSS class to apply to the footer section of the card. |
| HeaderCSSClass | string | | CSS class to apply to the header section of the card. |
| Appearance | CardAppearance | CardAppearance.Outlined | The card's visual appearance. |
| ImageSource | string | | An optional image to render at the start of the card. |
| ImageAltText | string | | Alt text for the optional image. |
| Orientation | CardOrientation | CardOrientation.Vertical | Renders the card's orientation. |

#### Basic Usage
```HTML+Razor
<WACard>
    <CardBody>
        This is just a basic card without any header, footer, or media.
     </CardBody>
</WACard>
```

#### Header, footer, and media in vertical orientation
```HTML+Razor
    <WACard>
        <CardHeader>Header content</CardHeader>
        <CardMedia>
            <img src="https://picsum.photos/480" alt="Card media" />
        </CardMedia>
        <CardBody>
            <strong>Everything</strong> is here in this vertical card.
        </CardBody>
        <CardFooter>
            <small>Today 3 minutes ago.</small>
        </CardFooter>
        <HeaderActions>
            <WAButton StartIconName="gear" Caret="true" />
        </HeaderActions>
        <FooterActions>
            <WAButton StartIconName="thumbs-up" />
        </FooterActions>
    </WACard>
```

#### Horizontal card
````HTML+Razor
    <WACard Orientation="CardOrientation.Horizontal">
        <CardBody>Horizontal card</CardBody>
        <CardMedia>
            <img src="https://picsum.photos/150" alt="Card media" />
        </CardMedia>
        <HorizontalActions>
            <WAButton Caret="true" />
        </HorizontalActions>
    </WACard>
````
<img width="513" height="1061" alt="image" src="https://github.com/user-attachments/assets/29ab3a9d-4d77-4079-abc3-7b5a6cba08b9" />
