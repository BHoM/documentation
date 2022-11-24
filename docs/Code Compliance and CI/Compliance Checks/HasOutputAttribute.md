## Summary

**Severity** - Warning

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/master/CodeComplianceTest_Engine/Query/Checks/HasOutputAttribute.cs)

## Details

The `HasOutputAttribute` check ensures that a method has a `Output` or `MultiOutput` attribute explaining what the method is providing for users.

You can add an `Output` attribute with the following syntax sitting above the method:

`[Output("outputName", "Your description here")]`

If you have not used any attributes in your file previously, you may need to add the following using:

`using BH.oM.Reflection.Attributes;`

You may also need to add a reference to the `Reflection_oM` to your project if you have not previously used it.