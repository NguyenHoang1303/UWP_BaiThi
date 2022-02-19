using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BaiThi.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppUniversal : Page
    {
        public AppUniversal()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(Pages.List.Index));
        }

        private void Contac_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Pages.List.Index));
        }

        private void Contact_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //contentFrame.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = args.SelectedItem as NavigationViewItem;
                switch (selectedItem.Tag.ToString())
                {
                    case "List":
                        contentFrame.Navigate(typeof(Pages.List.Index));
                        break;
                    case "Form":
                        contentFrame.Navigate(typeof(Pages.Form.Index));
                        break;
                }
            }
        }
    }
}
