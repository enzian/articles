// BEGIN1 OMIT
public class HostContextTests
{
  [Fact]
  public void TestConstruction(){
    var subject = new Context();
    subject.LoadAllDependencies();
  }
}
// END1 OMIT


// BEGIN2 OMIT
public class HostContextTests
{
  public HostContextTests(){
      Subject = new Context();

      var dbSettings = new DatabaseSettings{
        Connection = "odbc://localhost...."
        TransactionScope = "read-committed"
      };

      Subject.DatabaseSettings = dbSettings;

      var messagingBus = new MessagingBus();
      messagingBus.Open("http://localhost:8080/bus");

      try {
        messagingBus.Connect();
        var message = new Message();
        var success = messagingBus.Send(message);

        if(!success){
          Assert.Fail("Test Failed");
        }

        Subject.MessageBus = messagingBus;
      }
      catch (Exception e) {
        Assert.Fail("Test failed");
      }

      ...
  }


  [Fact]
  public void TestConstruction(){
    // Arrange

    // Act
    var result = Subject.GetService<IUserDataService>();

    // Assert
    result.Should().NotBeNull("Context.GetService<T>() returned null for type IUserDataService");
  }
}
// END2 OMIT


// BEGIN3 OMIT
public class HostContextTests
{
  [Fact]
  public void TestConstruction(){
    // Arrange
    var subject = new Context();
    // Act
    var result2 = subject.HasDefinition<IUserDataService>()
    var result = subject.GetService<IUserDataService>();
    // Assert
    result.Should().NotBeNull("Context.GetService<T>() returned null for type IUserDataService");
    result2.Should().BeTrue();
  }
}
// END3 OMIT
