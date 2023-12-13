using Mopups.Interfaces;
using MyMauiTemplate.Models;
using MyMauiTemplate.Pages;
using MyMauiTemplate.Pages.Account;
using MyMauiTemplate.Services.Interfaces;
using MyMauiTemplate.Utilities;

namespace MyTinyShoppingHelper.Pages.Shopping_Main;

public partial class MainShoppingPage
{

    private readonly IUserService _userService;
    private readonly IPopupNavigation _popupNavigation;
    private User? _currentUser;

    public MainShoppingPage(IUserService userService, IPopupNavigation popupNavigation, User? user)
    {
        InitializeComponent();
        _userService = userService;
        _popupNavigation = popupNavigation;
        _currentUser = user;
    }

    private async void OnSettingsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage(_userService, _popupNavigation));
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        _currentUser = null;
        // Perform logout operations here
        _userService.CurrentUser = _currentUser;
        PreferencesHelper.ClearPreferences("AutoLogin");
        
        // Navigate to the login page or another appropriate page
        await Navigation.PushAsync(new LoginPage(_userService, _popupNavigation));    
    }

    private async void OnShoppingClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainShoppingPage(_userService, _popupNavigation, _currentUser));
    }

    private async void OnProfileClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage(_userService, _popupNavigation, _currentUser));
    }
}