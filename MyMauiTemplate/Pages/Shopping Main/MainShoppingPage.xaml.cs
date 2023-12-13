using Mopups.Interfaces;
using MyMauiTemplate.Models;
using MyMauiTemplate.Services.Interfaces;

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
}