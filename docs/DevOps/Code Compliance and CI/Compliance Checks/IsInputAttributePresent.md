## Summary

**Severity** - Warning

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/IsInputAttributePresent.cs)

## Details

The `IsInputAttributePresent ` check ensures that an input parameter has a matching `Input` or `InputFromProperty` attribute explaining what the input is required for users.

You can add an `Input` attribute with the following syntax sitting above the method:

`[Input("variableName", "Your description here")]`

Alternatively, if the methods returning object has a property which contains a description which matches the input parameter, you can use the `InputFromProperty` attribute with the following syntax:

`[InputFromProperty("variableName")]`

Or, if your methods returning object has a property which contains a description which matches the input parameter, but the variable name entering the method is not named the same as the object's property, you can use the `InputFromProperty` to match the two, like so:

`[InputFromProperty("variableName", "objectPropertyName")]`

If you have not used any attributes in your file previously, you may need to add the following using:

`using BH.oM.Reflection.Attributes;`

You may also need to add a reference to the `Reflection_oM` to your project if you have not previously used it.