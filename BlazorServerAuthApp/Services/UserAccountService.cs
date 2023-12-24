using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerAuthApp;

public class UserAccountService
{
    public List<UserAccount> _users;

    private readonly string CosmosDBAccountUri = "https://myapp-license-db.documents.azure.com:443/";
    private readonly string CosmosDBAccountPrimaryKey = "pvLGdvW1PYgSQmGijbn3OeX6KWy9Un0tkWHQzjfYfAtqcamJ6KJkGVAb5AEPXDsPEYS1UPpfXMZJACDbgXHHwg==";
    private readonly string CosmosDbName = "myapp-license-db";
    private readonly string CosmosDbContainerName = "Employees";

    private Container ContainerClient()
    {
        CosmosClient cosmosDbClient = new CosmosClient(CosmosDBAccountUri, CosmosDBAccountPrimaryKey);
        Container containerClient = cosmosDbClient.GetContainer(CosmosDbName, CosmosDbContainerName);
        return containerClient;
    }

    public UserAccountService()
    {
        // _users = new List<UserAccount> {
        //         //new UserAccount { UserName = "cenk.yenikoylu@spailor.com", Password = "123", Role = "administrator"},
        //         new UserAccount { EmployeeEmail = "sayhat.sirinoglu@spailor.com", LoginPassword = "456", Role = "user"}
        //     };

        GetUsers();
    }

    public async Task GetUsers()
    {
        try
        {
            //List<UserAccount> employees = new List<UserAccount>();
            var container = ContainerClient();

            FeedIterator<UserAccount> setItetator = container.GetItemLinqQueryable<UserAccount>()
            //.Where(m => m.AgencyName == "Spailor LLC")
            .ToFeedIterator<UserAccount>();

            while (setItetator.HasMoreResults)
            {
                FeedResponse<UserAccount> currentResultSet = await setItetator.ReadNextAsync();

                _users = currentResultSet.ToList();

                // foreach (UserAccount employees in currentResultSet)
                // {
                //     //_users.Add(employees);
                //     _users.AddRange(
                //         new List<UserAccount> {
                //         new UserAccount { EmployeeEmail = employees.EmployeeEmail,
                //             LoginPassword = employees.LoginPassword,
                //             Role = employees.Role}
                //         }
                //     );
                // }
            }
            //return _users;

            // using (var licenseContext = new DBContext())
            // {
            //     if (licenseContext.EmployeesDbSet != null)
            //     {
            //         _users = licenseContext.EmployeesDbSet.ToList();
            //     }
            // }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            //return _users;
        }
    }

    public UserAccount? GetByUserName(string userName)
    {
        //_users = GetUsers().Result.ToList();
        return _users.FirstOrDefault(x => x.EmployeeEmail == userName);
    }
}