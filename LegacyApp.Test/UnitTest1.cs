namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Doe", "dsegmailcom", DateTime.Parse("1982-03-21"), 4);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Doe", "dse@gmail.com", DateTime.Parse("2005-03-21"), 4);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("Jan", "Malewski", "dsda@d.d", DateTime.Parse("2000-10-01"), 2);
        Assert.True(addResult);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Doe", "dse@gmail.com", DateTime.Parse("1995-03-21"), 4);
        Assert.True(addResult);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Kwiatkowski", "dse@gmail.com", DateTime.Parse("1995-03-21"), 5);
        Assert.True(addResult);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        var userService = new UserService();
        var addResult = userService.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", DateTime.Parse("1995-03-21"), 6);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();
        Assert.Throws<ArgumentException>(() =>
            userService.AddUser("John", "Andrzejewiczz", "dsa@.", DateTime.Parse("1990-03-20"), 7));
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}