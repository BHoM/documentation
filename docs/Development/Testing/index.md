# BHoM Testing

BHoM allows to create tests of several types. We mainly distinguish between Unit/Functional Tests and Data-Driven Tests. This section explains in detail how to write Unit/Functional Tests for BHoM in Visual Studio. For [Data-Driven Tests](./Data-Driven-Tests), please refer to their section; in this page you will also find [a section dedicated to their comparison](#unit-tests-vs-functional-tests-vs-data-driven-tests).

The content of this page can be roughly summarised as:

- [Setting up a Toolkit with a Test solution](#tests-solution-setup)
- [Creating Test projects](#create-a-new-a-test-project)
- [Writing tests](#writing-tests)
    - [Differences between Unit tests, Functional tests and Data-Driven tests](#unit-tests-vs-functional-tests-vs-data-driven-tests)
    - [Leveraging NUnit](#leveraging-the-nunit-test-framework-setup-and-teardown)
- [Running tests](#running-tests)
- [Good practices like Test Driven Development (TDD)](#test-driven-development-tdd)

## Tests Solution setup

BHoM operates a separation between tests and functionality/object models. This is achieved by placing the tests in a different solution from the main repository solution.

In this page, we will make an example where we want to create tests for the Robot_Toolkit.

### Create a new `unit-tests` directory

To add a new test solution, please create a new `unit-tests` folder in the Toolkit's `.ci` directory, e.g.:

![image](https://github.com/BHoM/documentation/assets/6352844/5eab5ee8-ad4e-4cb6-968d-bdd9ba41eb8b)

If a `.ci` folder does not exist in your Toolkit yet, create that first.

### Create a new test solution

You can create a new Test solution in Visual Studio from the File menu as shown below.

![2023-08-22 13_16_15-Diffing_Tests - Microsoft Visual Studio](https://github.com/BHoM/documentation/assets/6352844/4e6e299b-5ad8-4c74-9fee-14e1fca34d5c)

Search for NUnit in the search bar and select it:

![2023-08-22 13_16_33-Diffing_Tests - Microsoft Visual Studio](https://github.com/BHoM/documentation/assets/6352844/1ea16771-cc5e-4400-8a12-7184618aad80)

Make sure that you have "create new solution" and "place solution and project in the same directory" toggled on. 

Please name the new test solution with the same name as the main toolkit plus the suffix `_Tests`. For example, for Robot_Toolkit, the new test solution will be called `Robot_Toolkit_Tests`. 

![2023-08-22 13_16_47-Diffing_Tests - Microsoft Visual Studio](https://github.com/BHoM/documentation/assets/6352844/fd75629a-95f4-403a-a883-b8320a6c222d)

This will create a new solution with a dummy NUnit test project in it. For example, if we are setting up the `Robot_Toolkit_Tests` for the first time, we will end up with this:

![image](https://github.com/BHoM/documentation/assets/6352844/3e67b9ac-12a4-40ca-bd4c-ba8bb8fdfee1)


### Add the existing Toolkit projects to the Test solution

In order to reference the main Toolkit projects, you can add "Existing projects" to the test solution. This will allow debugging the Toolkit code while running the unit tests. 

Right-click the solution name in the Solution Explorer and do "Add existing project":

![image](https://github.com/BHoM/documentation/assets/6352844/56c5da91-2e60-444e-8d7b-d60677a504cb)

Navigate to the Toolkit's repository and select the Toolkit's oM project, if it exists:

![image](https://github.com/BHoM/documentation/assets/6352844/46770f2f-85e2-4652-a9c4-fcfc8eef328c)

This will add the Toolkit's oM project to the Test solution.

Repeat for all the Toolkit's projects, e.g. the Engine and Adapter ones, if they exist. In the example for the Robot_Toolkit, you will end up with this:

![image](https://github.com/BHoM/documentation/assets/6352844/9c35d93d-9632-4b05-851e-30270f10232f)


### Add a Solution Configuration for more efficient testing

After adding the Toolkit's existing projects to the Test solution, you can add a new "Test" _Solution Configuration_ that can be used when running tests.

Doing this allows to avoid time-consuming situations, like when you need to close software that locks the centralised assemblies (e.g. Rhino Grasshopper, Excel) whenever you want to compile or run Unit Tests. This is because BHoM relies on post-Build Events to copy assemblies in the `ProgramData/BHoM folder`, and if a software locks them, the project cannot build successfully. 

Go in the Configuration Manager as below:

![image](https://github.com/BHoM/documentation/assets/6352844/269954e2-7df3-49ef-8e1b-0ce85aca7ee5)

Then select "New":

![image](https://github.com/BHoM/documentation/assets/6352844/f494fb79-80c8-4e22-ac16-348efa7254b2)

And do the following:

![image](https://github.com/BHoM/documentation/assets/6352844/97a0ed93-2fa6-4ca1-948a-d6fe8a2d5322)

This will create a new _Solution Configuration_ called "Test". Make sure it's always selected when running tests from the Test solution:

![image](https://github.com/BHoM/documentation/assets/6352844/556e465f-2b30-4d28-a73f-5fb3d425b0da)

In order to get the benefits from this, we will need to edit the Post-build events of every non-test project in the Toolkit (in our example for the Robot_Toolkit, these are only 3: the Robot_oM, the Robot_Engine, and the Robot_Adapter). Let's take the example of Robot_oM. The post-build events can be accessed by right-clicking the project, selecting Properties, then looking for "Post-build Events". 

![image](https://github.com/BHoM/documentation/assets/6352844/ff94e8fa-a3ab-41ce-813f-e5587d852088)

The post build events should look something like this:
```
xcopy "$(TargetDir)$(TargetFileName)" "C:\ProgramData\BHoM\Assemblies" /Y
```

This instructs the MSBuild process to copy the compiled assembly to the BHoM central folder, from where they can be loaded by e.g. UIs like Grasshopper. We do not want this copy process to happen when we are only testing via NUnit. Therefore, we can modify the post build event by replacing it with:

```
if not "$(ConfigurationName)" == "Test" (xcopy "$(TargetDir)$(TargetFileName)" "C:\ProgramData\BHoM\Assemblies" /Y)
```

This means that the post-build event is going to be triggered only when the Solution Configuration is _not_ set to "Test". 

!!! warning "Solution Configuration"

    Make sure that the Solution Configuration is always set to "Test" when you are in the Test solution (e.g. `GitHub/Robot_Toolkit/.ci/unit-tests/Robot_Toolkit_Tests.sln`) and **not selected** when you are in the normal toolkit solution (e.g. `GitHub/Robot_Toolkit/Robot_Toolkit.sln`).
    
    If you have followed the guide so far, this will work fine.
    
    The only thing that this changes is that the DLLs are not copied in the BHoM central location if the "Test" configuration is selected: in you are developing some new functionalty and you want the change to appear in e.g. a UI like Grasshopper, you need to make sure to compile the solution with the "Debug" configuration!
    




## Create a new a test project

At this point, you should have a Test solution `.sln` file in your Toolkit's `.ci` folder, e.g. something like `GitHub/Robot_Toolkit/.ci/unit-tests/Robot_Toolkit_Tests.sln`.  
You will now want to create a Test project where we can write tests.

### Decide what the Test project should target
In order to create a new test project, you should decide what kind of functionality you will want to test there. Because BHoM functionality only resides in Engine and Adapter projects (not oM projects), we can have one test project corresponding to each Engine/Adapter project.

For example, say you want to write tests to verify the functionality that is contained in some Robot_Engine method, for example, [`Robot.Query.GetStringFromEnum()`](https://github.com/BHoM/Robot_Toolkit/blob/5e04c82a081e3dafab3213c6f89363f0840ad3cf/Robot_Engine/Query/GetStringFromEnum.cs#L32-L49). Because this method resides in the Robot_Engine, we will need to place it into a Test project that is dedicated to testing Robot_Engine functionality.

We can create a new test project for this. Right-click on the Solution in the Solution Explorer and do "Add" and then "New Project":

![image](https://github.com/BHoM/documentation/assets/6352844/5c1c1ba4-474d-42d9-84f2-4001b5cde794)


Search for NUnit in the search bar and select it:

![image](https://github.com/BHoM/documentation/assets/6352844/c7cbede5-cd9c-46e4-bf70-ca3fa9e075cc)


Because this test project will target functionality in the Robot_Engine, let's name it appropriately as `Robot_Engine_Tests`:

![image](https://github.com/BHoM/documentation/assets/6352844/e78e5a1f-be13-474f-915b-290489c5c6c3)

Click next and accept `.NET 6` as the target framework, then click "Create".

![image](https://github.com/BHoM/documentation/assets/6352844/997cc2da-1e51-44b5-a9ed-45704294dad4)

We will end up with this new test project:

![image](https://github.com/BHoM/documentation/assets/6352844/67485625-7f13-42e7-bcb2-2834238782de)

We can also delete the dummy test project at this point. Right-click the Robot_Toolkit_Test project and do "remove":

![image](https://github.com/BHoM/documentation/assets/6352844/99696b25-445f-4c6f-89cd-8e660d684dd2)


We end up with this situation:

![image](https://github.com/BHoM/documentation/assets/6352844/7e08268c-72e3-42b2-9102-ee0d41ddb414)


### Configure the default namespace for the test project

We want to set up the default namespace for tests included in this project. To do so, right-click the test project and go in Properties:

![image](https://github.com/BHoM/documentation/assets/6352844/6c76d690-3f75-4569-93b9-de380e44114e)

Type "default namespace" in the search bar at the top, then replace the text into the text box with an appropriate namespace. The convention is: start with `BH.Tests.`, then append `Engine.` or `Adapter.` depending on what the test project tests will target; then end with the name of the software/toolkit that the project targets, for example `Robot`. For our example so far, we will have `BH.Tests.Engine.Robot`.

![image](https://github.com/BHoM/documentation/assets/6352844/7877c27d-f618-4bc9-8146-dd0931ac2add)



### Adding references to a Test Project

#### Add existing project references
Because the test will verify some functionality placed in another project, namely the Robot_Engine, we need to add a reference to it. Right-click the project's dependencies and do "add project reference":

![image](https://github.com/BHoM/documentation/assets/6352844/27821c22-76fa-448c-b38d-747684f1daa5)

Then add the target project and any upstream dependency to the target project. For example, if adding an Engine project, make sure you add also the related oM project; if adding an Adapter project, add both the related Engine and oM projects.

![image](https://github.com/BHoM/documentation/assets/6352844/949e84bb-f5eb-4228-b069-735117dddfdc)

#### Add other BHoM assemblies dependencies

Most likely you will need to reference also other assemblies in order to write unit tests. Again, right-click the project's dependencies and do "add project reference", then click on "Browse" and "Browse" again:

![image](https://github.com/BHoM/documentation/assets/6352844/67f428ba-8ee1-4c45-ad31-e756f1f08d28)

This will open a popup. Navigate to the central BHoM installation folder, typically `C:\ProgramData\BHoM\Assemblies`. Add any assembly that you may need. These will appear under the "Assemblies" section of the project's Dependencies. 

Typically, a structural engineering Toolkit will need the following assembly references, although they will vary case by case:

![image](https://github.com/BHoM/documentation/assets/6352844/7b362ae2-acd4-413c-a1d6-4d0e6abc5cae)

Once you have added the assemblies, please select all of them as in the image above (click on the top one, then shift+click the bottom one) and then right click on one of them. Select "Properties" and under "Copy Local" make sure that "True" or "Yes" is selected:

![image](https://github.com/BHoM/documentation/assets/6352844/f931a678-0236-4d39-b6a6-e8586fd56b48)

This is required to make sure that NUnit can correctly grab the assemblies.

### Adding extra NuGet packages

We can leverage some other NuGet packages to make tests simpler and nicer. 

If you want your Unit test to be automatically invocable by CI/CD mechanisms, you should check with the DevOps lead if the NuGet packages you want to use are already supported or can be added to the CI/CD pipeline. The following packages are already supported.

#### Add FluentAssertions

We use the FluentAssertions NuGet package for easier testing and logging.
Please add it by right-clicking the Project's Packages and do "Manage NuGet packages":

![image](https://github.com/BHoM/documentation/assets/6352844/fa9f6d9e-cb8d-4a59-943b-c5617aa5771f)

Click "Browse", then type "FluentAssertions" in the search bar. Select the first result and then click "Install":

![image](https://github.com/BHoM/documentation/assets/6352844/83410ddb-7820-4a10-976c-acb2c5d2c442)

We will provide some examples on how to use this library below. Please refer to the [FluentAssertions documentation](https://fluentassertions.com/introduction) to see all the nice and powerful features of this library.


## Writing tests

Let's image we want to write some test functionality for the Robot Query method called [`Robot.Query.GetStringFromEnum()`](https://github.com/BHoM/Robot_Toolkit/blob/5e04c82a081e3dafab3213c6f89363f0840ad3cf/Robot_Engine/Query/GetStringFromEnum.cs#L32-L49). Because this method resides in the Robot_Engine, we will need to place it into the `Robot_Engine_Tests` project (created as explained above).

Because the method we want to test is a Query method, let's create a folder called `Query`:

![image](https://github.com/BHoM/documentation/assets/6352844/d171e3f5-6766-4437-abe3-b1555c17bcad)

Right-click the newly created Query folder and do Add new Item:

![image](https://github.com/BHoM/documentation/assets/6352844/cd8d4d5b-f695-4415-b958-819f5d292421)

Let's call the new item as the method we want to test, e.g. `GetStringFromEnum`:

![image](https://github.com/BHoM/documentation/assets/6352844/e2bd9605-2159-41e5-b0c9-5ac642b563c5)

Let's edit the content of the generated file, so it looks like the following.

```cs
using NUnit;
using NUnit.Framework;
using FluentAssertions;

namespace BH.Tests.Engine.Robot.Query
{
    public class GetStringFromEnumTests
    {
        [Test]
        public void GetStringFromEnum()
        {

        }
    }
}
```

In particular, note that:
- we added a `using NUnit;`, `using NUnit.Framework;` and `using FluentAssertions;` at the top;
- we edited the name of the class appending `Tests`
- We added an empty test method called as the Engine method we want to verify (`GetStringFromEnum`). The test method is decorated with the `[Test]` attribute.

### Unit test sections: Arrange, Act, Assert

Every good unit test should be composed by these 3 clearly identifiable main sections (please refer to [Microsoft's Unit testing best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#arranging-your-tests) for more info and examples):

- **Arrange**: any statement that defines the inputs and configurations required to do the verification;
- **Act**: execute the functionality that we want to verify, given the Arrange setup;
- **Assert**: statements that make sure that the result of the Act is as it should be.

The test structure should always be clear and follow this structure. Each test should only verify a specific functionality. You can have multiple assertion statements if they all concur to test the same functionality, but it can be a red flag if you have more than two or three: it often means that you should split (or parameterise) the test.

### Your first unit test: a simplistic example

Following the example so far, we could write this code for the `GetStringFromEnum()` test method:

```cs
[Test]
[Description("Verify that the GetStringFromEnum() method returns the correct string for a specific DesignCode_Steel enum value.")]
public void GetStringFromEnum()
{
    // Arrange
    // Set up any input or configuration for this test method.
    var input = oM.Adapters.Robot.DesignCode_Steel.BS5950;

    // Act
    // Call the target method that we want to verify with the given input.
    var result = BH.Engine.Adapters.Robot.Query.GetStringFromEnum(input);

    // Assert
    // Make sure that the result of the Act is how it should be.
    result.Should().Be("BS5950");
}
```

Note that we use [FluentAssertions'](#fluentassertions) `Should().Be()` method to verify that the value of the result is equal to the string `BS5950`, as it is supposed to be when calling the `GetStringFromEnum` engine method with the input `DesignCode_Steel.BS5950`.

Also note that a good practice is to add a test `[Description]` too! This is very helpful in case the test fails, so you get an explanation of what kind of functionality verification failed and what how it was supposed to work.

!!! warning "Why this is a bad example of unit test"

    This example is simplistic and shown for illustrative purposes. It's not a good unit test for several reasons:

    - we are not testing every possible combination of inputs to the `GetStringFromEnum()` engine method and related outputs. 
    - it hard-codes the value `BS5950`. We took that value by copying it from the body of the `GetStringFromEnum()` method and copying it in the Assert statement. This effectively duplicates that value in two places. If the string in the engine method was modified, you would need to modify the test method too. You should avoid this kind of situation and limit yourself to verifying things variables defined as part of the "Arrange" step.

    See below for better examples of unit tests.

### Better examples of good unit tests
To illustrate good unit tests, let's look at another repository, the Base BHoM_Engine. Let's look at the test in the [`IsNumericIntegralTypeTests`](https://github.com/BHoM/BHoM_Engine/blob/f18a175c2c14f703f7f62e7cdee7658e8c4618c9/.ci/unit-tests/Base_Engine_Tests/Query/IsNumericIntegralType.cs#L31-L52) class, which looks like this (edited and with additional comments for illustrative purposes):

```cs
namespace BH.Tests.Engine.Base.Query
{
    public class IsNumericIntegralTypeTests
    {
        [Test]
        public void AreEnumsIntegral()
        {
            // Arrange. Set up the test data
            var input = typeof(DOFType);

            // Act. Invoke the target engine method.
            var result = BH.Engine.Base.Query.IsNumericIntegralType(input);

            // Assert. Verify that the output of the Act is how it should be.
            // If it fails the message in the string will be returned.
            result.ShouldBe(true, "By default, IsNumericIntegralType() considers enums as a numeric integral type.");
        }

        [Test]
        public void AreIntsIntegral()
        {
            // Arrange. Set up the test data
            var input = 10.GetType();

            // Act. Invoke the target engine method.
            var result = BH.Engine.Base.Query.IsNumericIntegralType(input);

            // Assert. Verify that the output of the Act is how it should be.
            // If it fails the message in the string will be returned.
            result.ShouldBe(true, "Integers should be recongnised as Numeric integral types.");
        }
    }
}

```

As you can see, this class contains 2 tests: `AreEnumsIntegral()` and `AreIntsIntegral()`. A single test class should test the same "topic", in this case the `BH.Engine.Base.Query.IsNumericIntegralType()` method, but it can (and should) do so with as many tests as needed.  
The first test checks that C# Enums are recognised as integers by the method `IsNumericIntegralType` (they should be). The second test checks that the same method also recognises C# Integers are recognised as integers.  
A good idea would be to add a test that verifies that a non-integral numerical value is recognised as _not an integer_, for example a `double` like `0.15`. Another test could be verifying that a non-numerical type is also recognised as _not an integer_, for example a `string`.  
Test should be "atomical" like this, because if something goes wrong, there is going to be a specific test telling you what did go wrong!

Why are these tests better examples of good unit tests than the one in the previous section?

- The expected output data is lightweight and limited to True/False boolean; it can be "hard-coded" safely in the unit test itself. Writing `result.ShouldBe(true)` makes sense, as opposed to `result.ShouldBe(someVerySpecificString)` or `result.ShouldBe(someHugeDataset)`.
- Because the output data has only a limited set of outcomes (True/False), the target method is well suited to be verified with a Unit test like this rather than a [Data-driven test](./Data-Driven-Tests).

For more examples of good tests, keep reading.


### Unit tests VS Functional tests VS Data-Driven tests

The example above is simple, as unit tests are supposed to be. The power of unit tests comes by creating many simple unit tests that verify the smallest possible functionality. You should always strive to write simple unit tests. 

Larger functionality verifications are also possible, in which case we talk about _Functional tests_. However, functional tests are slow to execute and, when they fail, they do not give good understanding of the possible causes for the failure, because they encompass too many things. A good practice is to have a good mix of functional tests and unit tests. Please refer to [Microsoft's Unit testing best practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) for more information.

In some cases, as mentioned [in the section above](#better-examples-of-good-unit-tests), the verification may need to target a complex set of data. For example, you may want to test your method against a "realistic" set of object, for example, many different input objects that cannot be generated easily from the code itself but can be easily generated in e.g. Grasshopper. In these cases, you should rely on **Data-driven tests** rather than unit tests. See the [Data-driven tests section](./Data-Driven-Tests) for more information.

!!! info "_unit test_ as an umbrella term"

    Sometimes, people use the term "_unit tests_" as an umbrella term for all kinds of tests. 
    This is incorrect, as the only really generic umbrella term should be "test". However, it's a common misconception that it's often done in development.  
    In BHoM we mistakenly perpetrate it in a couple of places:
    
    - in the setup of the [Test Solution parent folder](#create-a-new-unit-tests-directory) (the `.ci/unit-tests` folder; we should have `.ci/tests`)
    - in the name of the [Data-Driven test component](./Data-Driven-Tests.md) (which is called "unit test", but could be called "data driven test").

#### A Functional test example
Examples of Functional tests can be seen in the `Robot_Adapter_Tests` project. Adapter Test projects will likely contain lots of functional tests, as we care about testing complex behaviours like Push and Pull. 

For example, see below the test [`PushBarsWithTagTwice()`](https://github.com/BHoM/Robot_Toolkit/blob/5e04c82a081e3dafab3213c6f89363f0840ad3cf/.ci/unit-tests/Robot_Adapter_Tests/PushTests.cs#L127-L155) (this is slightly edited and with additional comments for illustration purposes). We test the behaviour of the Push and Pull functionality, which in the backend is composed by a very large set of function calls. The test a first set of 3 bars, then a second set of 3 bars, and all bars are pushed with the same Tag; then it verifies that the second set of bars has overridden the first set.

```cs
[Test]
[Description("Tests that pushing a new set of Bars with the same push tag correctly replaces previous pushed bars and nodes with the same tag.")]
public void PushBarsWithTagTwice()
{
    // Arrange. Create two sets of 3 bars.
    int count = 3;
    List<Bar> bars1 = new List<Bar>();
    List<Bar> bars2 = new List<Bar>();
    for (int i = 0; i < count; i++)
    {
        bars1.Add(Engine.Base.Create.RandomObject(typeof(Bar), i) as Bar);
    }

    for (int i = 0; i < count; i++)
    {
        bars2.Add(Engine.Base.Create.RandomObject(typeof(Bar), i + count) as Bar);
    }

    // Act. Push both the sets of bars. Note that the second set of bars is pushed with the same tag as the first set of bars.
    m_Adapter.Push(bars1, "TestTag");
    m_Adapter.Push(bars2, "TestTag");

    // Act. Pull the bars and the nodes.
    List<Bar> pulledBars = m_Adapter.Pull(new FilterRequest { Type = typeof(Bar) }).Cast<Bar>().ToList();
    List<Node> pulledNodes = m_Adapter.Pull(new FilterRequest { Type = typeof(Node) }).Cast<Node>().ToList();

    // Assert. Verify that the count of the pulled bars is only 3, meaning that the second set of bars has overridden the first set of bars.
    pulledBars.Count.ShouldBe(bars.Count, "Bars storing the tag has not been correctly replaced.");

    // Assert. Verify that the count of the pulled nodes is only 6, meaning that the second set of bars has overridden the first set of bars.
    pulledNodes.Count.ShouldBe(bars.Count * 2, "Node storing the tag has not been correctly replaced.");
}
```


### Leveraging the NUnit test framework: setup and teardown

When writing unit tests, you should leverage the NUnit test framework and other libraries in order to write clear, simple and understandable tests.

You may want to define NUnit "startup" methods like [`[OneTimeSetup]`](https://docs.nunit.org/articles/nunit/writing-tests/attributes/onetimesetup.html) or [`[Setup]`](https://docs.nunit.org/articles/nunit/writing-tests/attributes/setup.html?q=setup) in order to execute some functionality when a test starts, for example starting up an adapter connection to a software. Similarly, you can define "teardown" methods to define some functionality that must be executed when a test finishes, for example closing some adapter connection. 

Please refer to the [NUnit guide](https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html) to learn how to define startup and teardown methods.

For example, [we defined such methods for the Robot_Adapter_Tests test project](https://github.com/BHoM/Robot_Toolkit/blob/5e04c82a081e3dafab3213c6f89363f0840ad3cf/.ci/unit-tests/Robot_Adapter_Tests/PushTests.cs#L44-L76). Let's look at the OneTimeSetup done in Robot_Adapter_Tests:

```cs
namespace BH.Tests.Adapter.Robot
{
    public class PushTests
    {
        RobotAdapter m_Adapter;

        [OneTimeSetUp]
        public void OntimeSetup()
        {
            m_Adapter = new RobotAdapter("", null, true);
            //... more code ...
        }

        //... more code ...
    }
}
```
Here, we use the OneTimeSetup method to define a behaviour that should be executed **only once** before the tests contained in the class `PushTests` are run. This behaviour is the initialization of the RobotAdapter, which is stored in a variable in the class. All tests are going to reuse the same RobotAdapter instance, avoiding things like having to re-start Robot for each and every test, which would be time-consuming.

Check the [Robot_Adapter_Tests test project](https://github.com/BHoM/Robot_Toolkit/blob/5e04c82a081e3dafab3213c6f89363f0840ad3cf/.ci/unit-tests/Robot_Adapter_Tests/PushTests.cs#L44-L76) for more examples of Setup and Teardown methods, and refer to the [NUnit guide](https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html) for more examples and info.


## Running tests

All tests existing in a Test solution can be found in the Test Explorer. If you can't find the Test Explorer, use the search bar at the top and type "Test Explorer":

![image](https://github.com/BHoM/documentation/assets/6352844/a3785c42-8531-4fe0-aeee-411a896cf80f)

You can run a single test by right-clicking the test and selecting Run or Debug. If you choose "debug", you will be able to hit [break points](https://learn.microsoft.com/en-us/visualstudio/debugger/using-breakpoints?view=vs-2022) placed anywhere in the code.

By running tests often, you will be able to quickly develop new functionality while making sure you are not breaking any existing functionality.

### Test Driven Development (TDD)

A good practice is Test Driven Development (TDD), which consists in writing tests first, and implement the functionality in the "Act" step later. You can create a stub of the implementation that does nothing, write the tests that should verify that it works fine, and then develop the functionality by adding code to the body of the stub.

Doing so allows focusing on the "what" first, and the "how" later. You can develop several unit tests to verify the new functionality that you want to develop. This helps to focus on the requirements and the target result that you want to achieve. In many cases, the implementation will then almost "write itself", and you will also end up with a nice collection of unit tests that can be reused to verify that everything keeps working also years later!
