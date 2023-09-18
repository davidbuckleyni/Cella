using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cella.WinUi
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
 
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
         }

        public void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            SetCurrentNavigationViewItem(args.SelectedItemContainer as NavigationViewItem);

        }
        public void SetCurrentNavigationViewItem(
    NavigationViewItem item)
        {
            if (item == null)
            {
                return;
            }

            if (item.Tag == null)
            {
                return;
            }

            ContentFrame.Navigate(
            Type.GetType(item.Tag.ToString()),
            item.Content);
            NavigationViewControl.Header = item.Content;
            NavigationViewControl.SelectedItem = item;
        }
        private void NavigateByTag(string tag)
        {
 
            if (this.NavigationViewControl.MenuItems
                .OfType<NavigationViewItem>()
                .Where(x => x.Tag.Equals(tag) is true)
                .FirstOrDefault() is NavigationViewItem item)
            {
                this.NavigationViewControl.SelectedItem = item;
                this.ContentFrame.Navigate(Type.GetType($"{item.Tag}"));
            }
        }

        private void SearchTxt_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }
    }
}
