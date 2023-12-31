﻿using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static ShowMsg.ShowMessage;

namespace ShowMsg
{
    /// <inheritdoc cref="WinMessageBox" />
    /// <summary>
    /// Interaction logic for WinMessageBox.xaml
    /// </summary>
    public partial class WinMessageBox
    {
        public WinMessageBox()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public WinMessageBox(Window owner) : this()
        {
            if (owner == null) return;
            Owner = owner;
            ParentWindow = owner;
        }

        private void WinMessageBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            Opacity = 0;
            SetMessageBoxContent();
            PrepareMessageBoxButtons();
            PrepareMessageBoxIcon();
            SetMessageBoxDirection();
            SetMessageContentDirection();
            SettingUpWindowAppearance();
            PrepareMessageWindow();
            Opacity = 1;

        }

        #region Properties

        #region Message Box Appearance

        public ShowMsgWindowEffect WindowEffect { get; set; }
        public SolidColorBrush WindowBackground { private get; set; }
        public SolidColorBrush TextColor { private get; set; }
        public SolidColorBrush IconColor { private get; set; }
        public SolidColorBrush RippleEffectColor { private get; set; }
        public SolidColorBrush ClickEffectColor { private get; set; }
        public new FontFamily FontFamily { private get; set; }
        public double MessageFontSize { private get; set; }
        public double CaptionFontSize { private get; set; }
        #endregion
        public ShowMsgResult ShowMsgResult { get; private set; }
        public ShowMsgButtons ShowMsgButton { private get; set; }
        public ShowMsgIcon ShowMsgIcon { private get; set; }
        public FlowDirection ShowMsgDirection { private get; set; }
        public ShowMsgButtonsText ShowMsgButtonsText { private get; set; }
        public string Message { get; set; }
        public string Caption { get; set; }
        public bool ReverseContentDirection { get; set; }
        public Window ParentWindow { get; set; }
        public bool ShowMessageWithEffect { get; set; }

        #endregion

        #region UI Elements

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            ShowMsgResult = ShowMsgResult.Ok;
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ShowMsgResult = ShowMsgResult.Cancel;
            Close();
        }

        private void BtnYes_OnClick(object sender, RoutedEventArgs e)
        {
            ShowMsgResult = ShowMsgResult.Yes;
            Close();
        }

        private void BtnNo_OnClick(object sender, RoutedEventArgs e)
        {
            ShowMsgResult = ShowMsgResult.No;
            Close();
        }

        private void RectWindowEffect_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (ShowMsgButton)
            {
                case ShowMsgButtons.OkCancel:
                case ShowMsgButtons.YesNoCancel:
                    ShowMsgResult = ShowMsgResult.Cancel;
                    break;
                case ShowMsgButtons.YesNo:
                    ShowMsgResult = ShowMsgResult.No;
                    break;
                case ShowMsgButtons.Ok:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Close();
        }

        #endregion

        #region My Methods

        private void SettingUpWindowAppearance()
        {
            Resources["BaseBackground"] = WindowBackground ?? WindowBackground;
            Resources["BaseIconColor"] = IconColor ?? IconColor;
            Resources["MaterialDesignFlatButtonRipple"] = RippleEffectColor ?? RippleEffectColor;
            Resources["MaterialDesignFlatButtonClick"] = ClickEffectColor ?? ClickEffectColor;
            Resources["BaseFontFamily"] = FontFamily ?? FontFamily;
            Resources["BaseCaptionFontSize"] = Math.Abs(CaptionFontSize) <= 0 ? 15 : CaptionFontSize;
            Resources["BaseMessageFontSize"] = Math.Abs(MessageFontSize) <= 0 ? 12 : MessageFontSize;

            if (WindowEffect != null)
            {
                Resources["BaseEffectColor"] = WindowEffect.Color ?? WindowEffect.Color;
                Resources["BaseEffectOpacity"] = Math.Abs(WindowEffect.Opacity) <= 0 ? 0.5 : WindowEffect.Opacity;
            }

            if (TextColor != null)
                Resources["BaseForeground"] = TextColor.Color;
        }

        private void PrepareMessageWindow()
        {
            if (ParentWindow == null
                || !ShowMessageWithEffect
                || ParentWindow.ActualWidth <= CardMain.ActualWidth + 200
                || ParentWindow.ActualHeight <= CardMain.ActualHeight + 200)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                return;
            }

            if (!(WindowEffect.EffectArea is FrameworkElement effectArea)) return;

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            DpWindowEffect.Visibility = Visibility.Visible;

            if (ParentWindow.WindowState == WindowState.Maximized)
            {
                Top = 0;
                Left = 0;
                Width = SystemParameters.WorkArea.Width;
                Height = SystemParameters.WorkArea.Height;
            }
            else
            {
                Top = ParentWindow.Top;
                Left = ParentWindow.Left;
                Width = ParentWindow.ActualWidth;
                Height = ParentWindow.ActualHeight;
            }

            if (effectArea is Window && ParentWindow.WindowState != WindowState.Maximized)
            {
                DpWindowEffect.Width = ParentWindow.ActualWidth;
                DpWindowEffect.Height = ParentWindow.ActualHeight;
                DpWindowEffect.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                DpWindowEffect.Width = effectArea.ActualWidth;
                DpWindowEffect.Height = effectArea.ActualHeight;
            }
        }

        private void SetMessageBoxContent()
        {
            if (string.IsNullOrEmpty(Caption))
            {
                RowCaption.Height = new GridLength(0);
                RowMessage.Height = new GridLength(3, GridUnitType.Star);
                TxtMessage.FontSize = LblCaption.FontSize;
                DpWindowEffect.MinHeight = 120;
                CardMain.MinHeight = 120;
            }
            else
            {
                DpWindowEffect.MinHeight = 140;
                CardMain.MinHeight = 140;
            }
            LblCaption.Content = Caption;
            TxtMessage.Text = Message;
        }

        private void SetMessageBoxDirection()
        {
            CardMain.FlowDirection = ShowMsgDirection;
        }

        private void SetMessageContentDirection()
        {

            if (ShowMsgDirection == FlowDirection.LeftToRight)
            {
                SpMessage.HorizontalAlignment = HorizontalAlignment.Left;
                SpMessage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                SpMessage.HorizontalAlignment = HorizontalAlignment.Left;
                SpMessage.FlowDirection = FlowDirection.RightToLeft;
            }

            if (!ReverseContentDirection) return;

            SpMessage.HorizontalAlignment = SpMessage.HorizontalAlignment == HorizontalAlignment.Left ?
                HorizontalAlignment.Right : HorizontalAlignment.Left;

            SpMessage.FlowDirection = SpMessage.FlowDirection == FlowDirection.RightToLeft ?
                FlowDirection.LeftToRight : FlowDirection.RightToLeft;
        }

        private void PrepareMessageBoxIcon()
        {
            switch (ShowMsgIcon)
            {
                case ShowMsgIcon.None:
                    MessageBoxIcon.Visibility = Visibility.Collapsed;
                    break;
                case ShowMsgIcon.Warning:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.Alert;
                    break;
                case ShowMsgIcon.Error:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.CloseCircle;
                    break;
                case ShowMsgIcon.Success:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.CheckCircle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PrepareMessageBoxButtons()
        {
            switch (ShowMsgButton)
            {
                case ShowMsgButtons.Ok:
                    BtnOk.Visibility = Visibility.Visible;
                    break;
                case ShowMsgButtons.YesNo:
                    BtnYes.Visibility = Visibility.Visible;
                    BtnNo.Visibility = Visibility.Visible;
                    break;
                case ShowMsgButtons.OkCancel:
                    BtnOk.Visibility = Visibility.Visible;
                    BtnCancel.Visibility = Visibility.Visible;
                    break;
                case ShowMsgButtons.YesNoCancel:
                    BtnYes.Visibility = Visibility.Visible;
                    BtnNo.Visibility = Visibility.Visible;
                    BtnCancel.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SetButtonsText();
        }

        private void SetButtonsText()
        {
            if (ShowMsgButtonsText == null) return;
            BtnOk.Content = ShowMsgButtonsText.Ok ?? "Ok";
            BtnCancel.Content = ShowMsgButtonsText.Cancel ?? "Cancel";
            BtnYes.Content = ShowMsgButtonsText.Yes ?? "Yes";
            BtnNo.Content = ShowMsgButtonsText.No ?? "No";
        }

        #endregion

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

    }
}
//Edit By : linkedin.com/in/aliansari141