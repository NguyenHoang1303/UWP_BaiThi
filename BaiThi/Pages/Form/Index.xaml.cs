using BaiThi.Data;
using BaiThi.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BaiThi.Pages.Form
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Index : Page
    {
        public Index()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog();
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                contentDialog.Title = "Fail";
                contentDialog.Content = "Vui lòng nhập đủ thông tin";
                return;
            }
            
            Contact contact = new Contact();
            contact.Name = txtName.Text;
            contact.Phone = txtPhone.Text;
            if (MigrateContact.Save(contact)) {
                contentDialog.Title = "Success";
                contentDialog.Content = "Tạo thành công.";
                Debug.WriteLine(txtName.Text);
                Debug.WriteLine(txtPhone.Text);
            }
            else
            {
                contentDialog.Title = "Fail";
                contentDialog.Content = "Tạo thất bại";
            }
            contentDialog.CloseButtonText = "OK";
            await contentDialog.ShowAsync();
        }
    }
}
