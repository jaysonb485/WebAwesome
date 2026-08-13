# WAOTPInput
## WebAwesomeBlazor.Components.WAOTPInput

```HTML+Razor
<WAOTPInput @bind-Value="" />
```

### Description
OTP inputs collect one-time passcodes, PINs, and other fixed-length codes, one character per segment. Use them for SMS verification, two-factor authentication, and invite codes.

[WebAwesome docs](https://webawesome.com/docs/components/otp-input/)

### Properties
| Property | Type   | Default | Description                              |
|----------|--------|---------|------------------------------------------|
| Value | string |  | The current value of the input |
| ValueChanged | EventCallback<string> |  | Triggered when the input's value has changed |
| AllowedCharacters | OtpAllowedCharacters | OtpAllowedCharacters.Numeric | The allowed characters for the input. Numeric, Alpha, or Alphanumeric |
| Appearance | OtpAppearance | --mask-char.Outlined | The input's visual appearance. |
| Autofocus | bool | false | Automatically focuses the input when it is rendered. |
| Autocomplete | string |  | Specifies what permission the browser has to provide assistance in filling out form field values. Refer to [this page on MDN](https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete) for available values.. |
| AutoSubmit | bool | false | Automatically submits the form when the input is filled. |
| CaseTransform | OtpCaseTransform | OtpCaseTransform.Preserve | The input's case transformation. Preserve, Upper, or Lower |
| Disabled | bool | false | Maked the input disabled. |
| SegmentFormat | string |  | Segment format string using # as a segment placeholder and any other character as a literal separator. Setting format overrides length (the segment count is derived from the number of # characters). |
| Hint | string |  | The input's hint text. |
| Label | string |  | The input's label |
| Length | int | 6 | Number of character segments to display. Overridden by SegmentFormat when set. |
| OTPCompleted | EventCallback<string> |  | Triggered when the input is completed (all segments filled). The value is the concatenated string of all segments. |
| Mask | bool | false | When true, entered characters are displayed as `MaskCharacter` instead of their real value. |
| MaskCharacter | char | • | Character shown in place of entered values when `Mask` is set, and as a hint in empty segments when `ShowEmptyMask` is set. |
| ReadOnly | bool | false | Makes the input readonly. |
| Required | bool | false | Makes the input a required field. |
| Size | OtpSize | OtpSize.Medium | The input's size. |
| ShowEmptyMask | bool | false | When true, empty segments show MaskCharacter as a hint instead of appearing blank, similar to how a password field communicates its expected length before anything is typed. |

### Methods
| Method      | Parameters       | Description                              |
|-------------|------------------|------------------------------------------|
| SetValue  | value: string   | Sets the value of the input |
| SetValueAsync  | value: string   | Sets the value of the input |
| SetFocus |  | Sets focus to the input element. |
| SetFocusAsync |  | Sets focus to the input element. |


### Examples

#### Basic Usage
```HTML+Razor
<WAOTPInput
	@bind-Value="otpModel.OTPCode" 
	OTPCompleted="OTPCompleted"></WAOTPInput>

	@code 
	{
		private void OTPCompleted(string otpCode)
		{
			Console.WriteLine($"OTP Code entered: {otpCode}");
			// Process next steps, such as verifying the OTP code
		}
	}
```