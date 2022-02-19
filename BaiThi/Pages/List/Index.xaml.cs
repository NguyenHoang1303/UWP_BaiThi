using BaiThi.Data;
using BaiThi.Entity;
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

namespace BaiThi.Pages.List
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Index : Page
    {
        private List<Contact> listContact;
        public Index()
        {
            this.InitializeComponent();
            this.Loaded += Index_Loaded;
        }

        private void Index_Loaded(object sender, RoutedEventArgs e)
        {
            listContact = MigrateContact.findAll();
            dataContact.ItemsSource = listContact;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            ContentDialog contentDialog = new ContentDialog();
            listContact = MigrateContact.search(name, phone);
            if(listContact.Count == 0)
            {
                contentDialog.Title = "Search";
                contentDialog.Content = "Contact Not Found.";
                contentDialog.CloseButtonText = "OK";
                await contentDialog.ShowAsync();
                return;
            }
            dataContact.ItemsSource = listContact;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataContact.ItemsSource = MigrateContact.findAll();
        }
    }
}
