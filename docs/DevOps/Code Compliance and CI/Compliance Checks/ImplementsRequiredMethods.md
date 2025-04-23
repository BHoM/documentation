## Summary

**Severity** - Fail

**Check method** - [Here](https://github.com/BHoM/Test_Toolkit/blob/main/CodeComplianceTest_Engine/Query/DynamicChecks/ImplementsRequiredMethods.cs)

**Check frequency** - Nightly

## Details

The `ImplementsRequiredMethods` check ensures that any object which implements an `IElement` interface is also implementing, or has access to, the [required extension methods](https://bhom.xyz/documentation/BHoM_oM/Dimensional_oM/IElement-required-extension-methods/). Is an object does not have one of the required extension methods, then this check will report a failure for that object.