using ShowMsg;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace ShowMsg_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ShowMessage Light;
        private readonly ShowMessage Dark;

        public MainWindow()
        {
            InitializeComponent();
            Light = new ShowMessage();

            Dark = new ShowMessage
            {
                Background = "#333",
                TextColor = "#fff",
                RippleEffectColor = "#000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true,
                EffectArea = Content,
                ParentWindow = this,
                IconColor = "#3399ff",
                CaptionFontSize = 16,
                MessageFontSize = 14
            };
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void BtnNonStaticMessageBox1_OnClick(object sender, RoutedEventArgs e)
        {
            Light.Show("This is a sample message");
        }

        private void BtnNonStaticMessageBox2_OnClick(object sender, RoutedEventArgs e)
        {
            Light.Show("This is a sample message", "Sample Caption");
        }

        private void BtnNonStaticMessageBox3_OnClick(object sender, RoutedEventArgs e)
        {
            Dark.Show("This is a sample message", "Sample Caption", ShowMessage.ShowMsgButtons.YesNo);
        }

        private void BtnNonStaticMessageBox4_OnClick(object sender, RoutedEventArgs e)
        {
            Dark.Show("This is a sample message", "Sample Caption", ShowMessage.ShowMsgButtons.OkCancel, ShowMessage.ShowMsgIcon.Success);
        }
    }
}
