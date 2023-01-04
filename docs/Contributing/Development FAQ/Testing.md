# Testing

BHoM has several ways to cover developed functionality with Tests.


## Storing unit test data for Engine Methods

Engine methods can be tested against regression via "Unit tests" that [can be run automatically via CI/CD](/documentation/DevOps/Code Compliance and CI/CI Checks/Check-Unit-Tests). Unit tests in this context consists in running Engine methods with pre-stored input data and comparing their results with pre-stored output data. This way, it is possible to check that Engine methods keep behaving reliably.

To store data for tests, you can use the [Test_Toolkit](https://github.com/BHoM/Test_Toolkit) and the `Unit Test` component.

![image](https://user-images.githubusercontent.com/6352844/210525746-f55ad541-4022-4418-b35a-b2f174620c66.png)

### Procedure

0. Compile the [Test_Toolkit](https://github.com/BHoM/Test_Toolkit) - it contains some useful methods that are not shipped in the BHoM installer.
1. Drop a `Unit Test` component in a script.
2. Right click the component and find the method you want to store test data for. 
3. Produce the test data for the method. The test data should be any input object that you may want to feed to the Engine method. The test data should be representative of the general usage of the method.
4. Connect the test data to the `Unit Test` component. The compnent will execute the target method in the backend with the provided data, and it will return one or more _Unit Test objects_, which contain the input and outputs related to the method execution.
5. The _Unit Test objects_ should now be stored in the `.ci` folder of the repository that defines the method being tested. We store the objects as json. In order to do this reliably, you can use the Test_Toolkit's `StoreUnitTests` function, like so:

   ![image](https://user-images.githubusercontent.com/6352844/210527902-53bdf492-d305-405b-9f2b-3be671204519.png)



The `StoreUnitTests` function will save the test data in the `.ci` folder of the repository. Make sure to commit and push the data in your PR.
