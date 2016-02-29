// BEGIN1 OMIT
public class ServiceContext
{
  public ServiceFactory Factory { get; set; }

  public IEnumerable<IService> Services { get; set; }

  public IService GetService<T>(){
    if(Services.Contains(x => x.GetType() == typeof(T)){
      return Services.First(x => x.GetType() == typeof(T)
    }

    return Factory.CreateService<T>();
  }
}
// END1 OMIT


// BEGIN2 OMIT
public class ServiceContextTest
{
  [Fact]
  public void GetService_IfServiceNotCached(){
      // Arrage
      var subject = ServiceContext();
      var fakeFactory = A.Fake<IServiceFactory>();
      A.CallTo(() => fakeFactory.GetService<IService>()).Returns(A.Fake<IService>())

      // Act
      var result = subject.GetService<IService>();

      // Assert
      result.Should().NotBeNull();
  }
}
// END2 OMIT
