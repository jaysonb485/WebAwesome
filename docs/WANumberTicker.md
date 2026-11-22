# WANumberTicker
## WebAwesomeBlazor.Components.WANumberTicker

```HTML+Razor
<WANumberTicker Value="10000" />
```

### Description
Number tickers count up or down to a value when they scroll into view and format it with the Intl.NumberFormat API. Use them for dashboard stats, landing page metrics, and running totals.

[Web Awesome docs](https://webawesome.com/docs/components/number-ticker)

### Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `CurrencyCode` | `string` | `"USD"` | The ISO 4217 currency code used when formatting currency values. |
| `CurrencyDisplay` | `NumberTickerCurrencyDisplay` | `Symbol` | Determines how currency values are displayed, such as by symbol, code, or name. |
| `Delay` | `int` | `0` | The number of milliseconds to wait before the initial counting animation begins. Subsequent value changes are not delayed. |
| `Duration` | `int` | `2000` | The maximum duration, in milliseconds, of the counting animation. Set to `0` to disable animation and display the target value immediately. |
| `Eager` | `bool` | `false` | Starts counting immediately instead of waiting for the ticker to scroll into view. |
| `Easing` | `string` | `"cubic-bezier(0.16, 1, 0.3, 1)"` | The CSS easing function used by the counting animation. Invalid values fall back to the default easing function. |
| `MaximumFractionDigits` | `int?` | `null` | The maximum number of fractional digits to display. Valid values range from `0` to `100`. |
| `MinimumFractionDigits` | `int?` | `null` | The minimum number of fractional digits to display. Valid values range from `0` to `100`. |
| `MaximumSignificantDigits` | `int?` | `null` | The maximum number of significant digits to display. Valid values range from `1` to `21`. |
| `MinimumSignificantDigits` | `int?` | `null` | The minimum number of significant digits to display. Valid values range from `1` to `21`. |
| `StartValue` | `decimal` | `0` | The value from which counting begins on the initial run and whenever the ticker is restarted. |
| `FormatType` | `NumberTickerFormatType` | `Decimal` | Specifies the formatting style used when displaying the value, such as decimal, currency, or percentage. |
| `Value` | `decimal` | `0` | The target value to count towards. Once started, changes animate from the currently displayed value to the new value. |
| `GroupDigits` | `bool` | `true` | Displays digit grouping separators according to the current locale, such as thousands separators. |
| `Finished` | `EventCallback` | - | Invoked when the counting animation completes and the target value has been reached. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| Restart Async |  | Restarts the ticker from the StartValue |

### Examples

#### Basic Usage
```HTML+Razor
<WANumberTicker Value="10000" />
```

#### Currency formatting
```HTML+Razor
<WANumberTicker Value="1209.50" CurencyCode="AUD" CurrencyDisplay="NumberTickerCurrencyDisplay.Symbol" FormatType="NumberTickerFormatType.Currency" />
```

#### ValueFormatter
A custom formatting function to apply to the number. When set, the formatting properties are ignored. Must be set with JavaScript.

```HTML+Razor
<WANumberTicker Id="numberTicker" Value="10000" />
<script type="module">
    const ticker = document.getElementById('numberTicker');
    const formatter = new Intl.NumberFormat('en', { notation: 'compact', maximumFractionDigits: 2 });
    
    await customElements.whenDefined('wa-number-ticker');
   
    ticker.valueFormatter = value => formatter.format(value);
        
</script>
```