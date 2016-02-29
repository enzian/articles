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

// BEGIN3 OMIT
f.Property = 5;
A.CallTo(() => f.ReadOnly).Returns(8);

A.CallTo(() => f.GetValue()).Returns(42);
A.CallTo(() => f.GetValue()).ReturnsNextFromSequence(1, 2, 3, 4);

int i = 0;
A.CallTo(() => f.GetValue()).ReturnsLazily(() => i++);
// END3 OMIT

// Assert1 OMIT
A.CallTo(() => f.DoIt()).MustHaveHappened();
A.CallTo(() => f.DoIt()).MustHaveHappened(Repeated.AtLeast.Once);
A.CallTo(() => f.DoIt()).MustNotHaveHappened();
A.CallTo(() => f.DoIt()).MustHaveHappened(Repeated.Never);
A.CallTo(() => f.DoIt()).MustHaveHappened(Repeated.AtLeast.Twice);
A.CallTo(() => f.DoIt()).MustHaveHappened(Repeated.Exactly.Times(3));
A.CallTo(() => f.DoIt()).MustHaveHappened(Repeated.NoMoreThan.Once);
// Assert1End OMIT

// ARGUMENTMATCHING OMIT
A.CallTo(() => f.Request(3)).Returns(5);
A.CallTo(() => f.Request(3)).MustHaveHappened();
// ARGUMENTMATCHINGEND OMIT


// ARGUMENTMATCHING1 OMIT
A<int>._
A<int>.Ignored
A<int>.That.Matches(i => i == 5)
A<string>.That.StartsWith("g")
A<string>.That.Not.IsEmpty()
// ARGUMENTMATCHINGEND1 OMIT

// BEGINEVENTS OMIT
f.Trigger += Raise.WithEmpty().Now;
f.Trigger += Raise.With(new EventArgs()).Now;
f.Trigger += Raise.With(this, new EventArgs()).Now;
// ENDEVENTS OMIT

// INVOCATIONARGS OMIT
A.CallTo(() => f.Request(A<int>._))
  .ReturnsLazily((int i) => i + 5);
// INVOCATIONARGSEND OMIT

// INVOCATIONARGS1 OMIT
A.CallTo(() => f.Request(A<int>._))
  .ReturnsLazily(call => call.GetArgument<int>(0) + 5);
// INVOCATIONARGSEND1 OMIT

// EXCEPTIONS OMIT
A.CallTo(() => f.GetValue()).Throws<Exception>();

A.CallTo(() => f.GetValue()).Throws(new Exception());

A.CallTo(() => f.Request(A<int>._)).Throws((int i) => new MyException(i));
// EXCEPTIONSEND OMIT
