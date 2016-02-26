// BEGIN1 OMIT
Interface f = A.Fake<Interface>();

A.CallTo(() => f.GetValue()).Returns(5);

A.CallTo(() => f.DoIt()).MustHaveHappened();
// END1 OMIT

// BEGIN2 OMIT
Interface f = A.Fake<Interface>();

Interface f = A.Fake<Interface>(x => x.Strict());

IList<Interface> fakes = A.CollectionOfFake<Interface>(3);
// END2 OMIT
