using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reflection.Metadata;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Cella.Desktop.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Cella - Warehouse Managment System V1.0";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Home",
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },    new NavigationItem()
                {
                    Content = "Sales",
                    PageTag = "sales",
                    Icon = SymbolRegular.CurrencyDollarEuro24,
                    PageType = typeof(Views.Pages.SalesOrderPage)
                },    new NavigationItem()
                {
                    Content = "Invoice",
                    PageTag = "invoice",
                    Icon = SymbolRegular.Receipt24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },    new NavigationItem()
                {
                    Content = "Drivers",
                    PageTag = "drivers",
                    Icon = SymbolRegular.Receipt24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },    new NavigationItem()
                {
                    Content = "Routes",
                    PageTag = "routes",
                    Icon = SymbolRegular.Receipt24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },    new NavigationItem()
                {
                    Content = "Drivers Progress",
                    PageTag = "driversprogress",
                    Icon = SymbolRegular.VehicleTruck24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },    new NavigationItem()
                {
                    Content = "Warehouse",
                    PageTag = "warehouse",
                    Icon = SymbolRegular.VehicleTruckCube24,
                    PageType = typeof(Views.Pages.DashboardPage)
                }
                ,    new NavigationItem()
                {
                    Content = "Pick Lists",
                    PageTag = "picklists",
                    Icon = SymbolRegular.List24,
                    PageType = typeof(Views.Pages.DashboardPage)
                    
                },

                new NavigationItem()
                {
                    Content = "Data",
                    PageTag = "data",
                    Icon = SymbolRegular.DataHistogram24,
                    PageType = typeof(Views.Pages.DataPage)
                }
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
