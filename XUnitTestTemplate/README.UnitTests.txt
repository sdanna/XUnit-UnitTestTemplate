The namespace for true unit tests should follow the pattern
of just being the name of the class under test.  Set the 
folders to not be a namespace provider.  Use the folder 
structure of the project that the class under tests uses in 
its project.  

Example:
Suppose you have a project called WebProject with a folder 
called Components with a class called Emailer that you want
to test.

WebProject
     |___Components
            |____Emailer.cs
            
Your corresponding XUnit test project would have a structure
like the following.

XUnitProject
     |___Components
            |____EmailerTests.cs
            
Look at this class for an example of how to set up the nested 
namespacing so that tests are well organized and also at how 
they should be named.

namespace ExampleClassTests
{
    public class MethodUnderTest1_Should
    {
        [Fact]
        public void Return_SomeValue_Under_Some_Condition()
        {
            // Arrange, Act, Assert
        }

        [Fact]
        public void Return_SomeOtherValue_Under_Another_Condition()
        {
            // Arrange, Act, Assert
        }
    }

    public class MethodUnderTest2_Should
    {
        [Fact]
        public void Return_SomeValue_Under_Some_Condition()
        {
            // Arrange, Act, Assert
        }

        [Fact]
        public void Throw_A_Specific_Type_Of_Exception_Under_Some_Condition()
        {
            // Arrange, Act, Assert
        }
    }
}

See the XUnit_UnitTestProjectReference.cs class for some best practices as 
far as test layout goes.  

Definitely look at the links provided in the comments at the top of the file
to get a handle on how the framework works.  Have a good look at how to 
setup and teardown tests as it is different in XUnit than in other frameworks.