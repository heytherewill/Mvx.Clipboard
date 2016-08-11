using Clipboard;
using Clipboard.WindowsUWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Client.WindowsUWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IClipboardService service = new ClipboardService();
            service.CopyToClipboard("Hello, you're testing the Clipboard plugin for MvvmCross.");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            IClipboardService service = new ClipboardService();
            var text = service.ReadFromClipboard();
            var dialog = new MessageDialog("Text in clipboard : " + System.Environment.NewLine + text);
            dialog.ShowAsync();
        }
    }
}
