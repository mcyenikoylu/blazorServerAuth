namespace BlazorServerAuthApp;

public class UserAccountService
{
    private List<UserAccount> _users;

    public UserAccountService()
    {
        _users = new List<UserAccount> {
                new UserAccount { UserName = "cenk.yenikoylu@spailor.com", Password = "123", Role = "administrator"},
                new UserAccount { UserName = "sayhat.sirinoglu@spailor.com", Password = "456", Role = "user"}
            };
    }

    public UserAccount? GetByUserName(string userName)
    {
        return _users.FirstOrDefault(x => x.UserName == userName);
    }
}