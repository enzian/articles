// SAMPLE OMIT
[Subject(typeof(SecurityService), "Authentication")]  // or a combo!
public class When_authenticating_an_admin_user
{
    Establish context = () =>
    {
        Subject = new SecurityService(foo, bar);
    };

    Because of = () => Token = Subject.Authenticate("username", "password");

    It should_indicate_the_users_role = () => Token.Role.ShouldEqual(Roles.Admin);
    It should_have_a_unique_session_id = () => Token.SessionId.ShouldNotBeNull();

    static SecurityService Subject;
    static UserToken Token;
}
// SAMPLEEND OMIT

// ATTRIBUTES OMIT
[Subject("Authentication")]                           // a description
[Subject(typeof(SecurityService))]                    // the type under test
[Subject(typeof(SecurityService), "Authentication")]  // or a combo!
public class When_authenticating_a_user { ... }       // Only one Subject Attribute is allowed
// ATTRIBUTESEND OMIT

// TAGS OMIT
[Tags("RegressionTest")]  // this attribute supports any number of tags via a params string[] argument!
[Subject(typeof(SecurityService), "Authentication")]
public class When_authenticating_a_user { ... }
// TAGSEND OMIT
