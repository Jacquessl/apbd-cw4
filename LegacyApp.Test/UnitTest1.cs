
namespace LegacyApp.Test;

public class Tests
{
    [Test]
    public void AddUserTest()
    {
        var userService = new UserService();
        var addResult = userService.AddUser(null, "dsads", "dse@gmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
    [Test]
    public void AddUserTest2()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("noice", null, "dse@gmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.False(addResult);
    }
    [Test]
    public void AddUserTest3()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("noice", "Doe", "dsegmail.com", DateTime.Parse("1982-03-21"), 1);
        Assert.True(addResult);
    }[Test]
    public void AddUserTest4()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("noice", "Doe", "dse@gmailcom", DateTime.Parse("1982-03-21"), 1);
        Assert.True(addResult);
    }[Test]
    public void AddUserTest5()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("noice", "Doe", "@.", DateTime.Parse("1982-03-21"), 1);
        Assert.True(addResult);
    }
    
}