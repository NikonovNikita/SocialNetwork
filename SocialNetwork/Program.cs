using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
class Program
{
    static UserService userService;
    static MessageService messageService;

    public static AuthenticationView authenticationView;
    public static RegistrationView registrationView;
    public static UserMenuView userMenuView;
    public static MainView mainView;
    public static MessageSendingView messageSendingView;
    public static UserDataUpdateView userDataUpdateView;
    public static UserIncomingMessagesView userIncomingMessagesView;
    public static UserOutcomingMessagesView userOutcomingMessagesView;
    public static UserInfoView userInfoView;

    static void Main(string[] args)
    {
        messageService = new MessageService(new MessageRepository(), new UserRepository());
        userService = new UserService(new UserRepository());

        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService, messageService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendingView = new MessageSendingView(userService, messageService);
        userIncomingMessagesView = new UserIncomingMessagesView();
        userOutcomingMessagesView = new UserOutcomingMessagesView();

        while (true)
        {
            mainView.Show();
        }
    }
}