# WARating
## Vengage.WebAwesome.Components.WARating

```HTML+Razor
<WARating Value="" />
```

### Description
Ratings give users a way to quickly view and provide feedback.

[WebAwesome docs](https://webawesome.com/docs/components/rating/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | int | 0 | The current rating. |
| Label | string |  | A label that describes the rating to assistive devices. |
| MaximumRating | int | 5 | The highest rating to show. |
| RatingPrecision | decimal | 1 | The precision at which the rating will increase and decrease. For example, to allow half-star ratings, set this attribute to 0.5. |
| ReadOnly | bool | false | Makes the rating readonly. |
| Disabled | bool | false | Disables the rating. |
| Size | RatingSize | RatingSize.Inherit | The component's size. |

### Examples

#### Basic Usage
```HTML+Razor
<WARating @bind-Value="firstRating" />
```

#### Maximum rating and half step precision
```HTML+Razor
<WARating @bind-Value="secondRating" MaximumRating="10" RatingPrecision="(decimal)0.5" />
```

![WARating](https://github.com/user-attachments/assets/5b757d4a-d923-402a-977d-6281deca6904)