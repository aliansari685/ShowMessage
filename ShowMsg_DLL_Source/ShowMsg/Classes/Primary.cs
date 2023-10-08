using System.Windows;
using System.Windows.Media;

namespace ShowMsg
{
    public class ShowMessage
    {
        #region Properties   
        public enum ShowMsgButtons
        {
            Ok, YesNo, OkCancel, YesNoCancel
        }
        public enum ShowMsgIcon
        {
            None, Warning, Error, Success
        }
        public enum ShowMsgResult
        {
            Cancel, Ok, Yes, No
        }
        public class ShowMsgButtonsText
        {
            public string Ok { get; set; }
            public string Cancel { get; set; }
            public string Yes { get; set; }
            public string No { get; set; }
        }
        public class ShowMsgWindowEffect
        {
            public SolidColorBrush Color { get; set; }
            public object EffectArea { get; set; }
            public double Opacity { get; set; }
        }
        public string Background { internal get; set; }
        public string TextColor { internal get; set; }
        public string IconColor { internal get; set; }
        public string WindowEffectColor { internal get; set; }
        public object EffectArea { internal get; set; }
        public string RippleEffectColor { internal get; set; }
        public string ClickEffectColor { internal get; set; }
        public FontFamily FontFamily { internal get; set; }
        public double EffectOpacity { internal get; set; }
        public double MessageFontSize { internal get; set; }
        public double CaptionFontSize { internal get; set; }
        public FlowDirection Direction { internal get; set; }
        public ShowMsgButtonsText ButtonsText { internal get; set; }
        public Window ParentWindow { internal get; set; }
        public bool ShowMessageWithEffect { internal get; set; }
        internal string Caption { get; set; }
        internal string Message { get; set; }
        internal ShowMsgButtons MessageBoxButton { get; set; }
        internal ShowMsgIcon MessageBoxIcon { get; set; }
        internal bool ReverseContentDirection { get; set; }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Display message box dialog
        /// </summary>
        /// <returns>Result</returns>
        private ShowMsgResult DisplayMessageDialog()
        {
            var messageWindow = new WinMessageBox(ParentWindow)
            {
                WindowBackground = GetSolidBrush(Background),
                TextColor = GetSolidBrush(TextColor),
                IconColor = GetSolidBrush(IconColor),
                RippleEffectColor = GetSolidBrush(RippleEffectColor),
                ClickEffectColor = GetSolidBrush(ClickEffectColor),
                MessageFontSize = MessageFontSize,
                CaptionFontSize = CaptionFontSize,
                FontFamily = FontFamily,
                Message = Message,
                Caption = Caption,
                ShowMsgButton = MessageBoxButton,
                ShowMsgIcon = MessageBoxIcon,
                ReverseContentDirection = ReverseContentDirection,
                ShowMsgDirection = Direction,
                ShowMsgButtonsText = ButtonsText,
                ParentWindow = ParentWindow,
                ShowMessageWithEffect = ShowMessageWithEffect,
                WindowEffect = new ShowMsgWindowEffect
                {
                    Color = GetSolidBrush(WindowEffectColor),
                    EffectArea = EffectArea,
                    Opacity = EffectOpacity
                }
            };

            if (ParentWindow != null)
            {
                ParentWindow.Focus();
                ParentWindow.Activate();
            }

            messageWindow.ShowDialog();
            ResetOptions();

            return messageWindow.ShowMsgResult;
        }

        /// <summary>
        /// Reset message box options
        /// </summary>
        private void ResetOptions()
        {
            MessageBoxButton = default;
            MessageBoxIcon = default;
            ReverseContentDirection = default;
        }

        /// <summary>
        /// Convert hexadecimal color to SolidColorBrush
        /// </summary>
        /// <param name="hexColor">Hexadecimal color</param>
        /// <returns>SolidColorBrush</returns>
        private static SolidColorBrush GetSolidBrush(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor))
                return null;
            try
            {
                return (SolidColorBrush)new BrushConverter().ConvertFrom(hexColor);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Non-Static Message Box Methods

        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>ShowMsgResult</returns>
        public ShowMsgResult Show(string message, bool reverseContentDirection = false)
        {
            Message = message;
            Caption = null;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>ShowMsgResult</returns>
        public ShowMsgResult Show(string message, string caption,
            bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption and custom buttons
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>ShowMsgResult</returns>
        public ShowMsgResult Show(string message, string caption,
            ShowMsgButtons messageBoxButton, bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            MessageBoxButton = messageBoxButton;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption, custom buttons, custom icon in RTL languages
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="messageBoxIcon">Message box icon</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>ShowMsgResult</returns>
        public ShowMsgResult Show(string message, string caption,
            ShowMsgButtons messageBoxButton, ShowMsgIcon messageBoxIcon,
            bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            MessageBoxButton = messageBoxButton;
            MessageBoxIcon = messageBoxIcon;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }
        #endregion
        #endregion
    }
}
