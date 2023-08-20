# ShowMessage
beautiful MessageBox for #WPF Applications
جعبه پیام یا مسیج باکس زیبا و سفارشی برای WPF
Using Material Design 4.9.0 && Net Framework 4.8

## Installation Guide
Use the following command to install:
```
Import Dlls Primary:(ShowMSG.dll) And Install Or Import Material Design Package

وارد کردن رفرنس های مربوطه، اصلی ترین رفرنس فایل ShowMSG.dll است و متریال دیزاین را میتوانید نصب کنید از nuget
```

#### Simple Example || مثال ساده
```C#
ShowMessage Msg = new ShowMessage();
Msg.Show("This is a sample message");
Msg.Show("This is a sample message", "Sample Caption", ShowMessage.ShowMsgButtons.OkCancel, ShowMessage.ShowMsgIcon.Success);
```
#### Advanced Example || مثال پیشرفته
```C#
 ShowMessage Dark = new ShowMessage
            {
                ShowMessageWithEffect = true,
                Background = "#333",
                TextColor = "#fff",
                IconColor = "#fff",
                CaptionFontSize = 16,
                MessageFontSize = 14,
                Direction = FlowDirection.RightToLeft,
                EffectOpacity = -1,
                EffectArea = this,
                ParentWindow = this,
            };
Dark.Show("Salam", "Sample Caption", ShowMessage.ShowMsgButtons.OkCancel, ShowMessage.ShowMsgIcon.Error);
```

## Properties
In the following table, you can see the AmRoMessageBox class properties:

| Property  | Type | Description | 
| ------------- | ------------- | ------------- |
| Background | string | Specifies the background color |
| TextColor | string | Specifies the text color |
| IconColor | string | Specifies the icon color |
| WindowEffectColor | string | Specifies the window effect color |
| EffectArea | object | Specifies display region of window effect |
| RippleEffectColor | string | Specifies the buttons Ripple effect color |
| ClickEffectColor | string | Specifies the buttons Click effect color |
| FontFamily | FontFamily | Specifies the MessageBox font |
| EffectOpacity | double | Specifies the transparency level of window effect |
| MessageFontSize | double | Specifies message content font size |
| CaptionFontSize | double | Specifies message caption font size |
| Direction | FlowDirection | Specifies the MessageBox direction |
| ButtonsText | MessageBoxButtonsText | Specifies the MessageBox buttons text |
| ParentWindow | Window | Specifies the owner window |
| ShowMessageWithEffect | bool | Specifies whether MessageBox has an window effect when displaying or not |

## Screenshots

![3](https://github.com/aliansari685/ShowMessage/assets/37542697/62975fcb-cdf1-43cf-abc4-e51a87662670)

![2](https://github.com/aliansari685/ShowMessage/assets/37542697/a415dfb8-45b6-4578-a11b-38e354063aeb)

![1](https://github.com/aliansari685/ShowMessage/assets/37542697/012e7724-d7b0-4c05-a715-a32723e160f6)


## References
<div>
    <ul dir="rtl">
        <li dir="rtl"><a href="https://www.linkedin.com/in/aliansari141/">ویرایگشر</a></li>
        <li dir="rtl"><a href="https://github.com/AmRo045/AmRoMessageBox/">سازنده</a></li>
    </ul>
</div>
