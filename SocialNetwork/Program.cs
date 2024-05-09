using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
class Program
{
    static UserService userService;
    static MessageService messageService;
    static FriendService friendService;

    public static AuthenticationView authenticationView;
    public static RegistrationView registrationView;
    public static UserMenuView userMenuView;
    public static MainView mainView;
    public static MessageSendingView messageSendingView;
    public static UserDataUpdateView userDataUpdateView;
    public static UserIncomingMessagesView userIncomingMessagesView;
    public static UserOutcomingMessagesView userOutcomingMessagesView;
    public static UserInfoView userInfoView;
    public static UserFriendsView userFriendsView;
    public static RequestSendingView requestSendingView;
    public static RequestsOverviewView requestsOverviewView;

    static void Main(string[] args)
    {
        messageService = new MessageService(new MessageRepository(), new UserRepository());
        userService = new UserService(new UserRepository());
        friendService = new FriendService(new FriendRepository(), new FriendRequestRepository(), new UserRepository());

        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService, messageService, friendService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendingView = new MessageSendingView(messageService);
        userIncomingMessagesView = new UserIncomingMessagesView();
        userOutcomingMessagesView = new UserOutcomingMessagesView();
        userFriendsView = new UserFriendsView();
        requestSendingView = new RequestSendingView(friendService);
        requestsOverviewView = new RequestsOverviewView(friendService);

        while (true)
        {
            mainView.Show();
        }
    }
}