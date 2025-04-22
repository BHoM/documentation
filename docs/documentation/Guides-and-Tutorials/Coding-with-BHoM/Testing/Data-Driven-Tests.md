# Data driven tests

BHoM has several ways to cover developed functionality with Tests. An automated strategy for covering possible _regression_ (i.e. loss of functionality erroneously introduced by code changes) can be done with "Data driven tests".

Data driven tests are simply a way to take a "snapshot" of the input and output of a specific method. The input and output are stored in a dataset, together with the name of the method used to produce the output from the input. This data can be then used to automatically trigger the method at a later time, or periodically, to check that the method has not been broken e.g. with side-effects of other code changes elsewhere.

To record the test data, you simply need to run a target Engine method with some specific input data. The input data and the ouput of the method, together with the method name, will be recorded. When the data-driven test will be run, it will simply call again the method in question with the stored input data, and compare it with the output data. This way, it is possible to check that Engine methods keep behaving reliably.

This kind of "Data-driven Unit test" [can be run automatically via CI/CD](<../../../DevOps/Code Compliance and CI/CI Checks/Check-Unit-Tests.md>) for an automated checking of the functionality.

## Storing test data for Engine Methods

To store data for tests, you can use the [Test_Toolkit](https://github.com/BHoM/Test_Toolkit) and the `Unit Test` component.

![image](https://user-images.githubusercontent.com/6352844/210525746-f55ad541-4022-4418-b35a-b2f174620c66.png)

### Procedure

0. Compile the [Test_Toolkit](https://github.com/BHoM/Test_Toolkit) - it contains some useful methods that are not shipped in the BHoM installer.
1. Drop a `Unit Test` component in a script.
2. Right click the component. Use the search field to find and select method you want to store test data for. Once done, the component Unit test will transform into a `UT:MethodName` component.
   For example, if you want to test the method called `BaseTypes()`, type and select its name. The component will transform into a `UT:BaseType` component. See screenshot below.  
   This component will have as many input as the selected method. What it will do is simply run the selected method with any provided input data.
4. Produce some input test data for the method. This data is simply some objects that the method can take as an input. Don't just do random objects: think about what kind of test data an user may want to input to the test, and about particular "edge" situations you want to make sure that work. The input data should cover as many input combinations and "particular inputs" as it makes sense to, in order to have good [test coverage](https://en.wikipedia.org/wiki/Fault_coverage#Test_coverage_(computing)).
5. Connect the test data to the `Unit Test` component. The component will execute the target method with the provided data, and it will return one or more _Unit Test objects_, which contain the input and outputs related to the method execution.
6. At this point, we will want to store the  _Unit Test objects_ as a json somewhere where the automation can find them, so future testing can be done automatically. Our place of choice is the `.ci` folder of the repository where the method being tested can be found.
   In order to do this easily and reliably, you can use the Test_Toolkit's `StoreUnitTests` function. Please refer to the screenshot below.  
   The `StoreUnitTests` function will save the test data in the `.ci` folder of the repository. 

   ![image](https://user-images.githubusercontent.com/6352844/210527902-53bdf492-d305-405b-9f2b-3be671204519.png)

8. Make sure to commit and push the data in your PR.
